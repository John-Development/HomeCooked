<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAdvert.aspx.cs" Inherits="HomeCook.CreateAdvert" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <div style="margin: 50px 0 0 0">
            Rellena los campos para poder completar la creación del anuncio.
        </div>
        <br />
        <div style="margin: 0 50px; width: 300px">
            Nombre del plato
            <br />
            <asp:TextBox ID="name" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Description
            <br />
            <asp:TextBox ID="details" runat="server" Width="200px" Height="50px"></asp:TextBox>
            <br />
            <br />
            Cantidad de porciones
            <br />
            <asp:TextBox ID="porciones" TextMode="Number" runat="server" Width="200px" Height="50px"></asp:TextBox>
            <br />
            <br />
            Alérgenos (marca los alérgenos que contenga tu plato)
            <br />
            <asp:CheckBox ID="shellfish" runat="server" Text="Marisco"/>
            <asp:CheckBox ID="gluten" runat="server" Text="Gluten"/>
            <asp:CheckBox ID="lactose" runat="server" Text="Lactosa"/>
            <br />
        </div>
        <br />
        <div class="centerButton">
            <asp:Button CssClass="btn btn-primary" style="margin: 40px 0 0 200px" Text="Crear anuncio" runat="server" OnClick="CreateAdvert_Click"/>
        </div>
    </div>
</asp:Content>