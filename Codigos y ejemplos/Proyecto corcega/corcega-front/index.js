var express = require('express'),
    app = express(),
    port = process.env.PORT || 3000,
    //mongoose = require('mongoose'),
    //Empleado = require('./api/models/empleadosModel'),
    bodyParser = require('body-parser'),
    cors = require('cors'),
    //webSocketServer = require('websocket').server,
    http = require('http');


    app.use(bodyParser.json({limit: '50mb'}));
    app.use(bodyParser.urlencoded({limit: '50mb'}));

app.use(express.static(__dirname+ '/public'));

app.use('/views', express.static(__dirname + '/public/views'));

app.get('/', function(req, res) {
    res.sendfile('index.html', {root: __dirname + '/public'})
});

app.get('/registro', function(req, res) {
    console.log("enviando registro prueba");
    res.sendfile('registroView.html', {root: __dirname + '/public/views/Usuarios'})
});




// mongoose instance connection url connection
//mongoose.Promise = global.Promise;
//mongoose.connect('mongodb://localhost/Tododb'); 

app.use(cors());

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());


var routes = require('./api/routes/Routes'); //importing route
routes(app); //register the route


app.listen(port);


console.log('Web Api started at: ' + port);
app.use(function(req, res) {
    res.status(404).send({ url: req.originalUrl + ' not found' })
});

