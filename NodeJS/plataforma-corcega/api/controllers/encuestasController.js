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

exports.consultaEncuestas = function(req, res){
  mySQL.queryMySQL('select i.id_encuesta, i.titulo as tituloEncuesta, i.descripcion, ie.id_opcion, ie.titulo as tituloOpcion, i.esAnonima, i.estaFinalizada, i.estaActiva, i.fecha_creacion, '+
  '(select count(*) from inf_votaciones v where v.id_opcion = ie.id_opcion and v.id_encuesta = i.id_encuesta) as votos, '+
  '(select CONCAT(du.nombres ,\' \', du.apellidoPaterno,\' \', du.apellidoMaterno) from inf_votaciones v inner join gen_datosusuario du on v.id_usuario = du.id_Usuario where id_encuesta = i.id_encuesta order by v.fecha_voto desc limit 1) as ultimo_voto, ' +
  '(select v.fecha_voto from inf_votaciones v inner join gen_datosusuario du on v.id_usuario = du.id_Usuario where id_encuesta = i.id_encuesta order by v.fecha_voto desc limit 1) as ultimo_voto_fecha ' +
  'from inf_encuesta i '+
  'inner join inf_encuestaopciones ie on i.id_encuesta = ie.id_encuesta ' +
  'where i.estaActiva = 1 '+
  'order by i.fecha_creacion desc', 
  [], 
  function(encuestasOpciones){
    if(encuestasOpciones.length > 0)
    {
      //aqui crear los obj json de las encuestas
      var encuestasJson = [];
      console.log("ID: "+req.body.id_usuario);
      encuestasOpciones.forEach(function(item, index){
        var encuesta;
        for(var i = 0; i < encuestasJson.length; i++){
          if(encuestasJson[i].id == item.id_encuesta){
            encuesta = encuestasJson[i];
            break;
          }
        }
        if(!encuesta){
          encuesta = {
            "id": item.id_encuesta,
            "titulo": item.tituloEncuesta,
            "descripcion": item.descripcion,
            "esAnonima": item.esAnonima,
            "estaFinalizada": item.estaFinalizada,
            "fecha_creacion": item.fecha_creacion,
            "ultimo_voto": item.ultimo_voto,
            "fecha_ultimo_voto": item.ultimo_voto_fecha,
            "yaVoto": 0, //este se ajustará posteriormente
            "mensaje" : '',
            "opciones": []
          }
          encuestasJson.push(encuesta);
        }

        if(!encuesta.opciones)
          encuesta.opciones = [];

        encuesta.opciones.push({"id": item.id_opcion, "titulo": item.tituloOpcion, "votos": item.votos});

      });

      //antes de retornar la respuesta, se verifica en cuales encuestas activas ya voto el usuario

      mySQL.queryMySQL('select '+
      'infv.id_encuesta, dud.nombres, '+
      'eo.titulo '+
      'from inf_votaciones infv  '+
      'inner join gen_datosusuario dud on dud.id_Usuario = infv.id_usuario '+
      'inner join inf_encuesta e on infv.id_encuesta = e.id_encuesta '+
      'inner join inf_encuestaopciones eo on infv.id_opcion = eo.id_opcion '+
      'where e.estaActiva = 1 and dud.id_numeroCalle = ?'
      ,[req.body.numeroCalle]
      ,function(result){
        if(result.length > 0){
          for(var i = 0; i < result.length; i++){
            for(var j = 0; j < encuestasJson.length; j++){
              if(result[i].id_encuesta == encuestasJson[j].id){
                //Se actualiza el estatus a ya voto
                encuestasJson[j].yaVoto = 1;
                encuestasJson[j].mensaje = 'En tu casa el voto fue de '+result[i].nombres+', y votó por: '+result[i].titulo+'.';
                break;
              }
            }
          }
        }
        res.json({"exito": true, "mensaje": "Datos cargados correctamente.", "data": encuestasJson });
      },function(error){
        res.json({"exito": false, "mensaje": "Error al obtener los datos de la votación por usuario." });
      });

      
    }
    else
      res.json({"exito": false, "mensaje": "No existen votaciones activas." });
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al obtener los datos." });
  });
};

exports.votarEncuestas = function(req, res){
  mySQL.conecta(function(connection){
    mySQL.ejecutaQuery(connection, 
    'select count(*) as votos '+
    'from inf_votaciones v '+
    'inner join gen_datosusuario du on v.id_usuario = du.id_usuario '+
    'where du.id_numeroCalle = ? and v.id_encuesta = ?'
    ,[req.body.numeroCalle, req.body.id_encuesta]
    , function(result){
      //al momento de realizar la consulta, si no ha votado alguien antes de su casa, entonces se registra el voto.
      if(result[0].votos == 0){

          //no ha votado ningun vecino de la familia, por lo tanto se le permite votar.
        
          mySQL.ejecutaQuery(connection, 
          'insert into inf_votaciones(id_encuesta, id_opcion, id_usuario, fecha_voto) values(?,?,?,NOW())', 
          [req.body.id_encuesta, req.body.id_opcion, req.body.id_usuario]
          , function(result){
            mySQL.commitTransaction(connection, function(success){
              res.json({"exito": true, "mensaje": "Se ha registrado tu voto exitosamente." });
            }, function(error){
              res.json({"exito": false, "mensaje": "Error al guardar.", "obj":error });
            });
          
          }, function(error){
            res.json({"exito": false, "mensaje": "Error al guardar." , "obj":error});
          });
      }
      else{
        //ya voto alguien de la familia, por lo tanto no se le permite votar y se le retorna el error.
        res.json({"exito": true, "mensaje": "Un integrante de tu casa ya votó en esta votación, recuerda que solo está permitido un voto por casa."});
      }
      
        
    }, function(error){
      res.json({"exito": false, "mensaje": "Error al consultar votos previos." , "obj":error});
    });
    
  }, function(error){
    res.json({"exito": false, "mensaje": "Error al conectar con la base de datos.", "obj":error });
  });
};

exports.detallesEncuesta = function(req, res){
  mySQL.queryMySQL('select d.nombres, d.apellidoPaterno, d.apellidoMaterno, eo.titulo, v.fecha_voto, d.fotoPerfil '+
  'from inf_votaciones v '+
  'inner join gen_datosusuario d on v.id_usuario = d.id_Usuario '+
  'inner join inf_encuestaopciones eo on v.id_opcion = eo.id_opcion '+
  'inner join inf_encuesta e on e.id_encuesta = eo.id_encuesta '+
  'where v.id_encuesta = ? and e.esAnonima = 0 and e.estaActiva = 1 '+
  'order by v.fecha_voto desc'
  ,[req.params.id_encuesta], 
  function(result){
    if(result.length > 0){
      res.json({"exito": true, "mensaje": "Datos consultados exitosamente", "data":result });
    }else{
      res.json({"exito": false, "mensaje": "La votación no se puede visualizar debido a que no hay votos o es anónima."});
    }
  }, function(error){
    es.json({"exito": false, "mensaje": "Error al consultar los detalles de la votación.", "obj": error});
  });
};