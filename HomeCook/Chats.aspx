<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chats.aspx.cs" Inherits="HomeCook.Chats" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div runat="server" id="chatList" style="margin: 0 10px; width: 200px; float:left; display: inline; align-items: center">
        
        <%--<div id="advertElement" style="height: 50px; width: 200px">
            <div style="width: 200px; height: 50px; float:left" >
                <div style="height: 30px;" id="advert"> Anuncio </div>
                <div style="height: 20px;" id="vendor"> Vendedor </div>
            </div>
        </div>

        <div id="advertElement1" style="height: 50px; width: 200px">
            <div style="width: 200px; height: 50px; float:left" >
                <div style="height: 30px;" id="advert2"> Anuncio </div>
                <div style="height: 20px;" id="vendor2"> Vendedor </div>
            </div>
        </div>

        <div id="advertElement3" style="height: 50px; width: 200px">
            <div style="width: 200px; height: 50px; float:left" >
                <div style="height: 30px;" id="advert3"> Anuncio </div>
                <div style="height: 20px;" id="vendor3"> Vendedor </div>
            </div>
        </div>--%>

    </div>
    <div style="margin: 0 10px; width: 700px;" id="Chat">

    </div>
</asp:Content>