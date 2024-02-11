<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="_46612r_MS.Pages.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #MainContent_error {
            color: red;
            font-weight: bold;
            font-size: 18px;
        }

        .profilePic {
            border: solid 2px;
            border-radius: 1000px !important;
        }

        .new {
            text-align: left;
            width: fit-content;
            margin: 20px auto;
        }

        .newRows {
            text-align: center;
            width: fit-content;
            margin: 20px auto;
        }

        .borderRadius {
            border-radius: 10px;
            height: 40px;
        }

        .buttons {
            background-color: orange;
            width: 120px;
            transition: 0.3s;
        }

            .buttons:hover {
                background-color: #ffd280;
            }

        .red {
            width: fit-content;
            font-weight: bold;
            background-color: red;
            color: white;
            transition:0.3s;
        }

            .red:hover {
                background-color: black;
                border-color: red;
            }

        .black {
            width: fit-content;
            font-weight: bold;
            background-color: black;
            color: white;
            transition:0.3s;
        }

            .black:hover {
                background-color: white;
                color:black;
            }
    </style>
    <asp:Panel CssClass="panel" runat="server">
        <p>
            <br />
        </p>
        <asp:Panel CssClass="newRows" runat="server">
            <asp:Image CssClass="profilePic" ID="profilePic" ImageUrl="imageurl" runat="server" /><p></p>
            <asp:FileUpload Width="100px" Visible="false" ID="profilePic_uploader" runat="server" /><p>
                <br />
            </p>
        </asp:Panel>
        <asp:Panel CssClass="new" runat="server">
            <asp:Label Text="Username" runat="server" /><p></p>
            <asp:TextBox CssClass="borderRadius" ReadOnly="true" ID="profileUsername" runat="server" /><p></p>
            <asp:Label Text="Email" runat="server" /><p></p>
            <asp:TextBox CssClass="borderRadius" ReadOnly="true" ID="profileEmail" runat="server" /><p></p>
            <asp:Label Visible="false" ID="profilePassOld_lbl" Text="Old Password" runat="server" /><p></p>
            <asp:TextBox CssClass="borderRadius" Visible="false" TextMode="Password" ID="profilePassOld" runat="server" /><p></p>
            <asp:Label Visible="false" ID="profilePassNew_lbl" Text="New Password" runat="server" /><p></p>
            <asp:TextBox CssClass="borderRadius" Visible="false" TextMode="Password" ID="profilePassNew" runat="server" /><p></p>
            <asp:Label Visible="false" ID="profilePassNew2_lbl" Text="Confirm New Password" runat="server" /><p></p>
            <asp:TextBox CssClass="borderRadius" Visible="false" TextMode="Password" ID="profilePassNew2" runat="server" /><p></p>
            <asp:Label Visible="false" ID="error" Text="error" runat="server" />
        </asp:Panel>
        <asp:Panel CssClass="new" runat="server">
            <asp:Button CssClass="buttons borderRadius" OnClick="editProfile_Click" ID="editProfile" Text="Edit Profile" runat="server" />
            <asp:Button CssClass="buttons borderRadius" Visible="false" OnClick="saveProfile_Click" ID="saveProfile" Text="Save Changes" runat="server" />
        </asp:Panel>
        <asp:Panel CssClass="new" runat="server">
            <asp:Button CssClass="buttons borderRadius" OnClick="myProd_btn_Click" ID="myProd_btn" Text="My Products" runat="server" />
        </asp:Panel>
        <asp:Panel CssClass="new" runat="server">
            <asp:Button CssClass="buttons borderRadius red" ID="deleteUser_btn" Text="Delete Account" runat="server" />
            <asp:Button OnClick="SuspendUser_btn_Click" CssClass="buttons borderRadius red" ID="SuspendUser_btn" Text="Suspend Account" runat="server" />
            <asp:Button OnClick="unSuspendUser_btn_Click" CssClass="buttons borderRadius black" ID="unSuspendUser_btn" Text="Unsuspend Account" runat="server" />
        </asp:Panel>
    </asp:Panel>
    <input type="hidden" id="hdnSession" data-value="@Request.RequestContext.HttpContext.Session['userID']" />
    <script>
        document.getElementById("MainContent_deleteUser_btn").addEventListener("click", ConfirmDeletion);
        function ConfirmDeletion() {
            if (confirm("Are you sure you want to delete your profile?")) {
                $.ajax({
                    url: '/Pages/GetSession',
                    type: "POST",
                    async: true,
                    success: function (data) {
                        window.location.href = "/Pages/DeleteUserAPI?userID=" + data;
                    }
                });
            }

        }
    </script>
</asp:Content>
