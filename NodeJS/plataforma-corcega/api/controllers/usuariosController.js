'use strict';
var mySQL = require('../util/mysqlUtil');

var nodemailer = require('nodemailer');
var transporter = nodemailer.createTransport({
  service: 'Gmail',
  //host: 'myhost',
  port: 465,
  secure: true,
  auth: {
    user: 'plataformacorcega@gmail.com',
    pass: 'Qwer1234!'
  }
});
  

var enviarCorreo = function(para, asunto, correo, success, error){
  var mailOptions = {
    from: 'plataformacorcega@gmail.com',
    to: para,
    subject: asunto,
    text: '',
    html: correo
  };
  transporter.sendMail(mailOptions, function(err, info){
    if(err){
      error(err);
    }else{
      success(info);
    }
  });
}


exports.usuarioRegistraPost = function(req, res) {

  mySQL.conecta(function(connection){

    mySQL.ejecutaQuery(connection, "select id_Usuario from gen_usuario where numCelular = ?", [req.body.celular],
    function(result){
      if(result.length > 0)
      {
        res.json({"exito":false, "mensaje":"El celular ya fue registrado previamente."});  
        return;
      }else{
        //se continua con el registro
        mySQL.ejecutaQuery(connection, "insert into gen_usuario(numCelular, contrasena, preguntaSecreta, respuestaSecreta, email) values(?,?,?,?,?)",
        [req.body.celular, req.body.contrasena, req.body.preguntaSecreta, req.body.respuestaSecreta, req.body.email],
        function(result){
          //se pudo registrar el usuario, por lo que se registran los datos de usuario
          mySQL.ejecutaQuery(connection, "select id_Usuario from gen_usuario where numCelular = ? and contrasena = ?",
          [req.body.celular, req.body.contrasena]
          ,function(result){
            var idUsuario = result[0].id_Usuario;       
            //se insertan el resto de los datos de registro
            mySQL.ejecutaQuery(connection, "insert into gen_datosusuario(id_Usuario, apellidoPaterno, apellidoMaterno, nombres, fechaNacimiento, id_numeroCalle, fotoPerfil) values (?,?,?,?,?,?,?)",
            [idUsuario, req.body.apPaterno, req.body.apMaterno, req.body.nombre, req.body.fechaNacFor, req.body.idCasa, req.body.fotoPerfil],
            function(result){
              //se hace el commit a la transaccion y si es exitosa, se envian los correos
              mySQL.commitTransaction(connection, function(success){
                  //ahora se envian los correos informativos
                  res.json({"exito":true, "mensaje":"Registrado correctamente."});
                  //enviando correos registrados
                  var correo =  '<h1>Hola '+req.body.nombre+'!!</h1><br>'+
                  '<h3>Tus datos de registro son: </h3><br>'+
                  '<b>Teléfono:</b> ' + req.body.celular+ '<br>'+
                  '<b>Contraseña:</b> ' + req.body.contrasena+'<br>'+
                  '<b>Pregunta secreta:</b> '+req.body.preguntaSecreta+'<br>'+
                  '<b>Respuesta secreta:</b> '+ req.body.respuestaSecreta+'<br>'+
                  '<br><br><b>Gracias por tu registro!!.</b>';
                  //enviando correo...
                  enviarCorreo(req.body.email, "Stanza Corcega - Gracias por registrarte", 
                  correo
                  , function(success){
                    console.log(success);
                  }, function(error){
                    console.log(error);
                  });
                  //enviando correo informativo
                  var correo2 =  '<h3>Se ha registrado un nuevo usuario: </h3><br>'+
                  '<b>Teléfono:</b> ' + req.body.celular+ '<br>'+
                  '<b>Nombre(s):</b> ' + req.body.nombre+'<br>'+
                  '<b>Apellido Paterno:</b> '+ req.body.apPaterno+'<br>'+
                  '<b>Apellido Materno:</b> '+ req.body.apMaterno+'<br>'+
                  '<b>Email:</b> '+ req.body.email+'<br>'+
                  '<b>ID:</b> '+ idUsuario+'<br>'+
                  '';
                  //enviando correo ...
                  enviarCorreo('abrahamendez89@gmail.com', "Stanza Corcega - Usuario registrado", 
                  correo2
                  , function(success){
                    console.log(success);
                  }, function(error){
                    console.log(error);
                  });

                  return;
              }, function(error){
                res.json({"exito":false, "mensaje":"Error al guardar los datos en la transacción."});
                return;
              });
              
            }, function(error){
              res.json({"exito":false, "mensaje":"Error al registrar los datos personales."});
              return;
            });


          }, function(error){
            res.json({"exito":false, "error": error, "mensaje":"Error al obtener el id del usuario."});
            return;
          });
          

        },function(error){
          res.json({"exito":false, "error": error, "mensaje":"Error al insertar los datos de usuario."});
          return;
        });


      }
    }, function(error){
      res.json({"exito":false, "error": error, "mensaje":"Error al consultar los datos del telefono o contraseña."});
      return;
    });

  },function(err){
    console.log("Error al conectar: "+ err);
    
  });



};





  //validando que no se haya registrado el numero celular previamente.
  /*
  mySQL.queryMySQL("select id_Usuario from gen_usuario where numCelular = ?",[req.body.celular],function(result){
      if(result.length > 0)
      {
        //console.log(1);
        res.json({"exito":false, "mensaje":"El celular ya fue registrado previamente."});  
        return;
      }
      else
      {
        //console.log(2);
        //si el usuario no existe previamente, se insertan los registros
        mySQL.queryMySQL("insert into gen_usuario(numCelular, contrasena, preguntaSecreta, respuestaSecreta, email) values(?,?,?,?,?)",
        [req.body.celular, req.body.contrasena, req.body.preguntaSecreta, req.body.respuestaSecreta, req.body.email],function(result){
          //se consulta el id generado y se insertan sus datos personales
          //console.log(3);
          mySQL.queryMySQL("select id_Usuario from gen_usuario where numCelular = ? and contrasena = ?",[req.body.celular, req.body.contrasena],function(result){
              var idUsuario = result[0].id_Usuario;       
              //se insertan el resto de los datos de registro
              //console.log(4);
              mySQL.queryMySQL("insert into gen_datosusuario(id_Usuario, apellidoPaterno, apellidoMaterno, nombres, fechaNacimiento, id_numeroCalle) values (?,?,?,?,?,?)",[idUsuario, req.body.apPaterno, req.body.apMaterno, req.body.nombre, req.body.fechaNacFor, req.body.idCasa],function(result){
                res.json({"exito":true, "mensaje":"Registrado correctamente."});
                //enviando correos
                var correo =  '<h3>Tus datos de registro son: </h3><br>'+
                '<b>Teléfono:</b> ' + req.body.celular+ '<br>'+
                '<b>Contraseña:</b> ' + req.body.contrasena+'<br>'+
                '<b>Pregunta secreta:</b> '+req.body.preguntaSecreta+'<br>'+
                '<b>Respuesta secreta:</b> '+ req.body.respuestaSecreta+'<br>'+
                '<br><br><b>Gracias por tu registro!!.</b>';
                enviarCorreo(req.body.email, "Stanza Corcega - Gracias por registrarte", 
                correo
                , function(success){
                   console.log(success);
                }, function(error){
                   console.log(error);
                });
                //enviando correo informativo
                var correo2 =  '<h3>Se ha registrado un nuevo usuario: </h3><br>'+
                '<b>Teléfono:</b> ' + req.body.celular+ '<br>'+
                '<b>Nombre(s):</b> ' + req.body.nombre+'<br>'+
                '<b>Apellido Paterno:</b> '+ req.body.apPaterno+'<br>'+
                '<b>Apellido Materno:</b> '+ req.body.apMaterno+'<br>'+
                '<b>Email:</b> '+ req.body.email+'<br>'+
                '<b>ID:</b> '+ idUsuario+'<br>'+
                '';
                enviarCorreo('abrahamendez89@gmail.com', "Stanza Corcega - Usuario registrado", 
                correo2
                , function(success){
                   console.log(success);
                }, function(error){
                   console.log(error);
                });
                return;
              },function(error){
                //console.log(error);
                res.json({"exito":false, "mensaje":"Error al registrar los datos personales."});
                return;
              });
          }, function(error){
            //console.log(error);
            res.json({"exito":false, "error": error, "mensaje":"Error al obtener el id del usuario."});
            return;
          }); 
        },function(error){
          console.log(error);
          res.json({"exito":false, "error": error, "mensaje":"Error al insertar los datos de usuario."});
          return;
        });
      }
  },function(error){
      res.json({"exito":false,"error": error, "mensaje":"Error al registrar los datos personales."});
      return;
  });
  
};
*/

