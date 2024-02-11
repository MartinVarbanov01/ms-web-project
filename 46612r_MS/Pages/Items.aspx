<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="_46612r_MS.Pages.Items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .new {
            text-align: left;
            width: fit-content;
            margin: 0px auto;
        }

        .center {
            text-align: center;
            width: fit-content;
            margin: 20px auto;
        }

        .old {
            float: left;
        }

        .kinda {
            overflow: hidden;
            padding: 0 20px 0 20px;
        }

        .borderRadius {
            border-radius: 10px;
            height: 40px;
        }

        .buttons {
            background-color: orange;
            width: 190px;
            transition: 0.3s;
        }

            .buttons:hover {
                background-color: #ffd280;
            }

        .addbtn {
            margin-top: 10px;
        }
    </style>
    <asp:Panel CssClass="new" runat="server">
        <asp:Label Text="ADD NEW PRODUCT" runat="server" />
        <hr />
        <asp:Panel CssClass="new" runat="server">
            <asp:Panel CssClass="old" runat="server">
                <asp:Label Text="Product Name:" runat="server" /><p></p>
                <asp:TextBox CssClass="borderRadius" ID="prodName" runat="server" /><p></p>

                <asp:Label Text="Product Description:" runat="server" /><p></p>
                <asp:TextBox CssClass="borderRadius" ID="prodDesc" runat="server" /><p></p>
            </asp:Panel>
            <asp:Panel CssClass="kinda" runat="server">
                <asp:Label Text="Upload an Image:" runat="server" /><p></p>
                <asp:FileUpload accept=".png, .jpg,.jpeg" CssClass="borderRadius" ID="prodPic" runat="server" /><p></p>
                <asp:Label Text="Price:" runat="server" /><p></p>
                <asp:TextBox CssClass="borderRadius" ID="prodPrice" runat="server" />
            </asp:Panel>
            <p></p>
        </asp:Panel>
        <asp:Button CssClass="buttons borderRadius addbtn" OnClick="addProduct_btn_Click" ID="addProduct_btn" Text="Add Product" runat="server" /><p></p>
        <hr />
    </asp:Panel>
    <asp:Panel ID="myPanel" runat="server"></asp:Panel>
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
