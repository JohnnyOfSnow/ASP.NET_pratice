<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="CookiePratice.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="MyStyle.css" asp-append-version="true" />
    <title></title>
</head>
<body>
    <div class="wrapper">
        <div class="content">
             <form id="form2" runat="server">
                <div>
                     <asp:Label ID="Welcome_Hint" class="label_style" runat="server"></asp:Label>
                </div>
                <div>
                     <asp:Button ID="logout_Btn" Text="logout" class="button_style logoutBtn" OnClick="LogoutButton_Click" runat="server" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
