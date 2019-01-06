
module.exports = function (ws) {
    var module = {};
    
    module.EnviaEstado = function (req, res) {
         //console.log(req.body);
		 req.app.set('1', req.body);
		 var instruccion = req.app.get('instruccion');
         res.json({"Instruccion":instruccion});
    };
	
	module.ConsultaEstado = function (req, res) {
         console.log(req.body);
		 req.app.set('instruccion', req.body.instruccion);
		 var estado = req.app.get('1');
         res.json({"estado":estado});
    };

    return module;
};