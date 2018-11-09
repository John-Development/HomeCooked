function ResizeImage() {
    var filesToUpload = document.getElementById('imageFile').files;
    var file = filesToUpload[0];

    // Create an image
    var img = document.createElement("img");
    // Create a file reader
    var reader = new FileReader();
    // Set the image once loaded into file reader
    reader.onload = function (e) {
        img.src = e.target.result;

        var canvas = document.createElement("canvas");
        //var canvas = $("<canvas>", {"id":"testing"})[0];
        var ctx = canvas.getContext("2d");
        ctx.drawImage(img, 0, 0);

        var MAX_WIDTH = 400;
        var MAX_HEIGHT = 400;
        var width = img.width;
        var height = img.height;

        if (width > height) {
            if (width > MAX_WIDTH) {
                height *= MAX_WIDTH / width;
                width = MAX_WIDTH;
            }
        } else {
            if (height > MAX_HEIGHT) {
                width *= MAX_HEIGHT / height;
                height = MAX_HEIGHT;
            }
        }
        canvas.width = width;
        canvas.height = height;
        var ctx2 = canvas.getContext("2d");
        ctx2.drawImage(img, 0, 0, width, height);

        var dataurl = canvas.toDataURL("image/png");
        document.getElementById('output').src = dataurl;
    };
    // Load files into file reader
    reader.readAsDataURL(file);
}

function showmodalpopup1() {
    $("#popupdiv").text("ElMensaje");

    $("#popupdiv").dialog({

        width: 400,
        height: 150,
        autoOpen: true,
        draggable: false,
        resizable: false,
        hide: "slide",
        modal: true
    });
}




function listarAnuncios(infoJson) {

    /*
    <div id="advertElement" style="height: 100px; width: 700px">
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
    </div>

    nameDiv.innerHTML = infoJson[i].Nombre   + " " +
            infoJson[i].PrimerAp + " " +
            infoJson[i].SegundoAp;
    */

    for (let i = 0; i < infoJson.length; i++) {

        //Elemento
        var elementDiv = document.createElement("div");
        elementDiv.setAttribute("style", "height: 100px; width: 700px");

        //Foto y nombre
        var bloque1Div = document.createElement("div");
        bloque1Div.setAttribute("style", "width: 100px; height: 100px; float:left");

        var imgDiv = document.createElement("div");
        imgDiv.setAttribute("style", "height: 80px;");
        //imgDiv.innerHTML = infoJson[i].ImageUri;

        var nameDiv = document.createElement("div");
        nameDiv.setAttribute("style", "height: 20px;");
        nameDiv.innerHTML = infoJson[i].Name;

        //Descripcion y alergenos
        var bloque2Div = document.createElement("div");
        bloque2Div.setAttribute("style", "width: 600px; height:100px; float: right");

        var bloque2_1Div = document.createElement("div");
        bloque2_1Div.setAttribute("style", "width: 450px; height:100px; float:left");

        var descDiv = document.createElement("div");
        descDiv.setAttribute("style", "height:60px");
        descDiv.innerHTML = infoJson[i].Details;

        var alergDiv = document.createElement("div");
        alergDiv.setAttribute("style", "height:40px");
        alergDiv.innerHTML = preferences(infoJson[i].Preferences);

        //Botones
        var bloque2_2Div = document.createElement("div");
        bloque2_2Div.setAttribute("style", "width: 150px; height: 100px; float: right");

        var b1Div = document.createElement("button");
        b1Div.setAttribute("class", "btn btn-primary");
        b1Div.setAttribute("style", "height:50px; width: 150px");
        b1Div.innerHTML = "Activar anuncio";

        var b2Div = document.createElement("button");
        b2Div.setAttribute("class", "btn btn-primary");
        b2Div.setAttribute("style", "height:50px; width: 150px");
        b2Div.innerHTML = "Borrar anuncio";

        //Jerarquía
        elementDiv.appendChild(bloque1Div);
            bloque1Div.appendChild(imgDiv);
            bloque1Div.appendChild(nameDiv);
        elementDiv.appendChild(bloque2Div);
            bloque2Div.appendChild(bloque2_1Div);
                bloque2_1Div.appendChild(descDiv);
                bloque2_1Div.appendChild(alergDiv);
            bloque2Div.appendChild(bloque2_2Div);
                bloque2_2Div.appendChild(b1Div);
                bloque2_2Div.appendChild(b2Div);

        document.getElementById("elements").appendChild(elementDiv);
    }
}


function preferences(preferencias) {
    var res = "Este producto ";

    if (!preferencias.shellfish && !preferencias.gluten && !preferencias.lactose) {
        res = res + " no contiene ningún alérgeno, ";
    }
    else {
        res = res + " contiene ";
    }

    if (preferencias.shellfish) {
        res = res + "marisco, ";
    }
    if (preferencias.gluten) {
        res = res + "gluten, ";
    }
    if (preferencias.lactose) {
        res = res + "lactosa, ";
    }

    res = res.substr(0, res.length - 2);
    res = res + ".";
    return res;
}