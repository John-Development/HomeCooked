<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HomeCook.Login" %>


<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>


<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <link href="/Content/Style.css" rel="stylesheet" type="text/css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
<body class="bg">
    <form class="centro" runat="server">
        <div>
            Introduce tus datos para iniciar sesión.
        </div>
        <div>
        Nombre de usuario.
        <br />
        <asp:TextBox ID="centro" runat="server"></asp:TextBox>
        <br />
        Contraseña.
        <br />
        <asp:TextBox ID="centro2" runat="server"></asp:TextBox>
        <br />
        </div>
        <asp:Button CssClass="btonLeft" Text="Cancelar" runat="server" OnClick="Return_Click"/>
        <asp:Button CssClass="btonRight" Text="Acceder" runat="server" OnClick="Login_Click"/>
    </form>
</body>
</html>--%>


<asp:Content ID="centro" ContentPlaceHolderID="MainContent"  CssClass="centro" runat="server">
   <div class="centro">
    <div>
        Introduce tus datos para iniciar sesión.
    </div>

    <div>
    Nombre de usuario.
    <br />
    <asp:TextBox ID="user" runat="server"></asp:TextBox>
    <br />
    Contraseña.
    <br />
    <asp:TextBox ID="password" runat="server"></asp:TextBox>
    <br />
    </div>
    <asp:Button CssClass="btonLeft" Text="Cancelar" runat="server" OnClick="Return_Click"/>
    <asp:Button CssClass="btonRight" Text="Acceder" runat="server" OnClick="Login_Click"/>
    </div>
</asp:Content>