<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chats.aspx.cs" Inherits="HomeCook.Chats" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div runat="server" id="chatList" style="margin: 50px 10px; width: 200px; float:left; display: inline; align-items: center">

    </div>
    <div style="margin: 50px 10px; width: 700px;" id="Chat">
        <div id="messages" runat="server">

        </div>
        <div>
            <asp:TextBox runat="server" Width="660px" ID="message"/>
            <asp:Button runat="server" Width="30px" Text=">" OnClick="Unnamed_Click"/>
        </div>
    </div>
</asp:Content>