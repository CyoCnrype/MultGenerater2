<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCase.aspx.cs" Inherits="MultGenerater.ShowCase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>乘法對照表產生器</h1>
            <asp:PlaceHolder ID="plcShowCase" runat="server" Visible="true">
                <asp:Panel ID="PanelCase" runat="server" BorderStyle="Double">
                    
                </asp:Panel>
            </asp:PlaceHolder>
            <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
        </div>        
    </form>
</body>
</html>
