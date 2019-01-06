'use strict';
var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var EmpleadosSchema = new Schema({
  Nombres:          {type: String, required: "Nombres obligatorio"},
  Apellidos:        {type: String, required: "Apellidos obligatorio" },
  Edad:             {type: Number, default: 1,  },
  FechaInsercion:   { type: Date, default: Date.now }
});

module.exports = mongoose.model('Empleados', EmpleadosSchema);