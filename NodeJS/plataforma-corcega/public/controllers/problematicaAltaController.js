app.controller('problematicaAltaController', 
[
    '$scope'
    ,'$mdDialog'
    ,'$rootScope'
    ,function
    (
        $scope,
        $mdDialog,
        $rootScope
    ){

        $scope.imagenes = [];
        $rootScope.$broadcast('cambioTitulo', 'Registrar problemática');
        
        $scope.View = function(){
            console.log($scope.imagenes);
            $scope.imagenes.forEach(function(item, index){
                console.log(item.compressed.dataURL);
            });
        }

        $scope.updateImageArray = function(image) { 

            if($scope.imagenes.length == 4){
                $mdDialog.show(
                    $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#contenedorPrincipal')))
                        .clickOutsideToClose(false)
                        .title('Atención')
                        .textContent('Solo es posible agregar un máximo de 4 imagenes.')
                        //.ariaLabel('Alert Dialog Demo')
                        .ok('Aceptar')
                        //.targetEvent(ev)
                    ).then(function(data){              
                    });
            }
            else{
                $scope.imagenes.push(image);
            }
        };
}]);
