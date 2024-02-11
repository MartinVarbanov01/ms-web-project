<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="_46612r_MS.Pages.LoginPageaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        #logo {
            height: fit-content;
            height: 250px;
            border-radius: 10px;
        }

        #wrong_pass {
            color: red;
        }

        .LogoHolder {
            text-align: center;
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

        .link {
            color: black;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="LogoHolder">
            <asp:Image ID="logo" ImageUrl="~/Images/logo_new_white.png" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Email" runat="server" />
            <p></p>
            <asp:TextBox CssClass="borderRadius" ID="UserEmail" runat="server" />
            <p></p>
            <asp:Label Text="Password" runat="server" />
            <p></p>
            <asp:TextBox CssClass="borderRadius" TextMode="Password" ID="UserPassword" runat="server" /><p></p>
            <asp:Label ID="wrong_pass" Visible="false" Text="Wrong password or username or both who knows!" runat="server" /><p></p>
            <asp:Button CssClass="borderRadius buttons" ID="Login_btn" OnClick="Login_btn_Click" Text="Login" runat="server" /><p></p>
            <asp:LinkButton OnClick="Register_btn_Click" CssClass="link" Text="Don't have and account? <b>Register Here</b>" runat="server" />
        </div>
    </form>
</body>
</html>
