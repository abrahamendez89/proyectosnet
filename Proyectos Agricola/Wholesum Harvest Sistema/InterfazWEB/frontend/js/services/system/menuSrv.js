var menuSrv = angular.module('menuSrv', []);
menuSrv.factory('menuSrv', ['$http', function ($http) {
    return {
        Ingresar: function (usuario) {
            return $http.post('/Usuario/Login', usuario);
        }
    };


}]);