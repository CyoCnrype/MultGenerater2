<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MultGenerater.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>  
   <form id="form1" runat="server">
        <h1>乘法對照表產生器</h1>
        <asp:PlaceHolder ID="plcDefault" runat="server" Visible="true">
            基數<asp:TextBox ID="txtBase" runat="server" TextMode="Number" >
            </asp:TextBox>
            <br />
            係數<asp:TextBox ID="txtCoef" runat="server" TextMode="Number">
            </asp:TextBox>
            <asp:Button ID="btnCocu" runat="server" Text="產生" OnClick="btnCocu_Click"    />
            <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
        </asp:PlaceHolder>
       <br />
       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       
    </form>
</body>
</html>
