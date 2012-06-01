<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateHall.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Hall.UpdateHall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
Hall Maintenance
</h2>

<span class="failureNotification">
    <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</span>
<asp:ValidationSummary ID="HallValidationSummary" runat="server" CssClass="failureNotification" 
        ValidationGroup="HallValidationGroup"/>

<div class="accountInfo">
    <fieldset class="register">
        <legend>Hall Maintenance -> Update</legend>
        <p>
        <asp:Label ID="TheatreNameLabel" runat="server" AssociatedControlID="cmbTheatreName">Theatre Name:</asp:Label>
        <asp:DropDownList ID="cmbTheatreName" CssClass="title" Width="400px" runat="server" 
                 DataTextField="Name" DataValueField="ID"  AutoPostBack="true" 
                onselectedindexchanged="cmbTheatreName_SelectedIndexChanged">
        </asp:DropDownList>
       
            <br />
       <%-- <asp:RequiredFieldValidator ID="TheatreNameRequired" runat="server" ControlToValidate="" 
                CssClass="failureNotification" ErrorMessage="Theatre Name is required." ToolTip="Theatre Name is required." 
                ValidationGroup="TheatreValidationGroup">*</asp:RequiredFieldValidator>--%>
        </p>

        <p>
        <asp:Label ID="HallIDLabel" runat="server" AssociatedControlID="cmbHallName">Select Hall:</asp:Label>
        <asp:DropDownList ID="cmbHallName" CssClass="title" Width="400px" runat="server" 
                AutoPostBack="true" 
                onselectedindexchanged="cmbHallName_SelectedIndexChanged">
        </asp:DropDownList>
        </p>
        <br />
        <p>
        <asp:Label ID="HallNameLabel" runat="server" AssociatedControlID="HallName">Hall Name:</asp:Label>
        <asp:TextBox ID="HallName" runat="server" CssClass="textEntry" Width="400px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="HallNameRequired" runat="server" ControlToValidate="HallName" 
                CssClass="failureNotification" ErrorMessage="Hall Name is required." ToolTip="Hall Name is required." 
                ValidationGroup="HallValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
        <asp:Label ID="TotalSeatsLabel" runat="server" AssociatedControlID="TotalSeats">Total No. of Seats:</asp:Label>
        <asp:TextBox ID="TotalSeats" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="TotalSeatsRequired" runat="server" ControlToValidate="TotalSeats" 
                CssClass="failureNotification" ErrorMessage="Total No. of Seats is required." ToolTip="Total No. of Seats is required." 
                ValidationGroup="HallValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
        <asp:Label ID="HallStatusLabel" runat="server" AssociatedControlID="cmbHallStatus">Hall Status:</asp:Label>
         <asp:DropDownList ID="cmbHallStatus" CssClass="title" Width="400px" runat="server"  AutoPostBack="true">
         <asp:ListItem Text="Active" Value="True"></asp:ListItem>
         <asp:ListItem Text="In Active" Value="False"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="cmbHallStatusRequired" runat="server" ControlToValidate="cmbHallStatus" 
                CssClass="failureNotification" ErrorMessage="Hall Status is required." ToolTip="Hall Status is required." 
                ValidationGroup="HallValidationGroup">*</asp:RequiredFieldValidator>
        </p>
           <br />
            <p>
            <asp:Button ID="btnAdd" runat="server" Text="Update" 
                CausesValidation="true"  ValidationGroup="HallValidationGroup" onclick="btnAdd_Click" 
                 /> &nbsp;&nbsp;
                 </p>
    </fieldset>
</div>
</asp:Content>
