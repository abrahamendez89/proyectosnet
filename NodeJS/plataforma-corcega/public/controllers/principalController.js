app.controller('principalController', 
[
    '$scope',
    '$rootScope'
    ,function
    (
        $scope,
        $rootScope
    ){
        $rootScope.$broadcast('cambioTitulo', 'Plataforma Corcega');
}]);






