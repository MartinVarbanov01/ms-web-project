<%@ Page Title="MainPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="_46612r_MS.Pages.MainPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .panel{
        }
    </style>
    <asp:Panel CssClass="panel" ID="myPanel" runat="server"></asp:Panel>
    <script>
        function productClicked(prodID) {
            IDProd = prodID.replace('MainContent_', '');
            alert(IDProd);
        }
    </script>
</asp:Content>
