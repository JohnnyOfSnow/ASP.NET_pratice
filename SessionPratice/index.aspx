<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SessionPratice.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="How old are you?" runat="server"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="AgeTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Submit"  text="submit" OnClick="Submit_Click" runat="server" />
            <asp:Button ID="ShowButton" text="show" OnClick="ShowButoon_Click" runat="server" />
        </div>
    </form>
</body>
</html>
