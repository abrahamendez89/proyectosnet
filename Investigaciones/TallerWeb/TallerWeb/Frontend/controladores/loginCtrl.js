var loginCtrl = angular.module('loginCtrl', []);
loginCtrl.controller('loginCtrl', ['$scope', '$rootScope', 'loginSrv', function ($scope, $rootScope, loginSrv) {

    $scope.entrar = function () {

        loginSrv.Ingresar($scope.usuario).success(function (result) {

            if (result) {

                $scope.$parent.menu();
            }
            else {
                mensaje.notificacion("Usuario o contraseña incorrectos", { _titulo: "Login incorrecto",_cerrarAutomatico:false });
            }
        }).error(function (error) {
            alert(error);

        });
    };

}]);