<%@ Page Title="MainPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="_46612r_MS.Pages.MainPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <asp:FileUpload ID="img_upload" runat="server" />
    <asp:Button OnClick="choose_photo_btn_Click" Text="Okee" runat="server" />
    <asp:Image ID="my_img" ImageUrl="imageurl" runat="server" />
    <asp:Panel CssClass="panel" ID="myPanel" runat="server"></asp:Panel>
    <asp:Button OnClick="AddTextBox" Text="text" runat="server" />
</asp:Content>
