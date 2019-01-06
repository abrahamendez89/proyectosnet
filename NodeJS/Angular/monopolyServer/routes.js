'use strict';
module.exports = function(app, io) {
  //referenciando controladores
  
  var solicitudController = require('./controllers/solicitudController');
 
  var sendMessage = function(evento, mensaje){

    io.sockets.emit(evento, mensaje);
    //io.emit(evento, mensaje);
  }

  app.route('/solicitud')
    .post(solicitudController(sendMessage).guardaSolicitud);  


  app.route('/api/huella')
    .get(solicitudController(sendMessage).checadorFail);  
};