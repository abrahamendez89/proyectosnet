app.service("usuariosService", [
    '$http',
    'globalsService',
    function($http, globalsService) {

        //funciones privadas
        var login = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/usuarioLogin',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };
        var registrar = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/usuarioRegistra',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        var recuperarContra = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/usuarioRecuperaContra',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        var actualizarFoto = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/usuarioActualizaFoto',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        var actualizarDatos = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/usuarioActualizaDatos',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        var actualizarContrasena = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/usuarioActualizaContrasena',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        var cargarDatosEdicion = function(obj) {
            return $http({
                    method: 'POST',
                    url: globalsService.serverRest + '/usuarioDatosEdicion',
                    data: obj
                })
                .then(function(response) {
                    return response;
                });

        };

        //funciones publicas
        return {
            login: login,
            registrar: registrar,
            recuperarContra: recuperarContra,
            actualizarFoto: actualizarFoto,
            actualizarDatos: actualizarDatos,
            actualizarContrasena: actualizarContrasena,
            cargarDatosEdicion: cargarDatosEdicion
        };
    }
]);