<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HomeCoock.Register" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="margin: 50px 0 0 0">
            Rellena los campos para poder completar el registro.
        </div>
        <br />
        <div style="margin: 0 50px; width: 300px">
            Nombre de usuario
            <br />
            <asp:TextBox ID="user" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Correo electrónico
            <br />
            <asp:TextBox ID="email" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Contraseña
            <br />
            <asp:TextBox ID="password" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Localización
            <br />
            <asp:TextBox ID="location" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Alérgenos (marca si eres alérgico)
            <br />
            <asp:CheckBox ID="shellfish" runat="server" Text="Marisco"/>
            <asp:CheckBox ID="gluten" runat="server" Text="Gluten"/>
            <asp:CheckBox ID="lactose" runat="server" Text="Lactosa"/>
            <br />
        </div>
        <br />
        <div class="centerButton">
            <asp:Button CssClass="btn btn-primary" style="margin: 40px 0 0 200px" Text="Registrarse" runat="server" OnClick="Register_Click"/>
        </div>
    </div>
</asp:Content>