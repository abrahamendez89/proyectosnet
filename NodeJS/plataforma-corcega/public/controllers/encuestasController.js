app.controller('encuestasController', 
[
    '$scope'
    ,'$rootScope'
    ,'$timeout'
    ,'encuestasService'
    ,'$mdDialog'
    ,'sesionService'
    ,function
    (
        $scope,
        $rootScope,
        $timeout,
        encuestasService,
        $mdDialog,
        sesionService
    ){
        $rootScope.$broadcast('cambioTitulo', 'Votaciones');
        
        $scope.mostrarLoad = true;

        var indice = 0;

        $scope.idInicio = 0;
        $scope.idFin = 0;
        $scope.data = [];

        /*
        var votacion = {
            "id" : 1, 
            "titulo" : "¿Deseas que entren los camiones?",
            "descripcion" : "Esta encuesta es para saber blablablabalbalbal",
            "opciones" : [{ "id":0, "titulo" : "Si", "votos": 100}, {"id":1,"titulo" : "No", "votos": 40}],
            "yaVoto" : 0
        };
        $scope.data.push(votacion);
        */

        if(sesionService.GetNumeroCalle() == undefined || sesionService.GetNumeroCalle() == null){
            $mdDialog.show(
                $mdDialog.alert()
                    .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                    .clickOutsideToClose(false)
                    .title('Encuestas.')
                    .textContent("Por favor inicia sesión nuevamente para actualizar la plataforma.")
                    //.ariaLabel('Alert Dialog Demo')
                    .ok('Aceptar')
                    //.targetEvent(ev)
                ).then(function(data){          
                });
        }

        var consultaEncuestas = function(idEncuestaMostrar){
            encuestasService.obtenerEncuestas({"id_usuario": sesionService.GetIdUsuario(), "numeroCalle": sesionService.GetNumeroCalle()})
            .then(function(response){
                $scope.mostrarLoad = false;
                if(response.data.exito){
                $scope.data = response.data.data;
                console.log($scope.data);
                if(idEncuestaMostrar != 0){
                    $scope.data.forEach(function(item, index){
                        if(item.id == idEncuestaMostrar)
                            item.yaVoto = 1;
                    });    
                }
                if($scope.data.length == 0){
                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Encuestas.')
                            .textContent("Por el momento no hay encuestas activas.")
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){    

                        });
                }
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
                $scope.mostrarLoad = false;
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
        consultaEncuestas(0);

        $scope.votar = function(idEncuesta, idOpcion){
            console.log(sesionService.GetNumeroCalle());
            encuestasService.votar({"id_usuario": sesionService.GetIdUsuario(), "id_encuesta": idEncuesta, "id_opcion": idOpcion, "numeroCalle": sesionService.GetNumeroCalle()})
            .then(function(response){
                if(response.data.exito){
                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                            .clickOutsideToClose(false)
                            .title('Encuestas.')
                            .textContent(response.data.mensaje)
                            //.ariaLabel('Alert Dialog Demo')
                            .ok('Aceptar')
                            //.targetEvent(ev)
                        ).then(function(data){   
                            consultaEncuestas(idEncuesta); 
                        });
                }
                else{ console.log(response.data);
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
        $scope.formatDate = function(strdate) {
            var date = new Date(strdate);

            var monthNames = [
                "Enero", "Febrero", "Marzo",
                "Abril", "Mayo", "Junio", "Julio",
                "Agosto", "Septiembre", "Octubre",
                "Noviembre", "Diciembre"
            ];
            var monthIndex = date.getMonth();
            var yyyy = date.getFullYear();
            var mm = date.getMonth() < 9 ? "0" + (date.getMonth() + 1) : (date.getMonth() + 1); // getMonth() is zero-based
            var dd  = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            var hh = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            var min = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            var ss = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
            return "".concat(dd).concat('-').concat(monthNames[monthIndex]).concat('-').concat(yyyy); //.concat(' ').concat(hh).concat(':').concat(min).concat(':').concat(ss);
        }

        $scope.formatDateTime = function(strdate) {
            var date = new Date(strdate);
            /*
            var monthNames = [
                "Enero", "Febrero", "Marzo",
                "Abril", "Mayo", "Junio", "Julio",
                "Agosto", "Septiembre", "Octubre",
                "Noviembre", "Diciembre"
            ];

            var day = date.getDate();
            var monthIndex = date.getMonth();
            var year = date.getFullYear();

            var hora = date.getHours();

            return day + ' ' + monthNames[monthIndex] + ' ' + year;
            */


            var monthNames = [
                "Enero", "Febrero", "Marzo",
                "Abril", "Mayo", "Junio", "Julio",
                "Agosto", "Septiembre", "Octubre",
                "Noviembre", "Diciembre"
            ];
            var monthIndex = date.getMonth();
            var yyyy = date.getFullYear();
            var mm = date.getMonth() < 9 ? "0" + (date.getMonth() + 1) : (date.getMonth() + 1); // getMonth() is zero-based
            var dd  = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            var hh = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            var min = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            var ss = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
            return "".concat(dd).concat('-').concat(monthNames[monthIndex]).concat('-').concat(yyyy).concat(' ').concat(hh).concat(':').concat(min).concat(':').concat(ss);
        }


}]);
