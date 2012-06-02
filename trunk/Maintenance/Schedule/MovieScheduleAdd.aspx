<%@ Page Title="" Language="C#" Theme="Theme1" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieScheduleAdd.aspx.cs" Inherits="MovieBooking.UI.Maintenance.Schedule.MovieScheduleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style11
        {
            width: 264px;
        }
        .style13
        {
            width: 159px;
        }
        .style15
        {
            width: 312px;
        }
        .style17
        {
            width: 159px;
            height: 41px;
        }
        .style18
        {
            width: 312px;
            height: 41px;
        }
        .style19
        {
            width: 264px;
            height: 41px;
        }
        .style20
        {
            height: 41px;
        }
        .style21
        {
            width: 159px;
            height: 40px;
        }
        .style22
        {
            width: 312px;
            height: 40px;
        }
        .style23
        {
            width: 264px;
            height: 40px;
        }
        .style24
        {
            height: 40px;
        }
        .style25
        {
            width: 159px;
            height: 179px;
        }
        .style26
        {
            width: 312px;
            height: 179px;
        }
        .style27
        {
            width: 264px;
            height: 179px;
        }
        .style28
        {
            height: 179px;
        }
        .style29
        {
            width: 159px;
            height: 5px;
        }
        .style30
        {
            width: 312px;
            height: 5px;
        }
        .style31
        {
            width: 264px;
            height: 5px;
        }
        .style32
        {
            height: 5px;
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
            <td class="style13">
                <asp:Label ID="lblMovName" runat="server" Text="Movie Name" Font-Bold="True"></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="ComboMovName" runat="server" Width="300px" 
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
                <asp:Label ID="LblTheatreName" runat="server" Text="Theatre Name" 
                    Font-Bold="True"></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="ComboTheatreName" runat="server" Width="300px" 
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
                <asp:Label ID="LblHallNAme" runat="server" Text="Hall Name" Font-Bold="True"></asp:Label>
            </td>
            <td class="style15">
                <asp:DropDownList ID="CombohallName" runat="server" DataSourceID="Ods_Hall" Width="200px"
                    DataTextField="HallName" DataValueField="ID" 
                    >
                </asp:DropDownList>
                <asp:ObjectDataSource ID="Ods_Hall" runat="server" 
                    SelectMethod="FindByTheatreId" 
                    TypeName="MovieBooking.BLL.Entities.HallRepository">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ComboTheatreName" DefaultValue="Select..." 
                            Name="theatreId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
             <td class="style25">
                <asp:Label ID="LblSchedule" runat="server" Text="Schedule" Font-Bold="True"></asp:Label>
             </td>
            <td class="style26">
                <asp:Label ID="lblFromdate" runat="server" Text="From Date"></asp:Label>
            &nbsp;<asp:TextBox ID="TxtFromdate" runat="server" Width="104px"></asp:TextBox>
               <asp:ImageButton ID="ImageButton2" runat="server" Height="22px" 
                    ImageUrl="Images/calendar.gif" onclick="ImageButton1_Click" />
                <asp:Calendar ID="Calendar1" runat="server" 
                    onselectionchanged="Calendar1_SelectionChanged" Visible="False">
                </asp:Calendar>
            </td>
            <td class="style27">
                <asp:Label ID="LblTodate" runat="server" Text="To Date"></asp:Label>
                <asp:TextBox ID="TxtTodate" runat="server" style="margin-left: 13px" 
                    Width="102px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" 
                    ImageUrl="Images/calendar.gif" onclick="ImageButton2_Click" Width="16px" />
                <asp:Calendar ID="Calendar2" runat="server" 
                    onselectionchanged="Calendar2_SelectionChanged" Visible="False" 
                    style="margin-right: 11px; margin-left: 6px;" Width="232px">
                </asp:Calendar>
            </td>
            <td class="style28">
                </td>
       
        </tr>
        <tr>
        <td class="style13">
            <asp:Label ID="LblTimeSlot" runat="server" Text="Show Time" Font-Bold="True"></asp:Label>
        </td>
        <td class="style15">

            <asp:DropDownList ID="Combotime1" runat="server">
                <asp:ListItem Value="0 ">Select..</asp:ListItem>
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:DropDownList ID="Combotime2" runat="server">
            <asp:ListItem Value="0 ">Select..</asp:ListItem>
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="Combotime3" runat="server">
            <asp:ListItem Value="0 ">Select..</asp:ListItem>
                <asp:ListItem Value="10 ">10 am</asp:ListItem>
                <asp:ListItem Value="1 ">1 pm</asp:ListItem>
                <asp:ListItem Value="4 ">4 pm</asp:ListItem>
                <asp:ListItem Value="7 ">7 pm</asp:ListItem>
                <asp:ListItem Value="10 ">10 pm</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:DropDownList ID="Combotime4" runat="server">
                <asp:ListItem Value="0 ">Select..</asp:ListItem>
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
            <td class="style17">
                <asp:Label ID="LblPrice" runat="server" Text="Price" Font-Bold="True"></asp:Label>
            </td>
            <td class="style18">
                <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtPrice" ErrorMessage="RequiredFieldValidator" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td class="style19">
                </td>
            <td class="style20">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style21">
                <asp:Label ID="LblActive" runat="server" Text="Active" Font-Bold="True"></asp:Label>
            </td>
            <td class="style22">
                <asp:DropDownList ID="ComboActive" runat="server">
                    <asp:ListItem Value="3 ">Select..</asp:ListItem>
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style23">
                </td>
            <td class="style24">
                </td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td class="style15">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
