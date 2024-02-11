<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="_46612r_MS.Pages.ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        input {
            max-width: none;
        }

        .mainImage {
            border-radius: 15px;
            border: solid 2px;
        }

        .images {
            border: solid 2px;
            border-radius: 15px;
            margin: 5px 3px 0px 2px;
            transition: 0.3s;
        }

            .images:hover {
                opacity: 0.7;
                background-color: orange;
            }


        .imagesPanel {
            width: fit-content;
            height: fit-content;
        }

        .mainPanel {
            border: solid 2px;
            border-radius: 15px;
            width: 100%;
            position: relative;
            display: flex;
        }

        .prodGallery {
            margin: 10px 0px 5px 10px;
        }

        .infoBorder {
            border: solid 2px;
            border-radius: 15px;
            width: 100%;
            margin: 10px;
        }

        .info {
            margin: 5px;
            height: 100%;
        }

        .textBox {
            border: none;
            outline: none;
        }

        .textArea {
            max-width: none;
            width: 100%;
            height: 85%;
            resize: none;
            border: none;
            margin-top: 5px;
            vertical-align: top;
            border-radius: 10px;
        }

        .title {
            font-weight: bold;
            font-size: 28px;
        }

        .price_lbl {
            text-align: right;
            align-self: flex-end;
            font-weight: bold;
            font-family: fantasy;
            min-width: 100px;
            border: solid 2px;
            border-radius: 15px;
        }

        .pricePanel {
            position: absolute;
            bottom: 4px;
            right: 20px;
        }

        .fill-space {
            width: 100%;
            height: 100%;
        }

        .borderRadius {
            border: solid 3px black;
            border-radius: 10px;
            height: 40px;
        }

        .buttons {
            margin-top: 10px;
            background-color: red;
            color: white;
            font-weight: bold;
            font-size: 20px;
            width: fit-content;
            transition: 0.3s;
        }

            .buttons:hover {
                background-color: #000000;
                border-color: red;
            }

        .suspended {
            color:red;
        }
    </style>
    <asp:Label ID="suspendedProd_lbl" CssClass="suspended" Visible="false" Text="<h1>Product Is Suspended</h1>" runat="server" />
    <asp:Panel CssClass="mainPanel" ID="mainPanel" runat="server">
        <asp:Panel CssClass="prodGallery" runat="server">
            <asp:ImageButton CssClass="mainImage" OnClick="prodImg1_Click" ID="prodImg1" ImageUrl="/Images/default-product.png" runat="server" />
            <asp:Panel CssClass="imagesPanel" runat="server">
                <asp:ImageButton CssClass="images" OnClick="prodImg1_Click" ID="prodImg2" ImageUrl="/Images/default-product.png" runat="server" /><asp:ImageButton CssClass="images" OnClick="prodImg1_Click" ID="prodImg3" ImageUrl="/Images/default-product.png" runat="server" /><asp:ImageButton CssClass="images" OnClick="prodImg1_Click" ID="prodImg4" ImageUrl="/Images/default-product.png" runat="server" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel CssClass="infoBorder" runat="server">
            <asp:Panel CssClass="info" runat="server">
                <asp:Panel CssClass="pricePanel" runat="server">
                    <asp:TextBox ID="prodPrice" CssClass="textBox price_lbl" ReadOnly="true" runat="server" /><p></p>
                </asp:Panel>
                <asp:Panel CssClass="fill-space" runat="server">
                    <asp:TextBox ID="prodName" CssClass="textBox title" ReadOnly="true" runat="server" Text="<h1>asd<h1/>" /><p></p>
                    <asp:TextBox ID="prodDesc" CssClass="textBox textArea" Wrap="true" TextMode="MultiLine" ReadOnly="true" runat="server" /><p></p>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
    <asp:Button OnClick="suspdenProd_btn_Click" Visible="false" CssClass="borderRadius buttons" ID="suspdenProd_btn" Text="Suspend Product" runat="server" />
    <asp:Button OnClick="deleteProd_btn_Click" Visible="false" CssClass="borderRadius buttons" ID="deleteProd_btn" Text="Delete Product" runat="server" />
    <asp:Label ID="prodNotFound_lbl" Visible="false" Text="<h1>Error product not found!</h1>" runat="server" />
    <script>
        //#region imagesResizing
        function ResizeImages() {
            var mainImg = document.getElementsByClassName("mainImage");
            for (let i = 0; i < mainImg.length; i++) {
                ResizeMainImg(mainImg[i]);
            }
            var img = document.getElementsByClassName("images");
            for (let i = 0; i < img.length; i++) {
                Resize(img[i]);
            }
        }
        function ResizeMainImg(imgSize) {
            var size = 465;
            var imgRation = imgSize.height / imgSize.width;
            imgSize.width = size;
            imgSize.height = size * imgRation;
        }
        function Resize(imgSize) {
            var size = 150;
            var imgRation = imgSize.height / imgSize.width;
            imgSize.width = size;
            imgSize.height = size * imgRation;
        }
        ResizeImages();
        //#endregion
        price_tb = document.getElementById("MainContent_prodPrice");
        price_tb.style.width = (price_tb.value.length - 2) + 'ch';
    </script>
</asp:Content>
