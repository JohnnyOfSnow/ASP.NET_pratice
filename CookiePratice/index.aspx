<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CookiePratice.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Welcome_Hint"  runat="server"></asp:Label>
        </div>
        <div>
             <asp:Button ID="logout" Text="logout" class="button_style" OnClick="LogoutButton_Click" runat="server" />
        </div>
    </form>
</body>
</html>
