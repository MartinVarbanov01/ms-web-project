<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="_46612r_MS.Pages.LoginPageaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        #logo {
            height: fit-content;
            height: 350px;
        }

        #wrong_pass {
            color: red;
        }

        .LogoHolder {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="LogoHolder">
            <asp:Image ID="logo" ImageUrl="~/Images/logo_new.png" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Username / Email" runat="server" />
            <p></p>
            <asp:TextBox ID="Username" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Password" runat="server" />
            <p></p>
            <asp:TextBox TextMode="Password" ID="Password" runat="server" /><p></p>
            <asp:Label ID="wrong_pass" Visible="false" Text="Wrong password or username or both who knows!" runat="server" /><p></p>
            <asp:Button ID="Login_btn" OnClick="Login_btn_Click" Text="Login" runat="server" />
            <asp:Button ID="Register_btn" OnClick="Register_btn_Click" Text="Register" runat="server" />
        </div>
    </form>
</body>
</html>
