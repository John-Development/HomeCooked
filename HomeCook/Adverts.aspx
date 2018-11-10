<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adverts.aspx.cs" Inherits="HomeCook.Adverts" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="center">
        <asp:Button class="btn btn-primary" runat="server" style="float:right" ID="new" Text="Crear anuncio" OnClick="NewAdvert_Click"/>
    </div>
    <div class="coincidenceElement" id="elements" runat="server" style="display: inline; align-items: center">
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
    <script type="text/javascript">
        function Button2(id) {
            console.log("boton 2");
            <%--console.log("<%=ResolveUrl("~/Adverts.aspx")%>");--%>

            //Call the approve method on the code behind
            //$.ajax({
            //    type: "POST",
            //    url: "Pages/Mobile/Adverts.aspx/Button2_click",
            //    data: "{'id':'" + id + "' }", //Pass the parameter names and values
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    async: true,
            //});
            //PageMethods.set_path("<%=ResolveUrl("~/Adverts.aspx")%>");
            PageMethods.Button2_click(id);
        }

        function Button1(id) {
            console.log("boton 1");

            //Call the approve method on the code behind
            //$.ajax({
            //    type: "POST",
            //    url: "Pages/Mobile/Adverts.aspx/Button1_click",
            //    data: "{'id':'" + id + "' }", //Pass the parameter names and values
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    async: true,
            //});

            //PageMethods.set_path("<%=ResolveUrl("~/Adverts.aspx")%>");
            PageMethods.Button1_click(id);
        }
    </script>
</asp:Content>