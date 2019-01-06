var menuCtrl = angular.module('menuCtrl', []);
menuCtrl.controller('menuCtrl', ['$scope', '$rootScope', '$location', '$state', '$timeout', function ($scope, $rootScope, $location, $state, $timeout) {

    $scope.mostrarMenuBandera = false;
    $scope.ventanaMostrar = '';

    $scope.abrirMenu = function () {
        $("#menu").addClass("mostrarMenu");
        $("#menu").addClass("fadeInLeft");

        $timeout(function () {
            $("#menu").removeClass("fadeInLeft");
        }, 1000);

    };

    $scope.cerrarMenu = function () {
        $("#menu").addClass("fadeOutLeft");
        
        $timeout(function () {
            $("#menu").removeClass("mostrarMenu");
            $("#menu").removeClass("fadeOutLeft");
        }, 1000);
    };

    this.cerrarVentana = function () {
        
        $("#views").addClass("zoomOut");

        $timeout(function () {
            $('#views').hide();
            $(".contenedorView").remove();
            $scope.ventanaMostrar = '';
            $("#views").removeClass("zoomOut");
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

        
        

        $timeout(function () {
            
            $("#views").removeClass("zoomIn");
        }, 1000);

        //setTimeout(function () {
        
        //}, 5000);



        $scope.cerrarMenu();
    };

}]);

