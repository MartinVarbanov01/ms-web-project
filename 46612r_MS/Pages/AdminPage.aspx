<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="_46612r_MS.Pages.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .gv {
            background-color: white;
        }
    </style>
    <asp:GridView CssClass="gv" OnRowDataBound="users_RowDataBound" AutoGenerateColumns="false" ID="users" runat="server">
        <Columns>
            <asp:BoundField DataField="IDUser" HeaderText="ID" />
            <asp:ImageField DataImageUrlField="Photo" DataImageUrlFormatString="{0}" HeaderText="Profile Picture" />
            <asp:BoundField DataField="Username" HeaderText="UserName" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
        </Columns>
    </asp:GridView>
    <script>
        function addRowHandlers() {
            var table = document.getElementById("MainContent_users");
            var rows = table.getElementsByTagName("tr");
            for (i = 0; i < rows.length; i++) {
                var currentRow = table.rows[i];
                var createClickHandler = function (row) {
                    return function () {
                        var cell = row.getElementsByTagName("td")[0];
                        var userID = cell.innerHTML;
                        window.open("/Pages/Profile?userID=" + userID, "_blank");
                    };
                };
                currentRow.onclick = createClickHandler(currentRow);
            }
        }
        addRowHandlers()

    </script>
</asp:Content>
