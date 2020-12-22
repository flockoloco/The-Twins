var http = require('http');
const mysql = require('mysql2');
<<<<<<< HEAD
const express = require('express');
const path = require("path")
const cors = require('cors');
const bodyParser = require('body-parser');

<<<<<<< HEAD
=======
var express = require('express');
var cors = require('cors');
var bodyParser = require('body-parser');
var playersRouter = require('./routes/players');
>>>>>>> parent of e6ff177... commit apenas para mim se o casa abrir é gay haahaha
=======
const login = require(path.join(__dirname, "routers", "login.js"))

>>>>>>> parent of 2080c1f... minor fix
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