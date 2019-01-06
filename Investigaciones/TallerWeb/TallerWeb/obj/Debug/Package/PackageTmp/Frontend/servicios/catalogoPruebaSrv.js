var catalogoPruebaSrv = angular.module('catalogoPruebaSrv', []);
catalogoPruebaSrv.factory('catalogoPruebaSrv', ['$http', function ($http) {
    return {
        Todos: function () {
            return $http.get('/CatalogoPrueba/Todos');
        }
    };


}]);