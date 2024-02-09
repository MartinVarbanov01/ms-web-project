<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="_46612r_MS.Pages.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style>
        #logo {
            height: fit-content;
            height: 250px;
            border-radius: 10px;    
        }

        .wrong_pass {
            color: red;
        }

        .LogoHolder {
            text-align: center;
        }

        #header {
            font-size: larger;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="LogoHolder">
            <asp:Image ID="logo" ImageUrl="~/Images/logo_new.png" runat="server" /><p></p>
            <asp:Label ID="header" Text="Fill the registration form" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Username" runat="server" />
            <p></p>
            <asp:TextBox ID="Username" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Email" runat="server" />
            <p></p>
            <asp:TextBox TextMode="Email" ID="Email" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Password" runat="server" />
            <p></p>
            <asp:TextBox TextMode="Password" ID="Password" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Confirm Password" runat="server" />
            <p></p>
            <asp:TextBox TextMode="Password" ID="Password2" runat="server" />
            <p></p>
            <asp:Label CssClass="wrong_pass" Visible="false" ID="pass" Text="Passwords don't match" runat="server" /><p></p>
            <asp:Button ID="Register_btn" OnClick="Register_btn_Click" Text="Register" runat="server" />
        </div>
    </form>
</body>
</html>
