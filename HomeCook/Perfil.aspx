<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="HomeCook.Perfil" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="margin: 50px 0 0 0">
            Aquí puede editar su perfil.
        </div>
        <br />
        <div style="float:left">
            <img src="/" id="profilePic"/>
            <br /> 
            <input type="file" style="width: 200px" name="profilePic"/>
        </div>
        <div style="margin: 0 0 0 240px; width: 600px">
            Nombre de usuario
            <br />
            <asp:TextBox ID="user" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            Correo electrónico
            <br />
            <asp:TextBox runat="server" ID="email" Width="200px" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            Contraseña
            <asp:Label runat="server" ID="passLabel" Text="Vuelva a escribir la contraseña" style="margin: 0 0 0 180px" Width="200px"> </asp:Label>
            <br />
            <asp:TextBox runat="server" ID="password" TextMode="Password" Width="200px"></asp:TextBox>
            <asp:TextBox ID="passRepeat" TextMode="Password" runat="server" style="margin: 0 0 0 50px" Width="200px"></asp:TextBox>
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
            <asp:Button CssClass="btn btn-primary" style="margin: 40px 0" Text="Guardar cambios" runat="server" OnClick="SaveCanges_Click"/>
            <asp:Button CssClass="btn btn-primary" style="margin: 40px 0 40px 10px" Text="Cerrar sesión" runat="server" OnClick="Logout_Click"/>
            <asp:Button CssClass="btn btn-primary" style="background-color: crimson; margin: 40px 20px 40px 50px" Text="Eliminar cuenta" runat="server" OnClick="DropOut_Click"/>
            <asp:label runat="server" style="" Text="Escribe tu contraseña para eliminar la cuenta"></asp:label>
            <asp:TextBox runat="server" ID="passDelete" style="margin: 0 0 0 20px" TextMode="Password"></asp:TextBox>
        </div>
        <%--<div id="popupdiv" title="Basic modal dialog" style="display: none;">

        </div>--%>
    </div>
</asp:Content>
