var principalCtrl = angular.module('principalCtrl', ['loginCtrl', 'menuCtrl', 'catalogoPruebaCtrl']);
principalCtrl.controller('principalCtrl', ['$scope', '$rootScope', '$timeout', function ($scope, $rootScope, $timeout) {
    
    $scope.login = function () {
        $scope.principalMostrar = "\\frontend\\vistasAdmin\\Login.html";

    };
    
    $scope.menu = function () {
        $scope.EfectoCambio();
        //$scope.principalMostrar = "\\frontend\\vistasAdmin\\Menu.html";
       
    };
    $scope.EfectoCambio = function () {
        $("#principales").addClass("pt-page-rotateCarouselLeftOut");

        $timeout(function(){
            
            $("#principales").removeClass("pt-page-rotateCarouselLeftOut");
            $("#principales").hide();
        }, 550);
        $timeout(function () {
            //$("#ventana").empty();
            $("#principales").show();
            $("#principales").addClass("pt-page-rotateCarouselLeftIn");
            
            
            
        }, 560);
        $timeout(function () {
            //$("#divPrincipal").addClass("OcultarVentanasPrincipal");
            //("#divPrincipal").addClass("fadeInRight");
            //$("#ventana").hide();
            $scope.principalMostrar = "\\frontend\\vistasAdmin\\Menu.html";
        }, 550);

    };

    
    ($scope.login)();
}]);