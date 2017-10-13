<%@ Page Language="C#" AutoEventWireup="true" CodeFile="page.aspx.cs" Inherits="page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>URL Rewrite Demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <h1>
            URL Rewrite Demo</h1>
    </div>
    <br />
    <div style="width:500px; margin:0 auto;">
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Product ID:"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:Label ID="ProductLabel" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Product Name:"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:Label ID="ProductNameLabel" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
