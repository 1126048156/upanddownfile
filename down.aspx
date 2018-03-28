<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="down.aspx.cs" Inherits="fileupload.down" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        从服务器上下载文件<br />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="下载" />
    </form>
</body>
</html>
