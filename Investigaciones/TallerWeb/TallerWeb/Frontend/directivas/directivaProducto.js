var directivaProducto = angular.module('directivaProducto', []);
directivaProducto.directive('producto', function () {
    return {
        restrict: 'E',  // E = etiqueta , A para atributo    : nos indica el tipo de directiva
        templateUrl: '/Frontend/directivas/directivaProducto.html',
        controller: function ($scope) {
            $scope.holaDirectiva = function () {
                alert('hola');

            };
        }, controllerAs: 'productoDirectivaController'
    };
});