var catalogoPruebaCtrl = angular.module('catalogoPruebaCtrl', []);
catalogoPruebaCtrl.controller('catalogoPruebaCtrl', ['$scope', '$rootScope', 'catalogoPruebaSrv', function ($scope, $rootScope, catalogoPruebaSrv) {

    $scope.catalogoPruebasTodos = {};
    $scope.catalogoPruebasTodos.todos = [];

    this.CargarTodos = function () {
        

        catalogoPruebaSrv.Todos().success(function (result) {

            if (result) {
                //accion que hara despues de llamar al controller en c#

                

                $scope.catalogoPruebasTodos.todos = result;
                
                mensaje.notificacion("Catálogo prueba!!", { _titulo: 'Notificación' }, function () {
                    //alert("hola callback");
                });

            };

        }).error(function (error) {
            console.log(error);
        });


    };


    (this.CargarTodos)();

}]);