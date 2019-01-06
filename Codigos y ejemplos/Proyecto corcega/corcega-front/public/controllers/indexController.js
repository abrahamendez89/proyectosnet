app.controller('indexController', 
[
    '$scope',
    '$location',
    '$timeout', 
    '$mdSidenav',
    '$rootScope',
    'sesionService'
    ,function
    (
        $scope,
        $location,
        $timeout, 
        $mdSidenav,
        $rootScope,
        sesionService
    ){

   

    $scope.go = function (path) {
        $location.path( path );
        $scope.toggleLeft();
        console.log('go: '+path);
    };

     $scope.goto = function (path) {
        $location.path( path );
        console.log('goto: '+path);
    };

    $scope.cerrarSesion = function(){
        $rootScope.inicioSesion = false;
        sesionService.SetUsuario(undefined);
        $rootScope.usuarioSession = undefined;
        $location.path( '/login' );
    };

    
    $scope.NombreApp = "Plataforma Corcega";


  $scope.$on('cambioTitulo', function($event, message){
    $scope.NombreApp = message;
  });
$scope.$on('asignaDatosUser', function($event, message){
    $scope.nombreUser = message.nombre;
    $scope.fotoPerfil = message.fotoPerfil;
  });
$scope.$on('goto', function($event, message){
     $scope.goto(message);
  });

  $scope.$on('actualizaDatosUsuario', function($event, message){
    $rootScope.usuarioSession = sesionService.GetUsuario();
    $rootScope.usuarioIdSession = sesionService.GetIdUsuario();
    $rootScope.usuarioFotoPerfil = sesionService.GetFotoPerfil();
    $rootScope.numeroCalle = sesionService.GetNumeroCalle();

    $scope.nombreUser = $rootScope.usuarioSession;
    $scope.fotoPerfil =  $rootScope.usuarioFotoPerfil;
  });


    if(sesionService.EstaConectado()){
            $rootScope.usuarioSession = sesionService.GetUsuario();
            $rootScope.usuarioIdSession = sesionService.GetIdUsuario();
            $rootScope.usuarioFotoPerfil = sesionService.GetFotoPerfil();
            $rootScope.numeroCalle = sesionService.GetNumeroCalle();

            $rootScope.inicioSesion = true;
            $scope.nombreUser = $rootScope.usuarioSession;
            $scope.fotoPerfil =  $rootScope.usuarioFotoPerfil;
        }else{
            $rootScope.inicioSesion = false;
        }


    //$rootScope.compartida = "Plataforma Corcega";

    //$scope.NombreApp = $rootScope.compartida;


    $scope.toggleLeft = buildToggler('left');
    $scope.toggleRight = buildToggler('right');

    function buildToggler(componentId) {
      return function() {
        $mdSidenav(componentId).toggle();
      };
    }
}]);