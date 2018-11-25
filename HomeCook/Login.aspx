<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HomeCook.Login" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="center" style="height: 200px; width: 300px">
    <div>
        Introduce tus datos para iniciar sesión.
        <br />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Error al iniciar sesión: usuario o contraseña incorrectos" ForeColor="Crimson" ControlToValidate="user" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
    </div>

    <div class="centerElement" style="width: 70%">
    Nombre de usuario.
    <br />
    <asp:TextBox ID="user" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="user" runat="server" ForeColor="Crimson" ErrorMessage="Introduce un usuario válido"></asp:RequiredFieldValidator>
    <br />
    Contraseña.
    <br />
    <asp:TextBox ID="password" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="password" runat="server" ForeColor="Crimson" ErrorMessage="Introduce una contraseña válida"></asp:RequiredFieldValidator>
    <br />
    </div>
    <br />
    <div>
        <asp:Button CssClass="btn btn-primary" style="float:left" Text="Nuevo usuario" runat="server" OnClick="NewUser_Click"/>
        <asp:Button CssClass="btn btn-primary" style="float:right" Text="Acceder" runat="server" OnClick="Login_Click"/>
    </div>
    </div>
</asp:Content>