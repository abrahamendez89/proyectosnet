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
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json()); 
//registrando rutas http



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
var port = 4100; // 4100;
server.listen(port, function() {
	console.log('Starting at port: '+ port);
});

var usuarios = [];
var juegoIniciado = false;
var jugadorInicial;
var dineroRonda = 0;
var usarDadosVirtuales = false;
var indiceActualLanzamientoDados = -1;
var ordenLanzamientos = [];
var jugadores = [];

var peticionCobroBanco = {jugador: "", dinero: 0, autorizantes: 0};

io.on('connection', (socket) => {

    //datos de juego

    
    


    //termina datos de juego
    var socketId = socket.id;
    var clientIp = socket.request.connection.remoteAddress;
    var sessionid = socket.id;
    console.log('Usuario conectado ID:'+ sessionid);

    //--usuarios.push({_socket: socket, _socketid: sessionid, username: '-', gameData: { dinero: 0, estaConectado: true, turno: -1, dadosIniciales:-1 }});

    socket.on('disconnect', function() {
        console.log('Usuario desconectado ID:'+socket.id);

        for(var i = 0; i < jugadores.length; i++){
            if(jugadores[i].socketid == socket.id){
                jugadores[i].gameData.estaConectado = false;
            }
        }
    });

    socket.on('identificame', (username) => {
        //console.log("entro");
        console.log("identificando usuario: "+username+ " para socket id: "+ socket.id);
        var juego = [];
        var encontrado = false;
        if(!juegoIniciado){
            console.log("Juego aun no iniciado");
            for(var i = 0; i < jugadores.length; i++){
                if(jugadores[i].username == username){
                    encontrado = true;
                }
            }

            if(!encontrado){
                console.log("Se inserta jugador");
                jugadores.push({socketid: socket.id, username: username, gameData: { dinero: 0, estaConectado: true, turno: -1, dadosIniciales:-1 }});
                encontrado = true;
            }
           
            for(var i = 0; i < jugadores.length; i ++){
                juego.push({jugador: jugadores[i].username, gameData: jugadores[i].gameData});
            }
            
            io.emit('message', {receptor: "*", accion: "actualizarJuego", data: juego, dineroRonda: dineroRonda});
        }
        else{
            console.log("juego iniciado");
            console.log(JSON.stringify(jugadores));
            var turnoToca = -1;
            for(var i = 0; i < jugadores.length; i++){
                if(jugadores[i].username == username){
                    jugadores[i].socketid = socket.id;
                    jugadores[i].gameData.estaConectado = true;
                    turnoToca = jugadores[i].gameData.turno;
                    encontrado = true;
                }
            }
            if(encontrado)
            {
                console.log("Es un jugador registrado");
                 //se actualiza el juego
                for(var i = 0; i < jugadores.length; i ++){
                    juego.push({jugador: jugadores[i].username, gameData: jugadores[i].gameData});
                }
                var jugadorActual = "";
                if(ordenLanzamientos.length > 0){
                    jugadorActual = ordenLanzamientos[indiceActualLanzamientoDados].username;
                }
                else
                    jugadorActual = jugadorInicial;
                console.log("Es turno de: "+jugadorActual);
                console.log("Usar dados virtuales: "+usarDadosVirtuales);
                io.emit('message', {receptor: username, accion: "reconexion", data: juego, dineroRonda: dineroRonda, turnoDe: jugadorActual, turno: turnoToca, usarDadosVirtuales: usarDadosVirtuales});
                
                return;
            }
            else
            {
                console.log("No es un jugador registrado")
                io.emit('message', {receptor: username, accion: "iniciado"});
            }
        }
        if(encontrado)
        {
            if(!juegoIniciado){
                if(jugadorInicial == undefined || jugadorInicial == username)
                {
                    jugadorInicial = username;
                    io.emit('message', {receptor: username, accion: "configurar"});
                }
                else{
                    io.emit('message', {receptor: username, accion: "esperar"});
                }
                io.emit('message', {receptor: "*", accion: "actualizarJuego", data: juego, dineroRonda: dineroRonda});
            }else{
                io.emit('message', {receptor: username, accion: "reconexion", data: juego, dineroRonda: dineroRonda, turnoDe: jugadores[indiceActualLanzamientoDados].username, turno: jugadores[indiceActualLanzamientoDados].turno});
            }
        }
        else{
            io.emit('message', {receptor: username, accion: "iniciado"});
        }
        
    });

    socket.on('accion', (message) => {
        console.log(JSON.stringify(message));
        var mensajeLog = "";
        var juego = [];
        if(message.accion == "terminarJuego"){
            juegoIniciado = false;
            jugadorInicial = undefined;
            dineroRonda = 0;
            ordenLanzamientos = [];
            jugadores = [];

            io.emit('message', {receptor: "*", accion: "terminarJuego", data: juego, dineroRonda: dineroRonda});
           
        }
        else if(message.accion == "noPermitirCobro"){
            mensajeLog = message.emisor + " no pemitió el cobro de " + peticionCobroBanco.jugador + " por $" +peticionCobroBanco.dinero;
            peticionCobroBanco.jugador = "";
            peticionCobroBanco.dinero = 0;
            peticionCobroBanco.autorizantes = -1;
            io.emit('message', {emisor: message.emisor, receptor: "*", accion: "noautorizarCobro"});
        }
        else if(message.accion == "cobrarBanco"){
            peticionCobroBanco.jugador = message.emisor;
            peticionCobroBanco.dinero = message.dinero;
            peticionCobroBanco.autorizantes = jugadores.length-1;
            mensajeLog = peticionCobroBanco.jugador + " solicita un cobro por $" +peticionCobroBanco.dinero;
            io.emit('message', {emisor: message.emisor, receptor: "*", accion: "autorizarCobro", dinero: message.dinero});
        }
        else if(message.accion == "pagarBanco"){
            //se busca el que paga
            mensajeLog = message.emisor + " pagó $" + message.dinero + " al banco.";
            for(var i = 0; i < jugadores.length; i++){
                if(jugadores[i].username == message.emisor){
                    jugadores[i].gameData.dinero = parseInt(jugadores[i].gameData.dinero) - parseInt(message.dinero);
                }
            }
            //se actualiza el juego
            for(var i = 0; i < jugadores.length; i ++){
                juego.push({jugador: jugadores[i].username, gameData: jugadores[i].gameData});
            }
            io.emit('message', {receptor: "*", accion: "actualizarJuego", data: juego, dineroRonda: dineroRonda});
        }
        else if(message.accion == "autorizarCobroBanco"){
            peticionCobroBanco.autorizantes = peticionCobroBanco.autorizantes - 1;
            mensajeLog = message.emisor + " pemitió el cobro de " + peticionCobroBanco.jugador + " por $" +peticionCobroBanco.dinero;
            if(peticionCobroBanco.autorizantes == 0){
                mensajeLog = " cobro autorizado de " + peticionCobroBanco.jugador + " por $" +peticionCobroBanco.dinero;
                //ya se autorizaron los cobros
                //se busca el que paga
                for(var i = 0; i < jugadores.length; i++){
                    if(jugadores[i].username == peticionCobroBanco.jugador){
                        jugadores[i].gameData.dinero = parseInt(jugadores[i].gameData.dinero) + parseInt(peticionCobroBanco.dinero);
                    }
                }
                //se actualiza el juego
                for(var i = 0; i < jugadores.length; i ++){
                    juego.push({jugador: jugadores[i].username, gameData: jugadores[i].gameData});
                }
                //se envia actualizacion a jugadores
                peticionCobroBanco.jugador = "";
                peticionCobroBanco.dinero = 0;
                peticionCobroBanco.autorizantes = -1;

                io.emit('message', {receptor: "*", accion: "actualizarJuego", data: juego, dineroRonda: dineroRonda});
            }
        }
        else if(message.accion == "iniciarJuego"){
            juegoIniciado = true;
            dineroRonda = message.gameData.dineroRonda;
            usarDadosVirtuales = message.gameData.usarDadosVirtuales;
            for(var i = 0; i < jugadores.length; i ++){
                jugadores[i].gameData.dinero = message.gameData.dineroInicial;
                juego.push({jugador: jugadores[i].username, gameData: jugadores[i].gameData});
            }
            io.emit('message', {receptor: "*", accion: "actualizarJuego", data: juego, dineroRonda: dineroRonda});
            io.emit('message', {receptor: "*", accion: "iniciarJuego", usarDadosVirtuales: usarDadosVirtuales});
            if(usarDadosVirtuales){
                console.log("Se usaran dados virtuales, el primero en lanzar para turnos es:"+jugadores[0].username);
                io.emit('message', {receptor: jugadores[0].username, accion: "lanzarDadosInicial"});
                indiceActualLanzamientoDados = 0;
                ordenLanzamientos = [];
            }
        }
        else if(message.accion == "lanzarDadosInicial"){
            indiceActualLanzamientoDados ++;
            //se le asigna lo que le salio en los dados
            for(var i = 0; i < jugadores.length; i++){
                if(jugadores[i].username == message.emisor){
                    jugadores[i].gameData.dadosIniciales = parseInt(message.sumaDados);
                }
            }
            ordenLanzamientos.push({username: message.emisor, dadosIniciales: message.sumaDados, turno:0});
            if(indiceActualLanzamientoDados < jugadores.length){
                
                console.log("Se envia el primer lanzamiento de dados al siguiente jugador:");
                io.emit('message', {receptor: jugadores[indiceActualLanzamientoDados].username, accion: "lanzarDadosInicial"});
            }
            else{
                //se termino el lanzamiento inicial, inician los lanzamientos ordenados
                ordenLanzamientos.sort(function (a, b) {
                    if (a.dadosIniciales > b.dadosIniciales) {
                      return -1;
                    }
                    if (a.dadosIniciales < b.dadosIniciales) {
                      return 1;
                    }
                    // a must be equal to b
                    return 0;
                  });
                for(var i = 0; i < ordenLanzamientos.length; i++)
                {
                    ordenLanzamientos[i].turno = i+1;
                }
                console.log("ordenamiento: ");
                console.log(ordenLanzamientos);
                indiceActualLanzamientoDados = 0;
                for(var i = 0; i < ordenLanzamientos.length; i++)
                {
                    io.emit('message', {receptor: ordenLanzamientos[i].username, accion: "actualizarTurno", turno: ordenLanzamientos[i].turno});
                }
                //actualizando turno en los datos del juego
                for(var i = 0; i < jugadores.length; i++){
                    for(var j = 0; j < ordenLanzamientos.length; j++){
                        if(jugadores[i].username == ordenLanzamientos[j].username){
                            jugadores[i].gameData.turno = ordenLanzamientos[j].turno;
                            break;
                        }
                    }
                }
                io.emit('message', {receptor: "*", accion: "empiezaJuego"});
                io.emit('message', {receptor: ordenLanzamientos[indiceActualLanzamientoDados].username, accion: "lanzarDados"});
            }
        }
        else if(message.accion == "lanzarDados"){
            indiceActualLanzamientoDados++;
            if(indiceActualLanzamientoDados >= ordenLanzamientos.length){
                indiceActualLanzamientoDados = 0;
            }
            console.log("OrdenLanzamientos");
            console.log(JSON.stringify(ordenLanzamientos));
            console.log("indiceActualLanzamientoDados: "+indiceActualLanzamientoDados);
            io.emit('message', {receptor: ordenLanzamientos[indiceActualLanzamientoDados].username, accion: "lanzarDados"});
        }
        else if(message.accion == "mostrarTiroDadosOtro"){
            io.emit('message', message);
        }
        else if(message.accion == "mostrarTiroFinal"){
            mensajeLog = message.emisor + " lanzo: "+ message.dado1 + " - "+ message.dado2;
        }
        else if(message.accion == "pagar"){
            //se busca el que paga
            mensajeLog = message.emisor + " pago a " + message.receptor + " la cantidad de $" +message.pago;
            for(var i = 0; i < jugadores.length; i++){
                if(jugadores[i].username == message.emisor){
                    jugadores[i].gameData.dinero = parseInt(jugadores[i].gameData.dinero) - parseInt(message.pago);
                }
                if(jugadores[i].username == message.receptor){
                    jugadores[i].gameData.dinero = parseInt(jugadores[i].gameData.dinero) + parseInt(message.pago);
                }
            }
            //se actualiza el juego
            for(var i = 0; i < jugadores.length; i ++){
                juego.push({jugador: jugadores[i].username, gameData: jugadores[i].gameData});
            }
            //se envia actualizacion a jugadores
            io.emit('message', {receptor: "*", accion: "actualizarJuego", data: juego});
        }


        //se envia el log
        if(mensajeLog != "")
        {
            io.emit('message', {receptor: "*", accion: "log", mensaje: mensajeLog});
            mensajeLog = "";
        }
    });

});

