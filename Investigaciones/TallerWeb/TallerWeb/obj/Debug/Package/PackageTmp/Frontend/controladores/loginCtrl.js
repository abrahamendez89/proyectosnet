var loginCtrl = angular.module('loginCtrl', []);
loginCtrl.controller('loginCtrl', ['$scope', '$rootScope', 'loginSrv', function ($scope, $rootScope, loginSrv) {

    $scope.entrar = function () {

        loginSrv.Ingresar($scope.usuario).success(function (result) {

            $scope.$parent.menu();
            
        }).error(function (error) {
            alert(error);

        });
    };

}]);