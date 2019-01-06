var app = angular.module("app", ['ngRoute', 'ui.bootstrap', 'ngMaterial', 'ngStorage', 'ngImageCompress']);

app.config(function($routeProvider, $locationProvider) {
    //$locationProvider.html5Mode({enabled: true, requireBase: false});
    $routeProvider
        .when('/empleados', {
            templateUrl: 'views/empleadosView.html',
            controller: 'empleadoController'
        })
        .when('/personas', {
            templateUrl: 'views/personaView.html',
            controller: 'personaController'
        })
        .when('/principal', {
            templateUrl: 'views/principalView.html',
            controller: 'principalController'
        })
        .when('/registro', {
            templateUrl: 'views/registroView.html',
            controller: 'registroController'
        })
        .when('/recuperarcontra', {
            templateUrl: 'views/recuperarContraView.html',
            controller: 'recuperarContraController'
        })
        .when('/index', {
            templateUrl: 'index.html',
            controller: 'indexController'
        })
        .when('/login', {
            templateUrl: 'views/loginView.html',
            controller: 'loginController'
        })
        .when('/problematicaAlta', {
            templateUrl: 'views/problematicaAltaView.html',
            controller: 'problematicaAltaController'
        })
        .when('/problematicaForo', {
            templateUrl: 'views/problematicaForoView.html',
            controller: 'problematicaForoController'
        })
        .when('/problematicaForoDetalles', {
            templateUrl: 'views/problematicaForoDetallesView.html',
            controller: 'problematicaForoDetallesController'
        })
        .when('/usuarioEditarDatos', {
            templateUrl: 'views/usuarioEditarDatosView.html',
            controller: 'usuarioEditarDatosController'
        })
        .when('/encuestas', {
            templateUrl: 'views/encuestasView.html',
            controller: 'encuestasController'
        })
        .when('/encuestasDetalles/:id_encuesta', {
            templateUrl: 'views/encuestasDetallesView.html',
            controller: 'encuestasDetallesController'
        })
        .when('/', {
            redirectTo: '/login'
        })
        .otherwise({
            redirectTo: '/login'
        });
});

app.run(function($rootScope, $location, sesionService, $anchorScroll, globalsService){
    $anchorScroll.yOffset = 50;
    $rootScope.$on('$routeChangeStart',function(event, next, current){

        if(sesionService.EstaConectado()){
            $rootScope.usuarioSession = sesionService.GetUsuario();
            $rootScope.inicioSesion = true;

             $rootScope.$broadcast('asignaNombreUser', $rootScope.usuarioSession);
        
        }
        
        if($rootScope.inicioSesion == undefined)
            $rootScope.inicioSesion = false;
        console.log('Inicio de sesion: '+$rootScope.inicioSesion);
        if((next.$$route.originalPath == '/registro' || next.$$route.originalPath == '/recuperarcontra') && !$rootScope.inicioSesion){
                //$location.path("/principal");
        }
        else
        {
            if(!$rootScope.inicioSesion){
                if(next.$$route.originalPath == '/login'){
                }else{
                    console.log('4');
                    if(!globalsService.enDesarrollo)
                        $location.path("/login");
                    //se redireciona a login para autenticar
                }
            }else{
                console.log('2');
                if(next.$$route.originalPath == '/login'){
                    $location.path("/principal");
                    console.log('Ya esta logueado, redige a principal.');
                }
            }
        }
    });
});

app.config(function($mdThemingProvider) {
  $mdThemingProvider.theme('default')
    .primaryPalette('green')
    .accentPalette('orange');
});