var productosCtrl = angular.module('productosCtrl', []);
productosCtrl.controller('productosCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    (function () {

        mensaje.notificacion("Producto directiva!!", {_titulo:'Notificación'} ,  function () {
            //alert("hola callback");
        });

    })();
}]);