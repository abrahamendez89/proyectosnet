var express = require('express'),
    app = express(),
    MySQL = require('mysql');



//mysql connection
var pool;
if(true){
    /*
    pool = MySQL.createPool({
        //connectionLimit: 1, //important
        host: 'maharba7.heliohost.org',
        user: 'maharba7_nodejs',                                                   
        password: 'Qwer1234!',
        database: 'maharba7_corcega'
        //debug: false
    });*/
    pool = MySQL.createPool({
        connectionLimit: 100, //important
        host: 'localhost',
        user: 'root',                                                   
        password: 'Qwer1234!',
        database: 'plat_corcega'
        //debug: false
    });
    console.log("Conectando a base de datos de producción...")
}
else{
    pool = MySQL.createPool({
        //connectionLimit: 1, //important
        host: 'localhost',
        user: 'root',                                                   
        password: '12345',
        database: 'mysqldb'
        //debug: false
    });
    console.log("Conectando a base de datos de localhost...")
}


var queryMySQL = function(query, values, success, error) {
    pool.getConnection(function(err, connection) {
        if (err) {
            error(err);
            return;
        }
        connection.query(query, values, function(err, rows) {
            connection.release();
            //console.log("imprimiendo error: "+err);
            //console.log("termina imprimir error.");
            if (!err) {
                success(JSON.parse(JSON.stringify(rows)));
                //success(JSON.parse(rows));
                return;
            }
            else
                error(err);
        });

        connection.on('error', function(err) {
            //console.log("evento de error: "+err);
            error(err);
            //console.log("termina evento de error.");
            return;
        });
    });
};

var conecta = function(success, error){
    pool.getConnection(function(err, connection) {
        //si existe un error, se retorna el error
        if (err) {
            error(err);
            return;
        }

        connection.on('error', function(err) {
            //console.log("evento de error: "+err);
            error(err);
            //console.log("termina evento de error.");
            return;
        });

        success(connection);

    });
};

var ejecutaQuery = function(connection, query, values, success, error){
    connection.query(query, values, function(err, rows) {
        if (!err) {
            if(success)
                success(JSON.parse(JSON.stringify(rows)));
        }
        else{
            error(err);
            return connection.rollback(function() {
                error("Error en rollback.");
            });
        }
    });
};

var commitTransaction = function(connection, success, error){
    connection.commit(function(err) {
        if (err) {
          return connection.rollback(function() {
            error(err);
          });
        }
        success();
      });
};

module.exports = {
    queryMySQL: queryMySQL,
    conecta: conecta,
    ejecutaQuery: ejecutaQuery,
    commitTransaction: commitTransaction
};