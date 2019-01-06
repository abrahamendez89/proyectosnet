var principalCtrl = angular.module('principalCtrl', ['loginCtrl','menuCtrl']);
principalCtrl.controller('principalCtrl', ['$scope', '$rootScope', '$timeout', function ($scope, $rootScope, $timeout) {
    $rootScope.Usuario = {};
    $scope.login = function () {
        $scope.principalMostrar = "\\frontend\\views\\system\\login.html";
        
        $timeout(function () {
            $('#divPrincipal').addClass("fondoNegro");
        }, 500);
    };

    $scope.menu = function () {
        $scope.CambiarConEfecto("\\frontend\\views\\system\\menu.html");

    };
    $scope.CambiarConEfecto = function (pagina) {
        $("#contenedorVentanas").addClass("pt-page-scaleDown");

        $timeout(function () {
            $("#contenedorVentanas").removeClass("pt-page-scaleDown");
            $("#contenedorVentanas").hide();
        }, 550);
        $timeout(function () {
            $("#contenedorVentanas").show();
            $("#contenedorVentanas").addClass("pt-page-scaleUp");
        }, 560);
        $timeout(function () {
            $scope.principalMostrar = pagina;
        }, 550);

    };


    (function () {
        if (localStorage.Usuario == {})
            $scope.login();
        else
            $scope.menu();
    })();


}]);