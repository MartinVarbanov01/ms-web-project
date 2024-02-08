<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPageaspx.aspx.cs" Inherits="_46612r_MS.Pages.LoginPageaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoginPage</title>
    <style>
        #logo{
            height:fit-content;
            height:350px;
        }
        .LogoHolder{
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="LogoHolder">
            <asp:Image ID="logo" ImageUrl="~/Images/logo.png" runat="server" />
            <p>&nbsp;</p>
            <asp:Label Text="Username / Email" runat="server" />
            <p></p>
            <asp:TextBox ID="Username" runat="server"/>
            <p>&nbsp;</p>
            <asp:Label Text="Password" runat="server" />
            <p></p>
            <asp:TextBox ID="Password" runat="server" />
            <p>&nbsp;</p>
            <asp:Button ID="Login_btn" OnClick="Login_btn_Click" Text="Login" runat="server"/>
    </form>
</body>
</html>
