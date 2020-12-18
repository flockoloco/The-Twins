var http = require('http');
const mysql = require('mysql2');
var express = require('express');
var cors = require('cors');
var bodyParser = require('body-parser');
var playersRouter = require('./routes/players');
const hostname = '127.0.0.1';
const port = 3131;
dbcon = mysql.createConnection({
host: 'localhost',
user: 'root',
password: 'root',
database: 'nodejs_db'
});
dbcon.connect(function(err) {
if (err) throw err;
console.log("MySQL Connected!");
});

var app = express();
app.use(cors())
app.use(bodyParser.json());
app.use('/players', playersRouter);
app.listen(port, hostname, () => console.log(`Server running at
http://${hostname}:${port}/`));