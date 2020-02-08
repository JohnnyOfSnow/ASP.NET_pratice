<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="CookiePratice.login" %>

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
            <form id="form1" runat="server">
                <div>
                    <asp:Label ID="Login_Hint" Text="Please enter your account and password" class="label_style" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Account_Hint" Text="Name: " runat="server"></asp:Label>
                    <br />
                    <asp:TextBox ID="AccountText" class="textbox_style" type="text" placeholder="your name..." runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Password_Hint" Text="Password: " runat="server"></asp:Label>
                    <br />
                    <asp:TextBox ID="PasswordText" class="textbox_style" type="text" placeholder="your account..." runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="submit" Text="submit" class="button_style loginBtn" OnClick="SubmitButton_Click" runat="server" />
                    <asp:Button ID="Enter_HomePage" Text="Enter HomePage" class="button_style EnterHomePageBtn" OnClick="EnterHomePageButton_Click" runat="server" />
                </div>
            </form>
        </div>
    </div>
    
</body>
</html>
