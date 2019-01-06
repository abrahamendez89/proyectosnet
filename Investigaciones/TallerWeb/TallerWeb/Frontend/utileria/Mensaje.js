var mensaje =
    {
        cerrarNotificacion: function (cerrarSinAnimar, id) {

            if (cerrarSinAnimar) {
                //$("#mensaje").removeClass("fadeInRight");
                $("#" + id).addClass("zoomOutDown");

                setTimeout(function () {

                    $("#" + id).remove();

                }, 1200);
                return;
            }
            setTimeout(function () {
                //$("#mensaje").removeClass("fadeInRight");
                $("#" + id).addClass("fadeOutRight");
            }, 5000);
            setTimeout(function () {

                $("#" + id).remove();

            }, 6200);
        },
        notificacion: function (mensaje, opciones, callback) {

            var configuracion = {
                _titulo: 'Notificación',
                _mensaje: mensaje,
                _cerrarAutomatico: true

            }

            configuracion = $.extend(configuracion, opciones); //merge de ambos objetos y los complementa con informacion faltante

            var random = "mensaje_" + Math.floor((Math.random() * 100) + 1);

            var notificacion = '<div id ="' + random + '" class="Notificacion animated fadeInRight">'
            + '<div class="header">  '
              + '  <span class="titulo">' + configuracion._titulo + '</span>'
               + ' <span class="icon-cross" onClick="mensaje.cerrarNotificacion(true, \'' + random + '\')"></span>'
            + '</div>'
            + '<div class="body">  '
              + '  <p>'
                   + configuracion._mensaje
               + ' </p>'
           + ' </div>'
        + '</div>'

            $("#contenedor_notificacion").append(notificacion);
            if (configuracion._cerrarAutomatico)
                this.cerrarNotificacion(false, random);


            if (callback) {
                callback();
            }
        }
    }