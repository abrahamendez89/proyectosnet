var express = require('express'),
    app = express(),
    redis = require("redis");


var client = redis.createClient(6379, '192.168.56.101',
{
    password:12345
}); //port, host

client.on("error", function (err) {
    console.log("Error " + err);
});
 
/*
client.set("string key", "string val", redis.print);
client.hset("hash key", "hashtest 1", "some value", redis.print);
client.hset(["hash key", "hashtest 2", "some other value"], redis.print);
client.hkeys("hash key", function (err, replies) {
    console.log(replies.length + " replies:");
    replies.forEach(function (reply, i) {
        console.log("    " + i + ": " + reply);
    });
    client.quit();
});
*/

var consulta = function(variable, callback){

     client.get(variable, function(err, reply){
        //console.log("Valor: "+reply);
        callback(reply);
    });
};

module.exports = {
    consulta: consulta
};