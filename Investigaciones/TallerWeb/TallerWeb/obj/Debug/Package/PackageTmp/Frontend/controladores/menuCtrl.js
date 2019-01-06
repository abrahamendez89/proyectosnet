var menuCtrl = angular.module('menuCtrl', []);
menuCtrl.controller('menuCtrl', ['$scope', '$rootScope', '$location', '$state', function ($scope, $rootScope, $location, $state) {

    $scope.mostrarMenuBandera = false;
    $scope.ventanaMostrar = '';

    $scope.abrirMenu = function () {
        $("#menu").addClass("mostrarMenu");
        $("#menu").addClass("fadeInLeft");

        setTimeout(function () {
            $("#menu").removeClass("fadeInLeft");
        }, 1000);

    };

    $scope.cerrarMenu = function () {
        $("#menu").addClass("fadeOutLeft");
        
        setTimeout(function () {
            $("#menu").removeClass("mostrarMenu");
            $("#menu").removeClass("fadeOutLeft");
        }, 1000);
    };

    this.cerrarVentana = function () {
        
        $("#views").addClass("zoomOutDown");

        setTimeout(function () {
            $('#views').hide();
            $(".contenedorView").remove();
            $scope.ventanaMostrar = '';
            $("#views").removeClass("zoomOutDown");
        }, 1000);


    };

    $scope.cambiarVentana = function (ventana) {
        $('#views').show();
        //aqui podria trarme lo que el usuario puede ver
        $("#views").addClass("zoomIn");
        if (ventana == 'test') {
            $scope.ventanaMostrar = "\\frontend\\vistasSistema\\productos.html";
        }
        else if (ventana = 'test2') {
            $scope.ventanaMostrar = "\\frontend\\vistasSistema\\catalogoPrueba.html";
        }

        
        

        setTimeout(function () {
            
            $("#views").removeClass("zoomIn");
        }, 1000);

        //setTimeout(function () {
        
        //}, 5000);



        $scope.cerrarMenu();
    };

}]);

