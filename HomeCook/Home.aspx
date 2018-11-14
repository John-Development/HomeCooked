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
    
    <div class="coincidenceElement" id="elements" runat="server" style="display: inline; align-items: center">
        <%--<asp:LinkButton runat="server" >hola</asp:LinkButton>--%>
        <%--<div id="advertElement" style="height: 100px; width: 700px; margin: 0 0 25px 100px">
                <div style="width: 100px; height: 100px; float:left" >
                    <div style="height: 60px;" id="image"> imagen </div>
                    <div style="height: 40px;" id="name"> nombre </div>
                </div>
                <div style="width: 600px; height:100px; float: right">
                    <div style="width: 450px; height:100px; float:left">
                        <div style="height:60px" id="description"> decripcion </div>
                        <div style="height:40px" id="alerglist"> alérgenos </div>
                    </div>
                    <div style="width: 150px; height: 100px; float: right">
                        <button class="btn btn-primary" style="height:50px; width: 150px" id="activate"> Activar anuncio </button>
                        <button class="btn btn-primary" style="height:50px; width: 150px; background-color: crimson" id="remove"> Borrar anuncio </button>
                    </div>
                </div>
            </div>--%>
    </div>

</asp:Content>