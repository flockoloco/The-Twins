const mysql = require('mysql2');
const express = require('express');
const path = require("path")
const cors = require('cors');
const bodyParser = require('body-parser');

const login = require(path.join(__dirname, "routers", "login.js"))

const hostname = '127.0.0.1';
const port = 3000;

dbcon = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: 'root',
    database: 'TheTwins'
});

dbcon.connect(function(err) {
    if (err) throw err;
        console.log("Server Connected!");
});

var app = express();

app.use(cors())
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }))
app.listen(port, hostname, () => console.log(`Server running at http://${hostname}:${port}/`));

app.post('/register', (req, res, next) => {

    var data = req.body;

    var Username = data.Username;
    var Password = data.Password;

    dbcon.query('SELECT * FROM User WHERE UserName=?', [Username], function(err, result, fields){
        dbcon.on('error', function(err){
            console.log('[MYSQL ERROR]', err);
        })
        if(result && result.length){
                res.json('User alerady exists');
        }else{
            dbcon.query('INSERT INTO `user`(`UserName`, `UserPassword`) VALUES (?,?)', [Username, Password], function(err, result, fields){
                dbcon.on('error', function(err){
                    console.log('[MYSQL ERROR]', err);
                    res.json('Register user error: ', err);
                })
        
                res.json('Register successful');
            })
        }
    })
})

app.post('/login', (req, res, next) => {

    var data = req.body;

    var Username = data.Username;
    var Password = data.Password;
    
    dbcon.query('SELECT * FROM User WHERE UserName=?', [Username], function(err, result, fields){
        dbcon.on('error', function(err){
            console.log('[MYSQL ERROR]', err);
        })
        if(result && result.length){
            if(Password == result[0].UserPassword)
                res.end(JSON.stringify(result[0]));
            else
            res.end(JSON.stringify('Wrong password'));
        }else
            res.json('User does not exists')
    })
})
