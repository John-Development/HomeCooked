<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HomeCooked.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div>
        HOLA, bienvenido a nuestra aplicación de COMIDA.</div>
    <br />
    Introduce tu nombre y QUE TE DEN un euro.<br />
    <asp:TextBox ID="Name" runat="server"></asp:TextBox>
    <br />
    <asp:Button CssClass="btonUp" ID="GetEuro" runat="server" Text="TU PUTO EURO" OnClick="Button1_Click" Width="177px" />
    <br />
    <asp:Button CssClass="btonMid" ID="Login" runat="server" Text="Incia sesión" Width="177px" OnClick="Login_Click" />
    <br />
    <asp:Button CssClass="btonDown" ID="About" runat="server" Text="Botón inútil" Width="177px"/>
    <br />
    <asp:Image ID="Euro" runat="server" ImageUrl="images/1euroNew.jpg" AlternateText="Sample Photo" Visible="false"/>--%>
    
    <asp:ListView runat="server" ID="ofertas">
        <ItemTemplate/>
    </asp:ListView>

</asp:Content>