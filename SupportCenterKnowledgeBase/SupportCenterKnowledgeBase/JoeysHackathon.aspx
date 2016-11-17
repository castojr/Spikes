<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoeysHackathon.aspx.cs" Inherits="SupportCenterKnowledgeBase.JoeysHackathon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="brandLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="brandLinkButton" runat="server" OnClick="brandLinkButton_Click">Support Center</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
