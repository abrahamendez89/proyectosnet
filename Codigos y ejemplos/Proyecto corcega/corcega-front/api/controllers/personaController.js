'use strict';
var mySQL = require('../util/mysqlUtil');
//var redis = require('../util/redisUtil');

exports.GetAll = function(req, res) {
  mySQL.queryMySQL("select * from persona",[],function(result){
     res.json(result);

   /*redis.consulta("",function(valor){
      res.json(valor);
   });*/

   
  },function(error){
     res.json(error);
  });
};

exports.Post = function(req, res) {
  mySQL.queryMySQL("insert into persona (Nombre, Apellido, Edad) values (?,?,?)",
  [req.body.Nombre, req.body.Apellido, req.body.Edad],function(result){
     res.json(result);
  },function(error){
     res.json(error);
  });
};

exports.Put = function(req, res) {
  mySQL.queryMySQL("Update persona set Nombre = ?, Apellido = ?, Edad = ? where idPersona = ?",
  [req.body.Nombre, req.body.Apellido, req.body.Edad, req.body.idPersona],function(result){
     res.json(result);
  },function(error){
     res.json(error);
  });
};

exports.DeleteById = function(req, res) {
  mySQL.queryMySQL("delete from persona where idPersona = ?",
  [parseInt(req.params.idPersona)],function(result){
     res.json(result);
  },function(error){
     res.json(error);
  });
};

exports.GetById = function(req, res) {
  mySQL.queryMySQL("select * from persona where idPersona = ?",
  [parseInt(req.params.idPersona)],function(result){
     res.json(result);
  },function(error){
     res.json(error);
  });
};