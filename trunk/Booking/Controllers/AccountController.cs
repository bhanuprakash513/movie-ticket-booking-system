﻿using System;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using MovieBooking.BLL.Entities;
using MovieBooking.Model.Entities;
using MovieBooking.MVC.UI.Models;
using System.Collections.Generic;

namespace MovieBooking.MVC.UI.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            //Logger.Write("public ActionResult LogOn()!");
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            //Logger.Write("public ActionResult LogOn(LogOnModel model, string returnUrl)!");
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            //Logger.Write("public ActionResult LogOff()!");
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            //FindById
            //RegisteredUserRepository userRep = new RegisteredUserRepository();
            //System.Guid id = new Guid("0AE3AAEB-A8FC-43AC-B441-0E94C72CA9DB");
            //RegisteredUser user = userRep.FindById(id);
            //user.UserName = "Mansoor Test";
            //user.DOB = DateTime.Now;
            //user.BankName = "DBS";
            //user.AccountNo = "123-456789-0";
            //user.PostalCode = "009876";

            //Update
            //userRep.Update(user);
            
            //FindAll
            //IList<RegisteredUser> users = userRep.FindAll() as List<RegisteredUser>;
            
            //Caching
            //SystemParameterRepository sysRepo = new SystemParameterRepository();
            //IList<SystemParameter> param1 = sysRepo.GetSystemParameters("BookingStatus") as IList<SystemParameter>;
            ////to test the cache
            //IList<SystemParameter> param2 = sysRepo.GetSystemParameters("BookingStatus") as IList<SystemParameter>;

            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            //Logger.Write("public ActionResult Register(RegisterModel model)!");
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = this.RegisterMember(model);
                
                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region customised repository methods

        private MembershipCreateStatus RegisterMember(RegisterModel model)
        {
            // Attempt to register the user
            MembershipCreateStatus createStatus = MembershipCreateStatus.UserRejected;
            //
            DateTime dob;
            string[] dateFormats = new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "dd.MM.yyyy" };
            DateTime.TryParseExact(model.DOB, dateFormats, null, DateTimeStyles.None, out dob);
            //
            RegisteredUser _user = new RegisteredUser()
            {
                DOB = (dob == DateTime.MinValue) ? (DateTime?)null : dob,
                NRIC = model.NRIC,
                BankName = model.BankName,
                AccountNo = model.AccountNo,
                Address = model.Address,
                PostalCode = model.PostalCode,
                aspnet_Membership = new aspnet_Membership()
                {
                    Email = model.Email,
                    Password = model.Password,
                    aspnet_Users = new aspnet_Users() { UserName = model.UserName }
                }
            };

            RegisteredUserRepository userRep = new RegisteredUserRepository();
            int status = userRep.Insert(_user);
            createStatus = (MembershipCreateStatus) Enum.Parse(typeof(MembershipCreateStatus), status.ToString());
            if (createStatus != MembershipCreateStatus.Success)
                ErrorCodeToString(createStatus);

            return createStatus;
        }

        #endregion

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator. " + Environment.NewLine +
                        @"Refer to the Exception Log File ..\Log\Exception.log";
            }
        }
        #endregion

    }
}
