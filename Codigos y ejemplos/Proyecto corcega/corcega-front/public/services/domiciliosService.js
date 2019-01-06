app.service("domiciliosService", [
    '$http',
    'globalsService',
    function($http, globalsService) {

        var headers = {
				'Access-Control-Allow-Origin' : '*',
				'Access-Control-Allow-Methods' : 'POST, GET, OPTIONS, PUT',
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			};

        //funciones privadas
        var getCalles = function() {
            return $http({
                    method: 'GET',
                    headers: headers,
                    url: globalsService.serverRest + '/calles'
                })
                .then(function(response) {
                    console.log(response.data);
                    return response;
                });

        };
        var getNumeros = function(obj) {
            return $http({
                    method: 'GET',
                    headers: headers,
                    url: globalsService.serverRest + '/numerosPorCalle/'+obj
                })
                .then(function(response) {
                    console.log(response.data);
                    return response;
                });

        };

        //funciones publicas
        return {
            getCalles: getCalles,
            getNumeros: getNumeros
        };
    }
]);