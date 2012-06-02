<%@ Page Title="" Language="C#" Theme="Theme1" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieScheduleUpdate.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Schedule.MovieScheduleUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 18px;
        }
        .style4
        {
            width: 27px;
            height: 45px;
        }
        .style5
        {
            width: 141px;
        }
        .style6
        {
        width: 628px;
    }
        .style7
        {
            width: 628px;
            height: 41px;
        }
        .style8
        {
            height: 41px;
        }
        .style9
        {
            width: 141px;
            height: 41px;
        }
        .style10
        {
            width: 628px;
            height: 43px;
        }
        .style11
        {
            height: 28px;
        }
        .style12
        {
            width: 141px;
            height: 43px;
        }
        .style13
        {
            height: 43px;
        }
        .style15
        {
            width: 189px;
            height: 31px;
        }
        .style16
        {
            width: 628px;
            height: 45px;
        }
        .style17
        {
            width: 141px;
            height: 45px;
        }
    .style18
    {
        width: 189px;
    }
    .style19
    {
        width: 189px;
        height: 45px;
    }
    .style20
    {
        height: 41px;
        width: 189px;
    }
    .style21
    {
        height: 43px;
        width: 189px;
    }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <span class="failureNotification">
    <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</span>
<asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
        ValidationGroup="RegisterUserValidationGroup"/>
    <div class="accountInfo">
    <fieldset class="register">
        <legend>Movie Schedule -> Add</legend>
    <table class="style1">
        <tr>
            <td class="style6">
                <asp:Label ID="lblMovName" runat="server" Text="Movie Name" Font-Bold="True"></asp:Label>
            </td>
            <td class="style18">
                <asp:DropDownList ID="ComboMovName" runat="server" Width="300px" 
                    DataSourceID="odsMovName" DataTextField="MovieName" DataValueField="ID"
                    >
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsMovName" runat="server" SelectMethod="FindAll" 
                    TypeName="MovieBooking.BLL.Entities.MovieRepository"></asp:ObjectDataSource>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="LblTheatreName" runat="server" Text="Theatre Name" 
                    Font-Bold="True"></asp:Label>
            </td>
            <td class="style18">
                <asp:DropDownList ID="ComboTheatreName" runat="server" Width="300px" 
                    DataSourceID="odsTheatreName" DataTextField="Name" DataValueField="ID"
                   >
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsTheatreName" runat="server" SelectMethod="FindAll" 
                    TypeName="MovieBooking.BLL.Entities.TheatreRepository">
                </asp:ObjectDataSource>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="LblHallNAme" runat="server" Text="Hall Name" Font-Bold="True"></asp:Label>
            </td>
            <td class="style18">
                <asp:DropDownList ID="ComboHallName" runat="server" Width="200px" 
                    DataSourceID="odsHallName" DataTextField="HallName" DataValueField="ID"
                    >
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsHallName" runat="server" 
                    SelectMethod="FindByTheatreId" 
                    TypeName="MovieBooking.BLL.Entities.HallRepository">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ComboTheatreName" DefaultValue="Select.." 
                            Name="theatreId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style6" >
                <asp:Label ID="LblSchDate" runat="server" Text="Schedule Date" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        <td class="style18">
                <asp:TextBox ID="TxtSchDate" runat="server" Width="97px"></asp:TextBox>
               <asp:ImageButton ID="ImageButton3" runat="server" Height="22px" 
                    ImageUrl="~/Images/calendar.png" onclick="ImageButton3_Click" />
                <asp:Calendar ID="Calendar3" runat="server" 
                    onselectionchanged="Calendar3_SelectionChanged" Visible="False" 
                    Width="216px">
                </asp:Calendar>
            </td>
        <td> &nbsp;</td>
        <td> &nbsp;</td>
        </tr>
        <tr>
            <td class="style16">
                </td>
            <td class="style19">
                <asp:Button ID="BtnRetrieve" runat="server" onclick="BtnRetrieve_Click" 
                    Text="Retrieve" Width="71px" />
                </td>
            <td class="style17">
                </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="style6">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td class="style18">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style6">
            <asp:Label ID="LblTimeSlot" runat="server" Text="Show Time" Font-Bold="True"></asp:Label>
        </td>
        <td class="style15">
            <asp:DropDownList ID="Combotime1" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
                <asp:ListItem Value="Select.."></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:DropDownList ID="Combotime2" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
                <asp:ListItem Value="Select.."></asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="Combotime3" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
                <asp:ListItem Value="Select.."></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:DropDownList ID="Combotime4" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
                <asp:ListItem Value="Select.."></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;</td>
        <td class="style11">
        </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="LblPrice" runat="server" Text="Price" Font-Bold="True"></asp:Label>
            </td>
            <td class="style20">
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
            <td class="style9">
                </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="LblActive" runat="server" Text="Active" Font-Bold="True"></asp:Label>
            </td>
            <td class="style21">
                <asp:DropDownList ID="ComboActive" runat="server">
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                    <asp:ListItem Value="Select.."></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style12">
                </td>
            <td class="style13">
                </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style18">
                <asp:Button ID="Btnupdate" runat="server" Text="Update" 
                    onclick="Btnupdate_Click" />
                <asp:Button ID="Btndelete" runat="server" Text="Delete" 
                    onclick="Btndelete_Click" />
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>    
    </fieldset>
</div>

</asp:Content>
