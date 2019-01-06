app.controller('problematicaForoController', 
[
    '$scope'
    ,'$rootScope'
    ,'$timeout'
    ,function
    (
        $scope,
        $rootScope,
        $timeout
    ){
        $rootScope.$broadcast('cambioTitulo', 'Foro de problemáticas');
        

        var indice = 0;

        $scope.idInicio = 0;
        $scope.idFin = 0;
        $scope.data = [];

        console.log("entroooo");
        
        $scope.VerMas = function(){
            //$scope.data = [];

            var limite = indice + 5;
            console.log(limite);
            //indice += 5;
            
            for(; indice < limite; indice++){
                console.log("algo");
                $scope.data.push({"Titulo": "titulo" + indice, "Detalles": "Detalles" + indice});
            }
            
        };
        $scope.VerMas();
        

        $scope.foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkqSMDdWQdttqzoFF66yOuBwo5rmFGr3TmdZrEWxRqOmw4_UGi";

}]);
