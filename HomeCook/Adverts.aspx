<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adverts.aspx.cs" Inherits="HomeCook.Adverts" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="center">
        <asp:Button class="btn btn-primary" runat="server" style="float:right" ID="new" Text="Crear anuncio" OnClick="NewAdvert_Click"/>
    </div>
    <div>
        <%--<asp:ListView runat="server" ID="anuncios">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblId" Text="Text"></asp:Label>
            </ItemTemplate>
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
            </LayoutTemplate>
        </asp:ListView>--%>
    </div>
</asp:Content>