app.controller('problematicaForoDetallesController', 
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
        $rootScope.$broadcast('cambioTitulo', 'Detalles de la problemática');
        
        $scope.foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkqSMDdWQdttqzoFF66yOuBwo5rmFGr3TmdZrEWxRqOmw4_UGi";
        var imagePath = $scope.foto;
        $scope.fotos = [];
        for(var i = 0; i < 10; i++){
            $scope.fotos.push($scope.foto);
        }
        $scope.messages = [
          {
            face : imagePath,
            what: 'José perez',
            who: 'Costa Palermo 544',
            when: '2017-10-04 01:38',
            notes: " Si tambien considero que estan pasando a altas velocidades."
          },
          {
            face : imagePath,
            what: 'María Martinez',
            who: 'Costa Corsa 644',
            when: '2017-10-03 12:38',
            notes: " Es un peligro para nuestros hijos, totalmente de acuerdo."
          },
          {
            face : imagePath,
            what: 'Martin Nevarez',
            who: 'Avenida Corcega 6444',
            when: '2017-10-03 12:40',
            notes: " Propongo que se pongan unos topes!!!."
          },
          {
            face : imagePath,
            what: 'Laura Gomez',
            who: 'Costa Capoterra 518',
            when: '2017-10-03 12:55',
            notes: " Deberiamos ser consientes las personas que conducimos por la avenida."
          }
        ];
}]);
