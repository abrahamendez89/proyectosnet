app.controller('registroController', [
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
        ];


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

   $scope.registrarUser = function(ev) {
    

    var month = $scope.user.fechaNac.getUTCMonth() + 1; //months from 1-12
    var day = $scope.user.fechaNac.getUTCDate();
    var year = $scope.user.fechaNac.getUTCFullYear();

    $scope.user.fechaNacFor = year + "/" + month + "/" + day;

    //console.log($scope.user);
    usuariosService.registrar($scope.user)
    .then(function(response) {

        if(response.data.exito)
        {
            $mdDialog.show(
            $mdDialog.alert()
                .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                .clickOutsideToClose(false)
                .title('Tus datos se han registrado correctamente.')
                .textContent('Llegará a tu correo registrado los datos que ingresaste.')
                //.ariaLabel('Alert Dialog Demo')
                .ok('Aceptar')
                .targetEvent(ev)
            ).then(function(data){
                //console.log(data);
                $rootScope.$broadcast('goto', '/login');
                $rootScope.$broadcast('insertaNumeroCel', $scope.celular);                
            });
        }
        else
        {
            $mdDialog.show(
            $mdDialog.alert()
                .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                .clickOutsideToClose(false)
                .title('Error de registro.')
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
  $scope.user = {};
  $scope.user.fotoPerfil = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjzeMLlmGX21FTbIVH-kgAJQT0TLp80Cvjf2PIYWSSX8Er7pfC';
  
  $scope.updateImageArray = function(image) { 
      $scope.user.fotoPerfil = image.compressed.dataURL;
  };


}]);
        

   