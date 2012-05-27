<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieUpdate.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Movie.MovieUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        width: 291px;
    }
        .style3
        {
            width: 174px;
        }
        .style4
        {
            width: 174px;
            height: 26px;
        }
        .style5
        {
            width: 291px;
            height: 26px;
        }
        .style6
        {
            height: 26px;
        }
        .style7
        {
            width: 174px;
            height: 85px;
        }
        .style8
        {
            width: 291px;
            height: 85px;
        }
        .style9
        {
            height: 85px;
        }
        .style10
        {
            width: 174px;
            height: 29px;
        }
        .style11
        {
            width: 291px;
            height: 29px;
        }
        .style12
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="accountInfo">
    <fieldset class="register">
        <legend>Movie Maintenance -> Update</legend>

<span class="failureNotification">
    <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    <table class="style1">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">

<span class="failureNotification">
                <asp:Label ID="lblMovName" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" style="text-align: center" Text="Movie Name"></asp:Label>
</span>
            </td>
            <td class="style8">

                <asp:DropDownList ID="MovNameCombo" runat="server" 
                    DataSourceID="MovieNameEntity" DataTextField="MovieName" DataValueField="ID">
                </asp:DropDownList>
                <asp:EntityDataSource ID="MovieNameEntity" runat="server" 
                    ConnectionString="name=MovieBookingEntitiesContext" 
                    DefaultContainerName="MovieBookingEntitiesContext" EnableFlattening="False" 
                    EntitySetName="mb_Movie" EntityTypeFilter="mb_Movie" 
                    Select="it.[ID], it.[MovieName]">
                </asp:EntityDataSource>
            </td>
            <td class="style9">

<span class="failureNotification">
                <asp:Button ID="BtnRetrieve" runat="server" onclick="BtnRetrieve_Click" 
                    Text="Retrieve" />
</span>





            </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td class="style3">

<span class="failureNotification">
                <asp:Label ID="lblLanguage" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="Language"></asp:Label>
</span>
            </td>
            <td class="style2">

<span class="failureNotification">
                <asp:DropDownList ID="LanguageCombo" runat="server">
                    <asp:ListItem Value="English"></asp:ListItem>
                    <asp:ListItem Value="Tamil"></asp:ListItem>
                    <asp:ListItem Value="Chinese"></asp:ListItem>
                    <asp:ListItem Value="Malay"></asp:ListItem>
                </asp:DropDownList>
</span>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">

<span class="failureNotification">
                <asp:Label ID="lblCast" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="Cast"></asp:Label>
</span>
            </td>
            <td class="style2">

<span class="failureNotification">
                <asp:DropDownList ID="CastCombo2" runat="server">
                    <asp:ListItem>Director</asp:ListItem>
                    <asp:ListItem>Stars</asp:ListItem>
                    <asp:ListItem>Screenplay</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCast1" runat="server" style="margin-left: 29px"></asp:TextBox>
</span>
            </td>
            <td>

                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                </td>
            <td class="style11">

<span class="failureNotification">
                <asp:DropDownList ID="CastCombo1" runat="server">
                    <asp:ListItem>Director</asp:ListItem>
                    <asp:ListItem>Stars</asp:ListItem>
                    <asp:ListItem>Screenplay</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCast2" runat="server" style="margin-left: 29px"></asp:TextBox>
</span>
            </td>
            <td class="style12">

                &nbsp;</td>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">

<span class="failureNotification">
                <asp:DropDownList ID="CastCombo3" runat="server">
                    <asp:ListItem>Director</asp:ListItem>
                    <asp:ListItem Value="Stars"></asp:ListItem>
                    <asp:ListItem>Screenplay</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCast3" runat="server" style="margin-left: 29px"></asp:TextBox>
</span>
            </td>
            <td>

                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">

<span class="failureNotification">
                <asp:Label ID="lblGenre" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="Genre"></asp:Label>
</span>
            </td>
            <td class="style2">

<span class="failureNotification">
                <asp:DropDownList ID="GenreCombo" runat="server">
                    <asp:ListItem>Action</asp:ListItem>
                    <asp:ListItem>Thriller</asp:ListItem>
                    <asp:ListItem>Horror</asp:ListItem>
                    <asp:ListItem>Romance</asp:ListItem>
                    <asp:ListItem>Comedy</asp:ListItem>
                    <asp:ListItem>SciFi</asp:ListItem>
                </asp:DropDownList>
</span>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">

<span class="failureNotification">
                <asp:Label ID="lblMovDesc" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="Movie Description"></asp:Label>
</span>
            </td>
            <td class="style2">

<span class="failureNotification">
                <asp:TextBox ID="txtmovDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
</span>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">

<span class="failureNotification">
                <asp:Label ID="lblRating" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="Rating"></asp:Label>
</span>
            </td>
            <td class="style2">

<span class="failureNotification">
                <asp:DropDownList ID="RatingCombo" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <asp:ListItem Value="2"></asp:ListItem>
                    <asp:ListItem Value="3"></asp:ListItem>
                    <asp:ListItem Value="4"></asp:ListItem>
                    <asp:ListItem Value="5"></asp:ListItem>
                    <asp:ListItem Value="6"></asp:ListItem>
                    <asp:ListItem Value="7"></asp:ListItem>
                    <asp:ListItem Value="8"></asp:ListItem>
                    <asp:ListItem Value="9"></asp:ListItem>
                    <asp:ListItem Value="10"></asp:ListItem>
                </asp:DropDownList>
</span>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">

<span class="failureNotification">
                <asp:Label ID="lblDuration" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="Duration "></asp:Label>
</span>
            </td>
            <td class="style2">

<span class="failureNotification">
                <asp:TextBox ID="txtDuration" runat="server"></asp:TextBox>
                <asp:Label ID="lblminutes" runat="server" Font-Size="Small" Text="Minutes"></asp:Label>
</span>
            </td>
            <td>

                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">

<span class="failureNotification">
                <asp:Label ID="lblActive" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="Active"></asp:Label>
</span>
            </td>
            <td class="style5">

<span class="failureNotification">
                <asp:DropDownList ID="ActiveCombo" runat="server">
                    <asp:ListItem Value="True"></asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
</span>
            </td>
            <td class="style6">
            </td>
            <td class="style6">
            </td>
        </tr>
        <tr>
            <td class="style3">

                &nbsp;</td>
            <td class="style2">

                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">

<span class="failureNotification">
                <asp:Button ID="BtnUpdate" runat="server" Text="Update" 
                    onclick="BtnUpdate_Click" />
                <asp:Button ID="BtnDelete" runat="server" Text="Delete" 
                    onclick="BtnDelete_Click" style="margin-left: 31px" />
</span>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</span>



    </fieldset>
</div>


</asp:Content>

