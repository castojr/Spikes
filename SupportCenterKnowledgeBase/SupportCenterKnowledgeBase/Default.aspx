<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SupportCenterKnowledgeBase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            color: #CCCCCC;
            font-size: medium;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
        }
        .auto-style4 {
            color: #CCCCCC;
            font-size: medium;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
        }
        .auto-style5 {
            text-align: left;
        }
        .auto-style6 {
            color: #CCCCCC;
            font-size: medium;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <br />
        </p>
        <p>
            &nbsp;</p>
        <p style="text-align: center">
            <asp:Image ID="logo" runat="server" Height="93px" ImageAlign="Middle" ImageUrl="/Assets/logo.png" style="text-align: center" Width="398px" />
        </p>
        <p style="text-align: center">
            &nbsp;</p>
        <p class="auto-style6" style="text-align: left">
            Username</p>
        <p style="text-align: left">
            <asp:TextBox ID="userNameTextBox" runat="server" Width="256px" OnTextChanged="Page_Load"></asp:TextBox>
        </p>
        <p class="auto-style4">
            Password</p>
        <p class="auto-style3">
            <asp:TextBox ID="passwordTextBox" runat="server" Width="252px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
