app.controller('empleadoController', 
[
    '$scope',
    'empleadoService'
    ,function
    (
        $scope,
        empleadoService
    ){

    empleadoService.empleadosGetAll()
    .then(function(response){
        $scope.empleados = response.data;

/*
        $scope.totalItems = $scope.empleados.length;
        $scope.currentPage = 1;
        $scope.itemsPerPage = 5;

        $scope.$watch("currentPage", function() {
            setPagingData($scope.currentPage);
        });

        function setPagingData(page) {
            var pagedData = $scope.empleados.slice(
            (page - 1) * $scope.itemsPerPage,
            page * $scope.itemsPerPage
            );
            $scope.aCandidates = pagedData;
        }*/

        $scope.aCandidates = $scope.empleados;

    },function(error){
        alert('Error de conexión al servicio.');
    });
    /*
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





    $scope.user = {
      title: 'Developer',
      email: 'ipsum@lorem.com',
      firstName: '',
      lastName: '',
      company: 'Google',
      address: '1600 Amphitheatre Pkwy',
      city: 'Mountain View',
      state: 'CA',
      biography: 'Loves kittens, snowboarding, and can type at 130 WPM.\n\nAnd rumor has it she bouldered up Castle Craig!',
      postalCode: '94043'
    };

    $scope.states = ('AL AK AZ AR CA CO CT DE FL GA HI ID IL IN IA KS KY LA ME MD MA MI MN MS ' +
    'MO MT NE NV NH NJ NM NY NC ND OH OK OR PA RI SC SD TN TX UT VT VA WA WV WI ' +
    'WY').split(' ').map(function(state) {
        return {abbrev: state};
      });



}]);