var loginSrv = angular.module('loginSrv', []);
loginSrv.factory('loginSrv', ['$http', function ($http) {
    return {
        Ingresar: function (usuario) {
            return $http.post('/Usuario/Login',usuario);
        }
    };


}]);