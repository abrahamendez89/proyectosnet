app.controller('loginController', [
    '$scope',
    '$window',
    '$location',
    '$rootScope',
    '$mdDialog',
    'sesionService',
    'usuariosService',
    function(
        $scope,
        $window,
        $location,
        $rootScope,
        $mdDialog,
        sesionService,
        usuariosService
    ) {
         
        $scope.entrar = function(ev){
            console.log($scope.user);
            usuariosService.login($scope.user)
            .then(function(response) {
                console.log(response.data.exito);
                if(response.data.exito)
                {
                    console.log(response.data);
                    sesionService.SetIdUsuario(response.data.id);
                    sesionService.SetUsuario(response.data.nombre);
                    sesionService.SetFotoPerfil(response.data.fotoPerfil);
                    sesionService.SetNumeroCalle(response.data.numeroCalle);
                    
                    $rootScope.usuarioSession = sesionService.GetUsuario();
                    $rootScope.usuarioIdSession = sesionService.GetIdUsuario();
                    $rootScope.usuarioFotoPerfil = sesionService.GetFotoPerfil();
                    $rootScope.numeroCalle = sesionService.GetNumeroCalle();

                    $location.path( '/principal' );
                    $rootScope.inicioSesion = true;

                    var obj = {
                        "nombre": response.data.nombre,
                        "fotoPerfil": response.data.fotoPerfil
                    };

                    $rootScope.$broadcast('asignaDatosUser', obj);
                }
                else
                {
                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Mensaje')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            .targetEvent(ev)
                        ).then(function(data){
                            
                        });
                }
            }, function(error) {
                console.log(error);
                $rootScope.inicioSesion = false;
            });
        };


        $rootScope.$broadcast('cambioTitulo', 'Plataforma Corcega');
        
         $rootScope.$on('insertaNumeroCel', function($event, message){
            $scope.celular = message;
        });

        /*
        if(sesionService.EstaConectado()){
            $rootScope.usuarioSession = sesionService.GetUsuario();
            $rootScope.inicioSesion = true;
            $location.path( '/principal' );
        }

        $rootScope.inicioSesion = false;
        */

        
       /* $scope.go = function (path) {
            $location.path( path );
        };

        /*
        personaService.personasGetAll()
            .then(function(response) {

                $scope.personas = response.data;

            }, function(error) {
                alert('Error de conexión al servicio.');
            });
        
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
    }
]);