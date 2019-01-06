'use strict';
var mySQL = require('../util/mysqlUtil');

var nodemailer = require('nodemailer');

  

var enviarCorreo = function(para, asunto, correo, success, error){
  
}

exports.difusionEnviarCorreo = function(req, res){
    mySQL.queryMySQL('select d.nombres, u.email from gen_usuario u inner join gen_datosusuario d on u.id_Usuario = d.id_Usuario', 
    [], 
    function(result){
      if(result.length > 0)
      {
        var totalCorreos = 0;
        var correosError = 0;
        var correosOk = 0;
        var detalleErrores = [];


        //result = [{"nombres": "Abraham Salvador", "email": "abrahamendez89@gmail.com"}, {"nombres": "Sarah", "email": "ln.sarah.medina@gmail.com"}];

          result.forEach(function(item, index){
              totalCorreos++;
              setTimeout(function(){
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

                var correo =  '<h3>Hola '+ item.nombres+', tenemos un mensaje importante para ti! </h3>'+
                '<br>'+req.body.mensaje +
                '<br><br><b>Que tengas buen día!!.</b>'+
                '<br><br><h5>Este correo es enviado de forma automática con fines informativos, por favor no responda a esta dirección.</h5>';
                var mailOptions = {};
                if(req.body.archivo == undefined){
                  mailOptions = {
                    from: 'plataformacorcega@gmail.com',
                    to: item.email,
                    subject: "Plataforma Stanza Corcega - Difusión",
                    text: '',
                    html: correo
                  };
                }else{
                  mailOptions = {
                    from: 'plataformacorcega@gmail.com',
                    to: item.email,
                    subject: "Plataforma Stanza Corcega - Difusión",
                    text: '',
                    html: correo,
                    attachments: [
                      {   
                        filename: req.body.archivo,
                        content: req.body.archivoBase64,
                        encoding: 'base64'
                      }
                    ]
                  };
                }
                transporter.sendMail(mailOptions, function(err, info){
                  if(err){
                    correosError ++;
                    detalleErrores.push({"correo": item.email, "error": err});
                    console.log("Error al enviar correo difusion: "+ err);
                  }else{
                    correosOk ++;
                    console.log("Correo difusión enviado: "+ info);
                  }
                });

            },1000*index);
          });

          setTimeout(function(){
             res.json({"exito": true, "mensaje": "Correos enviados correctamente.", "correosTotales": totalCorreos, "exitosos": correosOk, "errores": correosError, "erroresDetalles": detalleErrores });
          },(1000*totalCorreos) + 2000);

      }
      else
        res.json({"exito": false, "mensaje": "No hay usuarios para enviar el correo." });
    }, function(error){
      res.json({"exito": false, "mensaje": "Error al obtener los usuarios." });
    });
  };