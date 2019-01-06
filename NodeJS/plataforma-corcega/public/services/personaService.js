app.service("personaService", [
    '$http',
    'globalsService',
    function($http, globalsService) {

        //funciones privadas
        var personasGetAll = function() {
            return $http({
                    method: 'GET',
                    url: globalsService.serverRest + '/persona'
                })
                .then(function(response) {
                    console.log(response.data);
                    return response;
                });

        };
        var empleadosPost = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/persona',
                    data: obj
                })
                .then(function(response) {
                    console.log(response.data);
                    return response;
                });

        };

        //funciones publicas
        return {
            personasGetAll: personasGetAll,
            empleadosPost: empleadosPost
        };
    }
]);