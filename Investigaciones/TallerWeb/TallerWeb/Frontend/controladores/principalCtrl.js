var principalCtrl = angular.module('principalCtrl', ['loginCtrl', 'menuCtrl', 'catalogoPruebaCtrl']);
principalCtrl.controller('principalCtrl', ['$scope', '$rootScope', '$timeout', function ($scope, $rootScope, $timeout) {
    
    $scope.login = function () {
        $scope.principalMostrar = "\\frontend\\vistasAdmin\\Login.html";
        
        $timeout(function () {
            $('#divPrincipal').addClass("fondoNegro");
        }, 500);
    };
    
    $scope.menu = function () {
        $scope.CambiarConEfecto("\\frontend\\vistasAdmin\\Menu.html");
        //$scope.principalMostrar = "\\frontend\\vistasAdmin\\Menu.html";
       
    };
    $scope.CambiarConEfecto = function (pagina) {
        $("#principales").addClass("pt-page-scaleDown");

        $timeout(function(){
            $("#principales").removeClass("pt-page-scaleDown");
            $("#principales").hide();
        }, 550);
        $timeout(function () {
            $("#principales").show();
            $("#principales").addClass("pt-page-scaleUp");
        }, 560);
        $timeout(function () {
            $scope.principalMostrar = pagina;
        }, 550);

    };

    
    ($scope.login)();
}]);