exports.usuarioLoginPost = function(req, res) {
  mySQL.queryMySQL("SELECT u.id_Usuario, d.nombres, d.fotoPerfil, d.id_numerocalle FROM gen_usuario u inner join gen_datosusuario d on u.id_Usuario = d.id_Usuario where numCelular = ? and contrasena = ?",
  [req.body.celular, req.body.contrasena]
  ,function(result){
    if(result.length > 0)
    {
        res.json({"exito": true, "id": result[0].id_Usuario, "nombre": result[0].nombres, "fotoPerfil": result[0].fotoPerfil, "numeroCalle": result[0].id_numerocalle });
    }
    else
      res.json({"exito": false, "mensaje": "Usuario o contraseña incorrectos." });
  },function(error){
     res.json({"exito": false, "error": error, "mensaje": "Error al intentar entrar al sistema." });
  });
};

exports.usuarioRecuperaContraPost = function(req, res) {
  mySQL.queryMySQL("select d.nombres, u.contrasena from gen_usuario u inner join gen_datosusuario d on u.id_Usuario = d.id_Usuario where u.numCelular = ? and u.email = ?",
  [req.body.celular, req.body.email],function(result){
    console.log('lenght: '+result.length);
    if(result.length > 0)
    {
      var correo =  '<h3>Hola '+ result[0].nombres+', tu contraseña es: </h3><br>'+
      '<b>Contraseña:</b> ' + result[0].contrasena+'<br>'+
      '<br><br><b>Que tengas buen día!!.</b>';
      enviarCorreo(req.body.email, "Stanza Corcega - Recuperación de contraseña", 
      correo
      , function(success){
        res.json({"exito": true, "mensaje": "Se envió la contraseña." });
      }, function(error){
        res.json({"exito": false, "error": error, "mensaje": "Error al enviar el correo con contraseña." });
      });
    }
    else
      res.json({"exito": false, "mensaje": "Usuario o email incorrectos." });
  },function(error){
     res.json({"exito": false, "error": error, "mensaje": "Ocurrió un error al consultar los datos." });
  });
};

