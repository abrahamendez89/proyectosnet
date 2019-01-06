app.service("sesionService",[
    '$localStorage'
    ,function($localStorage) {


        var EstaConectado = function(){
             if($localStorage.usuario)
                return true;
             else
                return false;
        };

        var GetUsuario = function(){
            return $localStorage.usuario;
        };

        var SetUsuario = function(usuario){
            $localStorage.usuario = usuario;
        };

        var GetIdUsuario = function(){
            return $localStorage.idUsuario;
        };

        var SetIdUsuario = function(idUsuario){
            $localStorage.idUsuario = idUsuario;
        };
        
        var SetFotoPerfil = function(foto){
            $localStorage.fotoPerfil = foto;
        };

        var GetFotoPerfil = function(){
            return $localStorage.fotoPerfil;
        };

        var SetNumeroCalle = function(numeroCalle){
            $localStorage.numeroCalle = numeroCalle;
        };

        var GetNumeroCalle = function(){
            return $localStorage.numeroCalle;
        };

        return {
            EstaConectado : EstaConectado,
            GetUsuario : GetUsuario,
            SetUsuario : SetUsuario,
            GetIdUsuario : GetIdUsuario,
            SetIdUsuario : SetIdUsuario,
            SetFotoPerfil : SetFotoPerfil,
            GetFotoPerfil : GetFotoPerfil,
            SetNumeroCalle : SetNumeroCalle,
            GetNumeroCalle : GetNumeroCalle
        };

    }]);