app.controller('recuperarContraController', [
    '$scope',
    '$window',
    '$location',
    '$rootScope',
    'sesionService',
     '$mdDialog',
     'usuariosService',
     'domiciliosService',
    function(
        $scope,
        $window,
        $location,
        $rootScope,
        sesionService,
         $mdDialog,
         usuariosService,
         domiciliosService
    ) {
        $scope.preguntasSecretas = 
        [
            {
                "descripcion" : '¿Cuál es tu color favorito?'
            }
            ,{
                "descripcion" : '¿Cuál es el nombre de tu mascota?'
            }
            ,{
                "descripcion" : '¿Cuál es tu comida favorita?'
            }
            ,{
                "descripcion" : '¿Qué modelo es tu carro?'
            }
            ,{
                "descripcion" : '¿Cuál es tu pelicula favorita?'
            }
        ]


        domiciliosService.getCalles()
        .then(function(result){
            $scope.calles = result.data.data;
        },function(error){

        });

        $rootScope.$broadcast('cambioTitulo', 'Nuevo Registro');

        $scope.getNumeros = function(){
            $scope.user.idCasa = undefined;
             domiciliosService.getNumeros($scope.user.idCalle)
            .then(function(result){
                $scope.casas = result.data.data;
            },function(error){

            });
        };

   $scope.recuperarContrasena = function(ev) {
    
    //console.log($scope.user);
    usuariosService.recuperarContra($scope.user)
    .then(function(response) {

        if(response.data.exito)
        {
            $mdDialog.show(
            $mdDialog.alert()
                .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                .clickOutsideToClose(false)
                .title('Datos enviados correctamente.')
                .textContent('Llegará a tu correo la contraseña que registraste.')
                //.ariaLabel('Alert Dialog Demo')
                .ok('Aceptar')
                .targetEvent(ev)
            ).then(function(data){
                //console.log(data);
                $rootScope.$broadcast('goto', '/login');            
            });
        }
        else
        {
            $mdDialog.show(
            $mdDialog.alert()
                .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                .clickOutsideToClose(false)
                .title('Error al recuperar contraseña.')
                .textContent(response.data.mensaje)
                //.ariaLabel('Alert Dialog Demo')
                .ok('Aceptar')
                .targetEvent(ev)
            ).then(function(data){             
            });
        }
        

    }, function(error) {
        console.log(error);
        alert('Error de conexión al servicio.');
    });
  };
}]);
        

   