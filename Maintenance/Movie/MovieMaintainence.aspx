﻿<%@ Page Title="" Language="C#" Theme="Theme1" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MovieMaintainence.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Movie.MovieMaintainence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 341px;
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
            width: 341px;
            height: 26px;
        }
        .style6
        {
            height: 26px;
        }
        .style7
        {
            width: 174px;
            height: 69px;
        }
        .style8
        {
            width: 341px;
            height: 69px;
        }
        .style9
        {
            height: 69px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Movie Maintenance -> Add</legend><span class="failureNotification">
                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <span class="failureNotification">
                                <asp:Label ID="lblMovName" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Style="text-align: center" Text="Movie Name"></asp:Label>
                            </span>
                        </td>
                        <td class="style2">
                            <span class="failureNotification">
                                <asp:TextBox ID="TxtMovName" runat="server"></asp:TextBox>
                            </span>
                        </td>
                        <td>
                            <span class="failureNotification">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtMovName"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <span class="failureNotification">
                                <asp:Label ID="lblLanguage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Language"></asp:Label>
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <span class="failureNotification">
                                <asp:Label ID="lblCast" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Cast"></asp:Label>
                            </span>
                        </td>
                        <td class="style2">
                            <span class="failureNotification">
                                <asp:DropDownList ID="CastCombo2" runat="server">
                                    <asp:ListItem>Director</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtCast1" runat="server" Style="margin-left: 38px"></asp:TextBox>
                            </span>
                        </td>
                        <td>
                            <span class="failureNotification">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCast1"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style2">
                            <span class="failureNotification">
                                <asp:DropDownList ID="CastCombo1" runat="server">
                                    <asp:ListItem>Stars</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtCast2" runat="server" Style="margin-left: 51px"></asp:TextBox>
                            </span>
                        </td>
                        <td>
                            <span class="failureNotification">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCast2"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style2">
                            <span class="failureNotification">
                                <asp:DropDownList ID="CastCombo3" runat="server">
                                    <asp:ListItem>Screenplay</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtCast3" runat="server" Style="margin-left: 16px"></asp:TextBox>
                            </span>
                        </td>
                        <td>
                            <span class="failureNotification">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCast3"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <span class="failureNotification">
                                <asp:Label ID="lblGenre" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Genre"></asp:Label>
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <span class="failureNotification">
                                <asp:Label ID="lblMovDesc" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Movie Description"></asp:Label>
                            </span>
                        </td>
                        <td class="style2">
                            <span class="failureNotification">
                                <asp:TextBox ID="txtmovDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <span class="failureNotification">
                                <asp:Label ID="lblRating" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Rating"></asp:Label>
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <span class="failureNotification">
                                <asp:Label ID="lblDuration" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Duration "></asp:Label>
                            </span>
                        </td>
                        <td class="style2">
                            <span class="failureNotification">
                                <asp:TextBox ID="txtDuration" runat="server"></asp:TextBox>
                                <asp:Label ID="lblminutes" runat="server" Font-Size="Small" Text="Minutes"></asp:Label>
                            </span>
                        </td>
                        <td>
                            <span class="failureNotification">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDuration"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <span class="failureNotification">
                                <asp:Label ID="lblActive" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Active"></asp:Label>
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
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td class="style8">
                            <asp:Button ID="BtnCreate" runat="server" Text="Create" OnClick="BtnCreate_Click" />
                        </td>
                        <td class="style9">
                            &nbsp;
                        </td>
                        <td class="style9">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <asp:GridView ID="gvMovie" runat="server" AutoGenerateColumns="False" 
                            Width="99%" CellPadding="4" ForeColor="#333333" GridLines="None">

                            <AlternatingRowStyle BackColor="White" />

                            <Columns>
                                <asp:BoundField DataField="MovieName" HeaderText="Movie" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="CastDescription" HeaderText="Casts" />
                                <asp:BoundField DataField="genre" HeaderText="Genre" />
                                <asp:BoundField DataField="RunningDuration" HeaderText="Duration" />
                            </Columns>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </tr>
                </table>
            </span>
        </fieldset>
    </div>
</asp:Content>
