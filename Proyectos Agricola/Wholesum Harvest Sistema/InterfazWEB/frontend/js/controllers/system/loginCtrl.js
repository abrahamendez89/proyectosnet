var loginCtrl = angular.module('loginCtrl', []);
loginCtrl.controller('loginCtrl', ['$scope', '$rootScope', 'loginSrv', function ($scope, $rootScope, loginSrv) {
    
    $scope.entrar = function () {

        loginSrv.Ingresar($scope.usuario).success(function (result) {
            //hasta aqui todo bien, se pueden ver los datos perfectamente
            if (!result.FueError) {
                //$rootScope.Usuario = result.Datos; //aqui tampco hay bronca
                localStorage.Usuario = JSON.stringify(result.Datos);
                $scope.$parent.menu();
            }
            else {
                mensaje.notificacion(result.Descripcion, { _titulo: "Login incorrecto", _cerrarAutomatico: false });
            }
        }).error(function (error) {
            alert(error);

        });
    };

}]);