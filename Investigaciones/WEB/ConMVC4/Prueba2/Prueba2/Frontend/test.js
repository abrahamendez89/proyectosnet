$(document).on("ready", loadEvents);

function loadEvents() {
    $(".myButton").click(function (evento) {

        var usuario = $("#usuario").val();
        var password = $("#contra").val();


        var dusuario = {} // objetvo vacio
        dusuario.Contra = $("#contra").val();
        dusuario.Usuario = $("#usuario").val();



        var usuario = JSON.stringify({
            'Usuario': $('#usuario').val(),
            'Contra': $('#contra').val()
        });


        $.ajax({
            method: "POST", //el tipo de llamado
            url: "/Ingresar/Ingresar/", //el controller que llamara XD error D: 
            dataType: "json",
            data: { Usuario: "John", Contra: "Doe" },
            datatype: "application/json" // haber te dejare un ratillo voy a leer 77 pq nunca me paso esto con jquery voy a ver el codigo que tengo
        })
        .success(function (result) {

            if (result) {
                var options = {};
                $(".login").effect("puff", options, 500, function () {
                    $(".login").remove();
                });
            }
            else {

                //var error = "<h1 class='animated fadeInLeft'>Error usuario incorrecto</h1>";
                //$(".login").append(error);

                $(".login").addClass("bounceIn");
                setTimeout(function () {
                    $(".login").removeClass("bounceIn");
                }, 500);
            }
        })
        .error(function (error) {
           console.log(error);
        });
    });
}

function callback() {
    setTimeout(function () {
        $(".login").remove();
    }, 1000);
};