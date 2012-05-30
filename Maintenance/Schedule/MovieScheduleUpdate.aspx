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
        }
        .style5
        {
            width: 141px;
        }
        .style6
        {
            width: 142px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="accountInfo">
    <fieldset class="register">
        <legend>Movie Schedule -> Add</legend>
    <table class="style1">
        <tr>
            <td class="style6">
                <asp:Label ID="lblMovName" runat="server" Text="Movie Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ComboMovName" runat="server" 
                    DataSourceID="odsMovieName" DataTextField="MovieName" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsMovieName" runat="server"></asp:ObjectDataSource>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="LblTheatreName" runat="server" Text="Theatre Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ComboTheatreName" runat="server" 
                    DataSourceID="odsTheatreName" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsTheatreName" runat="server"></asp:ObjectDataSource>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="LblHallNAme" runat="server" Text="Hall Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ComboHallName" runat="server" 
                    DataSourceID="odsHallName" DataTextField="HallName" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsHallName" runat="server"></asp:ObjectDataSource>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                <asp:Button ID="BtnRetrieve" runat="server" onclick="BtnRetrieve_Click" 
                    Text="Retrieve" Width="71px" />
                </td>
            <td class="style5">
                </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblFromdate" runat="server" Text="From Date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxtFromdate" runat="server" Width="97px"></asp:TextBox>
               <asp:ImageButton ID="ImageButton2" runat="server" Height="22px" 
                    ImageUrl="~/images/calendar.png" onclick="ImageButton1_Click" />
                <asp:Calendar ID="Calendar1" runat="server" 
                    onselectionchanged="Calendar1_SelectionChanged" Visible="False">
                </asp:Calendar>
            </td>
            <td>
                <asp:Label ID="LblTodate" runat="server" Text="To Date"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxtTodate" runat="server" style="margin-left: 13px" 
                    Width="96px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="22px" 
                    ImageUrl="~/images/calendar.png" onclick="ImageButton2_Click" />
                <asp:Calendar ID="Calendar2" runat="server" 
                    onselectionchanged="Calendar2_SelectionChanged" Visible="False">
                </asp:Calendar>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style13">
            <asp:Label ID="LblTimeSlot" runat="server" Text="Show Time"></asp:Label>
        </td>
        <td class="style15">
            <asp:DropDownList ID="Combotime1" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:DropDownList ID="Combotime2" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="Combotime3" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:DropDownList ID="Combotime4" runat="server">
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        <td class="style11">
        </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="LblActive" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ComboActive" runat="server">
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
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
