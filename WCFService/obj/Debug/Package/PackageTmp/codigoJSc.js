$(document).ready(function () {

    
    var $chatbox = $('.chatbox'),
        $chatboxTitle = $('.chatbox__title'),
        $chatboxTitleClose = $('.chatbox__title__close'),
        $chatboxCredentials = $('.chatbox__credentials');
    $chatboxTitle.on('click', function () {
        $chatbox.toggleClass('chatbox--tray');
    });
    $chatboxTitleClose.on('click', function (e) {
        e.stopPropagation();
        $chatbox.addClass('chatbox--closed');
    });
    $chatbox.on('transitionend', function () {
        if ($chatbox.hasClass('chatbox--closed')) $chatbox.remove();
    });
    $chatboxCredentials.on('submit',function (e) {
        e.preventDefault();
        var str = $("#inputName").val();
        var res = str.replace(/['"]+/g, '');
        res = res.replace(/\\/g, '');
        $.ajax({
            url: "Chat.svc/Autenticar",
            type: "POST",
            data: '{"correo":"' + $("#inputEmail").val() + '","password":"' + res + '" }',
            contentType: "application/json",
            dataType: "json",
            processData: true,
            beforeSend: function (objeto) {
                document.getElementById("idCredenciales").disabled = true;
                document.getElementById("idSinCredenciales").disabled = true;
            },
            success: function (response) {
                var foo = response;
                if (foo.idAutenticado > 0) {
                    $("#identificador").val(foo.idAutenticado);
                    $("#esAutenticado").val(1);
                    $chatbox.removeClass('chatbox--empty');
                } else {
                    alert("¡Correo electrónico o Contraseña incorrectos!");
                    $("#inputEmail").val("");
                    $("#inputName").val("");
                    document.getElementById("idCredenciales").disabled = false;
                    document.getElementById("idSinCredenciales").disabled = false;
                }
            }
        });
    });
    $("#idSinCredenciales").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "Chat.svc/NoAutenticar",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            processData: true,
            beforeSend: function (objeto) {
                document.getElementById("idSinCredenciales").disabled = true;
                document.getElementById("idCredenciales").disabled = true;
            },
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

function myFunction(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    var str = $("#mensajeAE").val();
    var res = str.replace(/[' ]+/g, ' ');
    if (tecla == 13 && res!= "" && res!=" ") {      
        res = res.replace(/['"]+/g, '');
        res = res.replace(/\\/g, '');     
        res = res.trim();
        $.ajax({
            url: "Chat.svc/FuncionChat",
            type: "POST",
            data: '{"nombre":"' +res  + '","identificador":"' + $("#identificador").val() + '","esAutenticado":"' + $("#esAutenticado").val()  +'" }',
            contentType: "application/json",
            dataType: "json",
            processData: true,
            beforeSend: function (objeto) {
                document.getElementById("mensajeAE").placeholder = "En un momento te respondo...";
                document.getElementById("mensajeAE").disabled = true;

            },
            success: function (response) {
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
                VentanaChat = document.getElementById("body");
                var nuevo = VentanaChat.scrollHeight;
                VentanaChat.scrollTo(0, nuevo);
                document.getElementById("mensajeAE").disabled = false;
                document.getElementById("mensajeAE").placeholder = "Escribe algo...";
            }
        });

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
        
        VentanaChat = document.getElementById("body");
        var nuevo = VentanaChat.scrollHeight;
        VentanaChat.scrollTo(0, nuevo);

    }
    
}