<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieScheduleAdd.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Schedule.MovieScheduleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 258px;
        }
        .style3
        {
            width: 258px;
            height: 21px;
        }
        .style4
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="accountInfo">
    <fieldset class="register">
        <legend>Movie Schedule -> Add</legend>
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="lblMovName" runat="server" Text="Movie Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="MovieNameEntity" DataTextField="MovieName" DataValueField="ID">
                </asp:DropDownList>
                <asp:EntityDataSource ID="MovieNameEntity" runat="server" 
                    ConnectionString="name=MovieBookingEntitiesContext" 
                    DefaultContainerName="MovieBookingEntitiesContext" EnableFlattening="False" 
                    EntitySetName="mb_Movie" Select="it.[ID], it.[MovieName]">
                </asp:EntityDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="LblTheatreName" runat="server" Text="Theatre Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    DataSourceID="TheatreNameEntity" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
                <asp:EntityDataSource ID="TheatreNameEntity" runat="server" 
                    ConnectionString="name=MovieBookingEntitiesContext" 
                    DefaultContainerName="MovieBookingEntitiesContext" EnableFlattening="False" 
                    EntitySetName="mb_Theatre" EntityTypeFilter="mb_Theatre" 
                    Select="it.[ID], it.[Name]">
                </asp:EntityDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="LblHallNAme" runat="server" Text="Hall Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" 
                    DataSourceID="HallNameEntity" DataTextField="HallName" DataValueField="ID">
                </asp:DropDownList>
                <asp:EntityDataSource ID="HallNameEntity" runat="server" 
                    ConnectionString="name=MovieBookingEntitiesContext" 
                    DefaultContainerName="MovieBookingEntitiesContext" EnableFlattening="False" 
                    EntitySetName="mb_Hall" EntityTypeFilter="mb_Hall" 
                    Select="it.[ID], it.[HallName]">
                </asp:EntityDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="LblSchedule" runat="server" Text="Schedule"></asp:Label>
            </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="style2">
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="LblActive" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server">
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>    
    </fieldset>
</div>

</asp:Content>
