var express = require('express');
var cors = require('cors');
var app = express();
var bodyParser = require('body-parser');

//socket
var server = require('http').createServer(app);  
var io = require('socket.io')(server);
var routes = require('./routes'); //importing route

//================================   web api =======================================================

app.use(cors());
// CORS Issue Fix
app.all('/', function(req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "X-Requested-With");
  next();
 });
//configurando la codificación del body
app.use(bodyParser.json({limit: '50mb'})); 
app.use(bodyParser.urlencoded({limit: '50mb', extended: true}));
//registrando rutas http
app.use(express.static('public'));


app.use(function(err, req, res, next) {
    //res.status(err.status || 500);
    console.log({"mensaje": "Error al llamar al servicio.", "detalles": err});
    res.json({"resultado": 500, "mensaje": "Error al llamar al servicio.", "detalles": err});
    //res.end();
});

//iniciando el servidor en el puerto 3000
/*
var port = 4100;
app.listen(port, function () {
    console.log("Web api port: "+port);
});*/
routes(app, io); //registrando la ruta y enviando el socket al controlador

//=================================   socket server   =================================================
var port = 8080; // 4100;
server.listen(port, function() {
	console.log('Starting at port: '+ port);
});

var usuarios = [];

io.on('connection', (socket) => {
    var socketId = socket.id;
  var clientIp = socket.request.connection.remoteAddress;

    var sessionid = socket.id;
    console.log('Usuario conectado ID:'+ sessionid);

    usuarios.push({_socket: socket, _socketid: sessionid, username: '-'});

    socket.on('disconnect', function() {
        console.log('Usuario desconectado ID:'+socket.id);
        //falta quitar del arreglo el objeto del usuario
         var found = usuarios.filter(function(item) { return item._socketid === socket.id; });
        var index = usuarios.indexOf(found[0]);
        if (index > -1) {
            usuarios.splice(index, 1);
            console.log("Se removió socket: "+found[0]._socketid);
        }
    });

	socket.on('enviamousedownleft', (message) => {
        io.emit('mousedownleft', message );
    });
	socket.on('enviamousedownmid', (message) => {
        io.emit('mousedownmid', message );
    });
    socket.on('enviamousedownright', (message) => {
        io.emit('mousedownright', message );
    });
    socket.on('enviamouseupleft', (message) => {
        io.emit('mouseupleft', message );
    });
	socket.on('enviamouseupmid', (message) => {
        io.emit('mouseupmid', message );
    });
    socket.on('enviamouseupright', (message) => {
        io.emit('mouseupright', message );
    });
    //envia letras
    socket.on('enviakeydown', (message) => {
        io.emit('keydown', message );
    });
    socket.on('enviakeyup', (message) => {
        io.emit('keyup', message );
    });

	socket.on('enviaMouse', (message) => {
        io.emit('mueveMouse', message );
    });
	socket.on('emitefoto', (message) => {
        io.emit('reenviafoto', message );
    });
    socket.on('identificame', (username) => {
        console.log("entro");
        console.log("identificando usuario: "+username+ " para socket id: "+ socket.id);
        //buscando usuario por su session id y actualizando su username
        var found = usuarios.filter(function(item) { return item._socketid === socket.id; });
        console.log(found);
        found[0].username = username;


        io.emit('message',{socketid:found[0]._socketid, username: found[0].username } );
    });

    socket.on('add-message', (message) => {
        console.log("message: "+message);
        io.emit('message', { type: 'new-message', text: message });
        // Function above that stores the message in the database
        //databaseStore(message)
    });

});

