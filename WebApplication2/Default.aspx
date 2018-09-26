<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Content/Inicio.css" rel="stylesheet" type="text/css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
<body class="bg">
    <form id="form1" runat="server">
        <div>
            HOLA, bienvenido a nuestra aplicación de COMIDA.</div>
        <br />
        Introduce tu nombre y QUE TE DEN un euro.<br />
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button CssClass="btonUp" ID="GetEuro" runat="server" Text="TU PUTO EURO" OnClick="Button1_Click" Width="177px" />
        <br />
        <asp:Button CssClass="btonMid" ID="Button1" runat="server" Text="Button" Width="177px" />
        <br />
        <asp:Button CssClass="btonDown" ID="Button2" runat="server" Text="Button" Width="177px" />
    </form>
    <form>
        <asp:Image ID="Euro" runat="server" src="images/1euroNew.jpg" alt="Sample Photo" Visible="false"/>
    </form>
</body>
</html>
