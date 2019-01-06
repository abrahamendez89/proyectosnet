var rutas = angular.module('rutas', ['ui.router']);
rutas.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/");   //significa que si ponen una ruta q no existe, envia al home de la aplicacion
    //$stateProvider
    //    .state('productos', {
    //        url: "/productos",
    //        templateUrl: "/Frontend/vistas/productos.html",
    //        controller: "productosController"
    //    })
    //    .state('catalogoPrueba', {
    //        url: "/catalogoPrueba",
    //        templateUrl: "/Frontend/vistas/catalogoPrueba.html",
    //        controller: ""
    //    });



});