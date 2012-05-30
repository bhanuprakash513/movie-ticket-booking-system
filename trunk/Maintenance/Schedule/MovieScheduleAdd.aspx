﻿<%@ Page Title="" Language="C#" Theme="Theme1" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieScheduleAdd.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Schedule.MovieScheduleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            height: 21px;
        }
        .style11
        {
            width: 264px;
        }
        .style12
        {
            height: 21px;
            width: 264px;
        }
        .style13
        {
            width: 116px;
        }
        .style14
        {
            height: 21px;
            width: 116px;
        }
        .style15
        {
            width: 283px;
        }
        .style16
        {
            height: 21px;
            width: 283px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="accountInfo">
    <fieldset class="register">
        <legend>Movie Schedule -> Add</legend>
    <table class="style1">
        <tr>
            <td class="style13">
                <asp:Label ID="lblMovName" runat="server" Text="Movie Name"></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="ComboMovName" runat="server" 
                    DataSourceID="ObsMovie" DataTextField="MovieName" 
                    DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObsMovie" runat="server" SelectMethod="FindAll" 
                    TypeName="MovieBooking.BLL.Entities.MovieRepository"></asp:ObjectDataSource>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="LblTheatreName" runat="server" Text="Theatre Name"></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="ComboTheatreName" runat="server" 
                    DataSourceID="obsTheatre" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="obsTheatre" runat="server" SelectMethod="FindAll" 
                    TypeName="MovieBooking.BLL.Entities.TheatreRepository">
                </asp:ObjectDataSource>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="LblHallNAme" runat="server" Text="Hall Name"></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="CombohallName" runat="server" 
                    >
                </asp:DropDownList>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                </td>
            <td class="style12">
                </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
             <td class="style13">
                <asp:Label ID="LblSchedule" runat="server" Text="Schedule"></asp:Label>
             </td>
            <td class="style15">
                <asp:Label ID="lblFromdate" runat="server" Text="From Date"></asp:Label>
            &nbsp;<asp:TextBox ID="TxtFromdate" runat="server" Width="97px"></asp:TextBox>
               <asp:ImageButton ID="ImageButton2" runat="server" Height="22px" 
                    ImageUrl="images/calendar.png" onclick="ImageButton1_Click" />
                <asp:Calendar ID="Calendar1" runat="server" 
                    onselectionchanged="Calendar1_SelectionChanged" Visible="False">
                </asp:Calendar>
            </td>
            <td class="style11">
                <asp:Label ID="LblTodate" runat="server" Text="To Date"></asp:Label>
                <asp:TextBox ID="TxtTodate" runat="server" style="margin-left: 13px" 
                    Width="96px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" 
                    ImageUrl="images/calendar.png" onclick="ImageButton2_Click" Width="16px" />
                <asp:Calendar ID="Calendar2" runat="server" 
                    onselectionchanged="Calendar2_SelectionChanged" Visible="False" 
                    style="margin-right: 11px" Width="232px">
                </asp:Calendar>
            </td>
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
            <td class="style13">
                <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
            </td>
            <td class="style15">
                <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="LblActive" runat="server" Text="Active"></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="ComboActive" runat="server">
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td class="style15">
                <asp:Button ID="Btncreate" runat="server" Text="Create" 
                    onclick="Btncreate_Click" />
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>    
    </fieldset>
</div>

</asp:Content>
