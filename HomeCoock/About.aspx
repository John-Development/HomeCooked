<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HomeCook.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <div>
        <asp:TextBox runat="server" ID="Message" CssClass="input-medium search-query"></asp:TextBox>
        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="input-medium search-query"></asp:TextBox>
        <asp:Button runat="server" ID="Send" Text="Send" CssClass="btn btn-primary" OnClick="Send_Click"/>
    </div>
</asp:Content>
