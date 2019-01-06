app.service("empleadoService",[
    '$http'
    ,function($http) {
    
    //funciones privadas
    var empleadosGetAll = function(){
        return $http({
            method: 'GET',
            url: 'http://localhost:3000/empleados'
        })
        .then(function(response) {  
            console.log(response.data);
            return response;  
        });  
    
    };
    var empleadosPost = function(obj){
        return $http({
            method: 'POST',
            url: 'http://localhost:3000/empleados',
            data: obj
        })
        .then(function(response) {  
            console.log(response.data);
            return response;  
        });  
    
    };

    //funciones publicas
    return {
        empleadosGetAll : empleadosGetAll,
        empleadosPost: empleadosPost
    };
}]);