$(document).ready(function () {

    //variables
    var $chatbox = $('.chatbox'),
        $chatboxTitle = $('.chatbox__title'),
        $chatboxTitleClose = $('.chatbox__title__close'),
        $chatboxCredentials = $('.chatbox__credentials');
    //Abrir la pestaña del chatbot
    $chatboxTitle.on('click', function () {
        $chatbox.toggleClass('chatbox--tray');
    });
    //Minimizar la pestaña del chatbot
    $chatboxTitleClose.on('click', function (e) {
        e.stopPropagation();
        $chatbox.addClass('chatbox--closed');
    });

    $chatbox.on('transitionend', function () {
        if ($chatbox.hasClass('chatbox--closed')) $chatbox.remove();
    });
    //Enviar las credenciales de un estudiante para autenticar
    $chatboxCredentials.on('submit',function (e) {
        e.preventDefault();
        var str = $("#inputName").val();
        var res = str.replace(/['"]+/g, '');
        res = res.replace(/\\/g, '');
        //petición ajax
        $.ajax({
            //datos de la petición
            url: "Chat.svc/Autenticar",
            type: "POST",
            data: '{"correo":"' + $("#inputEmail").val() + '","password":"' + res + '" }',
            contentType: "application/json",
            dataType: "json",
            processData: true,
            //Antes de enviar bloquear los demás controles del chatbot
            beforeSend: function (objeto) {
                document.getElementById("idCredenciales").disabled = true;
                document.getElementById("idSinCredenciales").disabled = true;
            },
            //Al haber tenido éxito en la petición
            success: function (response) {
                var foo = response;
                //Si la autenticación es correcta proceder al chat
                if (foo.idAutenticado > 0) {
                    $("#identificador").val(foo.idAutenticado);
                    $("#esAutenticado").val(1);
                    $chatbox.removeClass('chatbox--empty');
                } else {
                    //Si la autenticación es incorrecta presentar un mensaje de error
                    alert("¡Correo electrónico o Contraseña incorrectos!");
                    $("#inputEmail").val("");
                    $("#inputName").val("");
                    document.getElementById("idCredenciales").disabled = false;
                    document.getElementById("idSinCredenciales").disabled = false;
                }
            }
        });
    });
    //Ingresar al chat sin autenticarse
    $("#idSinCredenciales").click(function (e) {
        e.preventDefault();
        //Petición ajax
        $.ajax({
            //Parámetros de la petición
            url: "Chat.svc/NoAutenticar",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            processData: true,
            //Antes de enviar bloquear los controles
            beforeSend: function (objeto) {
                document.getElementById("idSinCredenciales").disabled = true;
                document.getElementById("idCredenciales").disabled = true;
            },
            //Al haber tenido éxito con la petición
            success: function (response) {
                var foo = response;
                if (foo.idAutenticado > 0) {
                    $("#identificador").val(foo.idAutenticado);
                    $("#esAutenticado").val(0);
                    $chatbox.removeClass('chatbox--empty');
                }
            }
        });
    });
});
//Función al enviar mensajes al chatbot
function myFunction(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    var str = $("#mensajeAE").val();
    //Para que se envíe únicamente con enter
    var res = str.replace(/[' ]+/g, ' ');
    if (tecla == 13 && res!= "" && res!=" ") {      
        res = res.replace(/['"]+/g, '');
        res = res.replace(/\\/g, '');     
        res = res.trim();
        //Petición ajax
        $.ajax({
            //Parámetros de la petición
            url: "Chat.svc/FuncionChat",
            type: "POST",
            data: '{"nombre":"' +res  + '","identificador":"' + $("#identificador").val() + '","esAutenticado":"' + $("#esAutenticado").val()  +'" }',
            contentType: "application/json",
            dataType: "json",
            processData: true,
            //Antes de enviar bloquear
            beforeSend: function (objeto) {
                document.getElementById("mensajeAE").placeholder = "En un momento te respondo...";
                document.getElementById("mensajeAE").disabled = true;

            },
            //Al haber tenido éxito con la petición
            success: function (response) {
                //Crar uhn nuevo objeto html con la estructura donde se insertará la respuesta del chatbot
                var foo = response;
                var divChatbot = document.createElement("div");
                divChatbot.className = "chatbox__body__message chatbox__body__message--left";
                var p = document.createElement("p");
                var img = document.createElement("img");
                img.src = "/chatbot.png"
                p.innerHTML = foo.Respuesta;
                divChatbot.appendChild(img);
                divChatbot.appendChild(p);
                var capa = document.getElementById("body");
                capa.appendChild(divChatbot);
                //Agregar a la página web
                VentanaChat = document.getElementById("body");
                var nuevo = VentanaChat.scrollHeight;
                VentanaChat.scrollTo(0, nuevo);
                //Limpiar los campos
                document.getElementById("mensajeAE").disabled = false;
                document.getElementById("mensajeAE").placeholder = "Escribe algo...";
            }
        });
        //Crear un nuevo objeto html con la correspondiente estructura donde se insertará el mensaje enviado por el usuario
        var div = document.createElement("div");
        div.className = "chatbox__body__message chatbox__body__message--right";
        var p = document.createElement("p");
        var img = document.createElement("img");
        img.src = "/persona.png"
        p.innerHTML = str;
        div.appendChild(img);
        div.appendChild(p);
        var capa = document.getElementById("body");
        capa.appendChild(div);
        $("#mensajeAE").val("");
        //Agregar a la página web
        VentanaChat = document.getElementById("body");
        var nuevo = VentanaChat.scrollHeight;
        VentanaChat.scrollTo(0, nuevo);

    }
    
}