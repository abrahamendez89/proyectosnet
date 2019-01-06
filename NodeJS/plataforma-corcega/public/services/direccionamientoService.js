app.service("direccionamientoService",[
    '$location'
    ,function($location) {


        var IrA = function(path){
             $location.path(path);
        };

        return {
        IrA : IrA
    };

    }]);