'use strict';
module.exports = function(app, io) {
  //referenciando controladores
  
  var enviaEstadoController = require('./controllers/solicitudController');
 
  var sendMessage = function(evento, mensaje){

    io.sockets.emit(evento, mensaje);
    //io.emit(evento, mensaje);
  }

  app.route('/enviaEstado')
    .post(enviaEstadoController(sendMessage).EnviaEstado);   
  app.route('/consultaEstado')
    .post(enviaEstadoController(sendMessage).ConsultaEstado);   
};