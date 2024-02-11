<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="_46612r_MS.Pages.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table{
            background-color:white;
        }
    </style>
    <asp:GridView OnRowDataBound="users_RowDataBound" OnSelectedIndexChanged="users_SelectedIndexChanged" AutoGenerateColumns="false" ID="users" runat="server">
        <Columns>
            <asp:BoundField DataField="IDUser" HeaderText="ID"/>
             <asp:ImageField DataAlternateTextField="Photo" DataImageUrlField="Photo" DataImageUrlFormatString="{0}" /> 
            <asp:BoundField DataField="Username" HeaderText="UserName"/>
            <asp:BoundField DataField="Email" HeaderText="Email"/>
            <asp:BoundField DataField="Role" HeaderText="Role"/>
        </Columns>
    </asp:GridView>
</asp:Content>
