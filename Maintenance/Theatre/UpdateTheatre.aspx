<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateTheatre.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Theatre.UpdateTheatre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>
Theatre Maintenance
</h2>

<span class="failureNotification">
    <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</span>
<asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
        ValidationGroup="RegisterUserValidationGroup"/>

<div class="accountInfo">
    <fieldset class="register">
        <legend>Theatre Maintenance -> Update</legend>
        <p>
        <asp:Label ID="TheatreNameLabel" runat="server" AssociatedControlID="cmbTheatreName">Theatre Name:</asp:Label>
        <asp:DropDownList ID="cmbTheatreName" CssClass="title" Width="400px" runat="server" 
                 DataTextField="Name" DataValueField="ID" 
                onselectedindexchanged="cmbTheatreName_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
       
            <br />
       <%-- <asp:RequiredFieldValidator ID="TheatreNameRequired" runat="server" ControlToValidate="" 
                CssClass="failureNotification" ErrorMessage="Theatre Name is required." ToolTip="Theatre Name is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>--%>
        </p>
        <p>
        <asp:Label ID="TheatreAddressLabel" runat="server" AssociatedControlID="TheatreAddress">Address:</asp:Label>
        <asp:TextBox ID="TheatreAddress" runat="server" CssClass="textEntry" Width="400px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="TheatreAddressRequired" runat="server" ControlToValidate="TheatreAddress" 
                CssClass="failureNotification" ErrorMessage="Theatre Name is required." ToolTip="Theatre Name is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
        <asp:Label ID="TheatrePostalCodeLabel" runat="server" AssociatedControlID="TheatrePostalCode">Postal Code:</asp:Label>
        <asp:TextBox ID="TheatrePostalCode" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TheatrePostalCode" 
                CssClass="failureNotification" ErrorMessage="Theatre Postal Code is required." ToolTip="Theatre Postal Code is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
        <asp:Label ID="TheatrePhoneNoLabel" runat="server" AssociatedControlID="TheatrePhoneNo">Phone No:</asp:Label>
        <asp:TextBox ID="TheatrePhoneNo" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TheatrePhoneNo" 
                CssClass="failureNotification" ErrorMessage="Theatre Phone No. is required." ToolTip="Theatre Phone No. is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
        <asp:Label ID="TheatreFaxNoLabel" runat="server" AssociatedControlID="TheatreFaxNo">Fax No.:</asp:Label>
        <asp:TextBox ID="TheatreFaxNo" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TheatreFaxNo" 
                CssClass="failureNotification" ErrorMessage="Theatre Fax No. is required." ToolTip="Theatre Fax No. is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
        <asp:Label ID="TheatreEmailLabel" runat="server" AssociatedControlID="TheatreEmail">Email:</asp:Label>
        <asp:TextBox ID="TheatreEmail" runat="server" CssClass="textEntry" Width="396px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TheatreEmail" 
                CssClass="failureNotification" ErrorMessage="Theatre Email is required." ToolTip="Theatre Email is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
        <asp:Label ID="TheatreWebSiteLabel" runat="server" AssociatedControlID="TheatreWebSiteAddress">Web Site:</asp:Label>
        <asp:TextBox ID="TheatreWebSiteAddress" runat="server" CssClass="textEntry" 
                Width="394px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TheatreWebSiteAddress" 
                CssClass="failureNotification" ErrorMessage="Theatre WebSite is required." ToolTip="Theatre WebSite is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>
        </p>

        <p>
            <asp:Button ID="btnAdd" runat="server" Text="Update" 
                CausesValidation="true" ValidationGroup="TheatreValidationGroup" 
                onclick="btnAdd_Click" /> &nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                CausesValidation="true" ValidationGroup="TheatreValidationGroup" onclick="btnDelete_Click" 
               />
        </p>
        <br />
    </fieldset>
</div>
</asp:Content>
