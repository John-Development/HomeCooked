<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chats.aspx.cs" Inherits="HomeCook.Chats" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 50px 0; display: flex;">
        <div runat="server" id="chatList" style="margin:0, 10px; width: 230px; flex-direction: row; order: 0">

        </div>
        <div style="margin:0, 10px; width: 600px; flex-direction: row; order: 1" id="Chat">
            <div>
                <asp:TextBox runat="server" Width="400px" ID="message" Visible="false"/>
                <asp:Button runat="server" ID="send" cssClass="btn btn-primary" Width="40px" Text=">" OnClick="Unnamed_Click" Visible="false"/>
                <br />
                <label runat="server" id="label" style="font-size: small" Visible="false">Porciones vendidas</label>
                <asp:TextBox runat="server" ID="portions" Visible="false"/>
                <asp:Button runat="server" ID="close" cssClass="btn btn-primary" style="background-color:crimson" Width="40px" Text="x" OnClick="Close_Click" Visible="false"/>
                
            </div>
            <br />
            <div id="messages" runat="server">

            </div>
        </div>
    </div>
    
</asp:Content>