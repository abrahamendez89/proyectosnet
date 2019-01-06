'use strict';
var mySQL = require('../util/mysqlUtil');

exports.getCalles = function(req, res) {
  //validando que no se haya registrado el numero celular previamente.
  mySQL.queryMySQL("select * from gen_calles",[],function(result){
      res.json({"exito": true, "data": result });
  },function(error){
      res.json({"exito":false,"error": error, "mensaje":"Error al registrar los datos personales."});
      return;
  });
};

exports.getNumerosPorCalle = function(req, res) {
    
  mySQL.queryMySQL("select id_numero, numero from gen_numeroscalles where id_calle = ?",
  [req.params.idCalle],function(result){
      res.json({"exito": true, "data": result });
  },function(error){
     res.json({"exito": false, "error": error, "mensaje": "Usuario o contraseña incorrectos." });
  });
};