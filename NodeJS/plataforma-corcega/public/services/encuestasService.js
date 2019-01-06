app.service("encuestasService", [
    '$http',
    'globalsService',
    function($http, globalsService) {

        //funciones privadas
        var obtenerEncuestas = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/encuestas',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        var votar = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/encuestasVotar',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        var obtenerDetalles = function(id) {
            return $http({
                    method: 'GET',
                    url: globalsService.serverRest + '/encuestasDetalles/'+id,
                })
                .then(function(response) {
                    return response;
                });

        };
        
        //funciones publicas
        return {
            obtenerEncuestas: obtenerEncuestas,
            votar: votar,
            obtenerDetalles: obtenerDetalles
        };
    }
]);