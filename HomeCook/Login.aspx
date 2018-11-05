<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HomeCook.Login" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="center" style="height: 200px; width: 300px">
    <div>
        Introduce tus datos para iniciar sesión.
    </div>

    <div class="centerElement" style="width: 70%">
    Nombre de usuario.
    <br />
    <asp:TextBox ID="user" runat="server" Width="200px"></asp:TextBox>
    <br />
    Contraseña.
    <br />
    <asp:TextBox ID="password" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
    <br />
    </div>
    <br />
    <div>
        <asp:Button CssClass="btn btn-primary" style="float:left" Text="Nuevo usuario" runat="server" OnClick="NewUser_Click"/>
        <asp:Button CssClass="btn btn-primary" style="float:right" Text="Acceder" runat="server" OnClick="Login_Click"/>
    </div>
    </div>
</asp:Content>