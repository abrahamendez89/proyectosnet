'use strict';


var mongoose = require('mongoose'),
Empleado = mongoose.model('Empleados');

exports.GetAll = function(req, res) {
  Empleado.find({}, function(err, Empleado) {
    if (err)
      res.send(err);
    console.log("Consulta Empleados.GetAll")
    res.json(Empleado);
  });
};


exports.Post = function(req, res) {
  var new_Empleado = new Empleado(req.body);
  new_Empleado.save(function(err, Empleado) {
    if (err)
      res.send(err);
    res.json(Empleado);
  });
};


exports.GetById = function(req, res) {
  Empleado.findById(req.params.EmpleadoId, function(err, Empleado) {
    if (err)
      res.send(err);
    res.json(Empleado);
  });
};


exports.Put = function(req, res) {
  Empleado.findOneAndUpdate({_id: req.params.EmpleadoId}, req.body, {new: true}, function(err, Empleado) {
    if (err)
      res.send(err);
    res.json(Empleado);
  });
};


exports.Delete = function(req, res) {
  Empleado.remove({
    _id: req.params.EmpleadoId
  }, function(err, Empleado) {
    if (err)
      res.send(err);
    res.json({ message: 'Empleado successfully deleted' });
  });
};