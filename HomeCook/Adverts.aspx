﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adverts.aspx.cs" Inherits="HomeCook.Adverts" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="center">
        <asp:Button class="btn btn-primary" runat="server" style="float:right" ID="new" Text="Crear anuncio" OnClick="NewAdvert_Click"/>
    </div>
    <div class="coincidenceElement" id="elements">
        <%--<div id="advertElement" style="height: 100px; width: 700px">
            <div style="width: 100px; height: 100px; float:left" >
                <div style="height: 80px;" id="image"> imagen </div>
                <div style="height: 20px;" id="name"> nombre </div>
            </div>
            <div style="width: 600px; height:100px; float: right">
                <div style="width: 450px; height:100px; float:left">
                    <div style="height:60px" id="description"> decripcion </div>
                    <div style="height:40px" id="alerglist"> alérgenos </div>
                </div>
                <div style="width: 150px; height: 100px; float: right">
                    <button class="btn btn-primary" style="height:50px; width: 150px" id="activate"> Activar anuncio </button>
                    <button class="btn btn-primary" style="height:50px; width: 150px" id="remove"> Borrar anuncio </button>
                </div>
            </div>
        </div>--%>
    </div>
</asp:Content>