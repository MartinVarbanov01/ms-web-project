<%@ Page Title="MainPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="_46612r_MS.Pages.MainPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="myPanel" runat="server"></asp:Panel>
    <asp:Label Visible="false" ID="noItems_lbl" Text="<h1>No Items Match!</h1>" runat="server" />
    <script>
        var img = document.getElementsByClassName("imageProd");
        for (let i = 0; i < img.length; i++) {
            Resize(img[i]);
        }
        function Resize(imgSize) {
            var imgRation = imgSize.height / imgSize.width;
            if (imgSize.width > imgSize.height) {
                imgSize.style.width = "200px";
                imgSize.style.height = (200 * imgRation).toString() + "px";
            }
            else {
                imgSize.style.height = "200px";
                imgSize.style.width = (200 / imgRation).toString() + "px";
            }
        }
        function productClicked(prodID) {
            IDProd = prodID.replace('MainContent_', '');
            window.location.href = "ProductPage?prodID=" + IDProd;
        }
    </script>
</asp:Content>