exports.usuarioActualizaFoto = function(req, res){
  mySQL.queryMySQL('update gen_datosusuario set fotoPerfil = ? where id_Usuario = ?', 
  [req.body.fotoPerfil, req.body.id], 
  function(result){
    res.json({"exito": true, "mensaje": "Se actualizó la foto correctamente." });
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al actualizar la fotografía." });
  });
};

exports.usuarioActualizaDatos = function(req, res){
  mySQL.queryMySQL('update gen_usuario set email = ?, preguntaSecreta = ?, respuestaSecreta = ? where id_Usuario = ?', 
  [req.body.email, req.body.preguntaSecreta, req.body.respuestaSecreta, req.body.id], 
  function(result){
    res.json({"exito": true, "mensaje": "Se actualizaron los datos correctamente." });
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al actualizar los datos." });
  });
};

exports.usuarioActualizaContrasena = function(req, res){
  mySQL.queryMySQL('select contrasena from gen_usuario where id_Usuario = ? and contrasena = ?', 
  [req.body.id, req.body.contrasena], 
  function(result){
    if(result.length > 0)
    {
       //coincide la contraseña anterior
       mySQL.queryMySQL('update gen_usuario set contrasena = ? where id_Usuario = ? and contrasena = ?',
       [req.body.contrasenaNueva, req.body.id, req.body.contrasena], 
      function(result){
        res.json({"exito": true, "mensaje": "Se actualizó la contraseña correctamente." });
      }, function(error){
        res.json({"exito": false, "mensaje": "Error al actualizar la contraseña." });
      });

    }else{
       //la contrasena anterior no coincide
       res.json({"exito": false, "mensaje": "La contraseña anterior no coincide." });
    }

   
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al actualizar los datos." });
  });
};

exports.usuarioConsultaDatosEdicion = function(req, res){
  mySQL.queryMySQL('select d.fotoPerfil, u.email, u.preguntaSecreta, u.respuestaSecreta from gen_usuario u inner join gen_datosusuario d on u.id_Usuario = d.id_Usuario where u.id_Usuario = ?', 
  [req.body.id], 
  function(result){
    if(result.length > 0)
      res.json({"exito": true, "mensaje": "Datos cargados correctamente.", "obj": result[0] });
    else
      res.json({"exito": false, "mensaje": "No existen los datos para el usuario." });
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al obtener los datos de usuario." });
  });
};

exports.usuarioConsultaDatos = function(req, res){
  mySQL.queryMySQL('select u.id_Usuario, d.nombres , d.apellidoPaterno, d.apellidoMaterno, u.numCelular, u.email, d.fechaNacimiento, nc.id_Numero, ca.nombreCalle, nc.numero from gen_usuario u inner join gen_datosusuario d on u.id_Usuario = d.id_Usuario inner join gen_numeroscalles nc on nc.id_numero = d.id_numeroCalle inner join gen_calles ca on nc.id_Calle = ca.id_Calle',   
  [], 
  function(result){
    if(result.length > 0 && req.body.password == 'Qwer1234!')
      res.json({"exito": true, "mensaje": "Datos cargados correctamente.", "rows": result.length, "datos": result });
    else
      res.json({"exito": false, "mensaje": "No hay datos o contraseña incorrecta." });
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al obtener los datos de usuario." });
  });
};

exports.usuarioConsultaDatosProspectos = function(req, res){
  mySQL.queryMySQL('select telefono, nombre from temp where telefono not in (select numCelular from gen_usuario)',   
  [], 
  function(result){
    if(result.length > 0 && req.body.password == 'Qwer1234!')
      res.json({"exito": true, "mensaje": "Datos cargados correctamente.", "rows": result.length, "datos": result });
    else
      res.json({"exito": false, "mensaje": "No hay datos o contraseña incorrecta." });
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al obtener los datos de usuario." });
  });
};