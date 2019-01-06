//var app_login = angular.module('app_login', ['servicioLogin','loginController', 'usuarioBienvenidaController']); //se pueden llamar diferente el var y el valor
//var app_menu = angular.module('app_menu', ['servicioCatalogoPrueba', 'rutas', 'menuController', 'anGrid', 'directivaProducto'
//    , 'productosController', 'catalogoPruebaController']); //se pueden llamar diferente el var y el valor


var app_principal = angular.module('app_principal', ['loginSrv', 'catalogoPruebaSrv',
                            
                            'rutas', 'principalCtrl', 'loginCtrl', 'menuCtrl', 'productosCtrl', 'catalogoPruebaCtrl',
                            'directivaProducto']);