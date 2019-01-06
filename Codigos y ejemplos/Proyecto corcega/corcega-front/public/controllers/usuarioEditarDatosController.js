app.controller('usuarioEditarDatosController', [
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

        $scope.user = {};

        $rootScope.$broadcast('cambioTitulo', 'Editar mis datos');

        

        $scope.updateImageArray = function(image) { 
            $scope.fotoPerfil = image.compressed.dataURL;
        };


        usuariosService.cargarDatosEdicion({"id": sesionService.GetIdUsuario()})
        .then(function(response){
            console.log(response);
            if(response.data.exito){
               $scope.fotoPerfil = response.data.obj.fotoPerfil;
               $scope.user.email = response.data.obj.email;
               $scope.user.preguntaSecreta = response.data.obj.preguntaSecreta;
               $scope.user.respuestaSecreta = response.data.obj.respuestaSecreta;
            }
            else{
                $mdDialog.show(
                    $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                        .clickOutsideToClose(false)
                        .title('Error.')
                        .textContent(response.data.mensaje)
                        //.ariaLabel('Alert Dialog Demo')
                        .ok('Aceptar')
                        //.targetEvent(ev)
                    ).then(function(data){           
                    });
            }
        }, function(error){
            $mdDialog.show(
                $mdDialog.alert()
                    .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                    .clickOutsideToClose(false)
                    .title('Error.')
                    .textContent(error)
                    //.ariaLabel('Alert Dialog Demo')
                    .ok('Aceptar')
                    //.targetEvent(ev)
                ).then(function(data){           
                });
        });


        $scope.ActualizarFoto = function(){
            
            usuariosService.actualizarFoto({"id": sesionService.GetIdUsuario(), "fotoPerfil": $scope.fotoPerfil})
            .then(function(response){
                if(response.data.exito){

                    sesionService.SetFotoPerfil($scope.fotoPerfil);

                    $rootScope.$broadcast('actualizaDatosUsuario', '');

                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Exito.')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){           
                        });
                }
                else{
                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Error.')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){           
                        });
                }
            }, function(error){
                $mdDialog.show(
                    $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                        .clickOutsideToClose(false)
                        .title('Error.')
                        .textContent(error)
                        //.ariaLabel('Alert Dialog Demo')
                        .ok('Aceptar')
                        //.targetEvent(ev)
                    ).then(function(data){           
                    });
            });
            
        };


        $scope.ActualizarDatos = function(){
            
            usuariosService.actualizarDatos({"id": sesionService.GetIdUsuario(), "email": $scope.user.email, "preguntaSecreta": $scope.user.preguntaSecreta, "respuestaSecreta": $scope.user.respuestaSecreta})
            .then(function(response){
                if(response.data.exito){

                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Exito.')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){           
                        });
                }
                else{
                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Error.')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){           
                        });
                }
            }, function(error){
                $mdDialog.show(
                    $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                        .clickOutsideToClose(false)
                        .title('Error.')
                        .textContent(error)
                        //.ariaLabel('Alert Dialog Demo')
                        .ok('Aceptar')
                        //.targetEvent(ev)
                    ).then(function(data){           
                    });
            });
            
        };

        $scope.ActualizarContrasena = function(){
            usuariosService.actualizarContrasena({"id": sesionService.GetIdUsuario(), "contrasena": $scope.user.contrasena, "contrasenaNueva": $scope.user.contrasenaNueva})
            .then(function(response){
                if(response.data.exito){

                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Exito.')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){           
                        });
                }
                else{
                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Error.')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){           
                        });
                }
            }, function(error){
                $mdDialog.show(
                    $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                        .clickOutsideToClose(false)
                        .title('Error.')
                        .textContent(error)
                        //.ariaLabel('Alert Dialog Demo')
                        .ok('Aceptar')
                        //.targetEvent(ev)
                    ).then(function(data){           
                    });
            });
            
        };

        //consultando los datos del usuario


}]);
        