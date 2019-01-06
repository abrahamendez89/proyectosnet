app.controller('encuestasDetallesController', 
[
    '$scope'
    ,'$rootScope'
    ,'$timeout'
    ,'encuestasService'
    ,'$mdDialog'
    ,'sesionService'
    ,'$routeParams'
    ,function
    (
        $scope,
        $rootScope,
        $timeout,
        encuestasService,
        $mdDialog,
        sesionService,
        $routeParams
    ){
        $rootScope.$broadcast('cambioTitulo', 'Detalles de encuesta');
      
        var obtenerDetalles = function(idEncuesta){
            console.log(123);
            encuestasService.obtenerDetalles(idEncuesta)
            .then(function(response){
                if(response.data.exito){
                    $scope.data = response.data.data;
                    console.log(response.data);
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
        obtenerDetalles($routeParams.id_encuesta);


        $scope.formatDate = function(strdate) {
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
