app.controller('personaController', [
    '$scope',
    '$rootScope',
    'personaService',
    function(
        $scope,
        $rootScope,
        personaService
    ) {

        personaService.personasGetAll()
            .then(function(response) {

                $scope.personas = response.data;

            }, function(error) {
                alert('Error de conexión al servicio.');
            });
        /*
        var obj = {
            "Nombres":"Esto es desde la web",
            "Apellidos": "web web",
            "Edad": 2
        };
        empleadoService.empleadosPost(obj)
        .then(function(response){
            $scope.empleados = response.data;
        },function(error){
            alert('Error de conexión al servicio.');
        });*/


        $scope.cambiar = function(){
            
            $rootScope.inicio = !$rootScope.inicio;

        }





    }
]);