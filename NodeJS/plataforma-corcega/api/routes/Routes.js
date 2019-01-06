'use strict';
module.exports = function(app) {
  /*var empleadosController = require('../controllers/empleadosController');

  app.route('/empleados')
    .get(empleadosController.GetAll)
    .post(empleadosController.Post);


  app.route('/empleados/:empleadoId')
    .get(empleadosController.GetById)
    .put(empleadosController.Put)
    .delete(empleadosController.Delete);


  var personaController = require('../controllers/personaController');

  app.route('/persona')
    .get(personaController.GetAll)
    .put(personaController.Put)
    .post(personaController.Post);

  app.route('/persona/:idPersona')
    .get(personaController.GetById)
    .delete(personaController.DeleteById);
*/
  var usuarioController = require('../controllers/usuariosController');

  app.route('/usuarioRegistra')
    .post(usuarioController.usuarioRegistraPost);

  app.route('/usuarioLogin')
    .post(usuarioController.usuarioLoginPost);

  app.route('/usuarioRecuperaContra')
    .post(usuarioController.usuarioRecuperaContraPost);
  
  app.route('/usuarioDatosEdicion')
    .post(usuarioController.usuarioConsultaDatosEdicion);

  app.route('/usuarioActualizaFoto')
    .post(usuarioController.usuarioActualizaFoto);

  app.route('/usuarioActualizaDatos')
    .post(usuarioController.usuarioActualizaDatos);

  app.route('/usuarioActualizaContrasena')
    .post(usuarioController.usuarioActualizaContrasena);

  app.route('/usuarios')
    .post(usuarioController.usuarioConsultaDatos);

  app.route('/prospectos')
    .post(usuarioController.usuarioConsultaDatosProspectos);


  var difusionController = require('../controllers/difusionController');
  
  app.route('/difusionEnviar')
    .post(difusionController.difusionEnviarCorreo);

  var encuestasController = require('../controllers/encuestasController');
  
  app.route('/encuestas')
    .post(encuestasController.consultaEncuestas);
  
  app.route('/encuestasVotar')
    .post(encuestasController.votarEncuestas);
  app.route('/encuestasDetalles/:id_encuesta')
    .get(encuestasController.detallesEncuesta);

  var domiciliosController = require('../controllers/domiciliosController');

  app.route('/calles')
    .get(domiciliosController.getCalles);

  app.route('/numerosPorCalle/:idCalle')
    .get(domiciliosController.getNumerosPorCalle);


  app.route('/test')
    .get(function(req, res){
      res.json("HOLAAA!!");
    });
};