const mysql = require('mysql2');
const express = require('express');
const path = require("path")
const cors = require('cors');
const bodyParser = require('body-parser');
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
app.listen(port, hostname, () => console.log(`Server running at http://${hostname}:${port}`));
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
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
            if(Password == result[0].UserPassword){
                res.end(JSON.stringify(result[0]));
            }
            else
            res.end(JSON.stringify('Wrong password'));
        }else
            res.json('User does not exists')
    })
})

//create the user for the companion app
app.post('/user', (req, res, next) => {
	var data = req.body;

	var UserID = data.UserID;

	dbcon.query('SELECT * FROM thetwins.capp WHERE UserID_FK_CApp=?', [UserID], function(err, result, fields){
		 dbcon.on('error', function(err){
            console.log('[MYSQL ERROR]', err);
        })
		 if(result && result.length){
		 	res.end(JSON.stringify(result[0]));
		 }
		 else
		 {
		 	dbcon.query('INSERT INTO `capp`(`UserID_FK_CApp`, `Gold`, `Nuggets`, `Bars`, `MineSpd`, `MineHarvest`, `PermUpgrade`, `FirstTime`) VALUES (?,?,?,?,?,?,?,?)', [UserID, 100, 10, 0, 0, 0, 1, 0], function(err, result, fields){
		 		dbcon.on('error', function(err){
                    console.log('[MYSQL ERROR]', err);
                    res.json('Companion app error: ', err);
                })
			})	
		}
		dbcon.query('SELECT * FROM thetwins.capp WHERE UserID_FK_CApp=?', [UserID], function(err, result, fields){
		 dbcon.on('error', function(err){
            console.log('[MYSQL ERROR]', err);
        })
		 if(result && result.length){
		 	res.end(JSON.stringify(result[0]));
		 }
		})
	})
})

//Save the data from the companion app to the database after the player closes the app
app.post('/sendDB', (req, res, next) => {
	var data = req.body;

	var UserID = data.UserID
	var Gold = data.Gold;
    var Nuggets = data.Nuggets;
    var Bars = data.Bars;
    var Minespd = data.Minespd;
    var MineHarvest = data.MineHarvest;
    var PermUpgrade = data.PermUpgrade;
    var FirstTime = data.FirstTime;

    dbcon.query('UPDATE thetwins.capp SET Gold = ?, Nuggets = ?, Bars = ?, MineSpd = ?, MineHarvest = ?, PermUpgrade = ?, FirstTime = ? WHERE UserID_FK_CApp = ?', [Gold, Nuggets, Bars, Minespd, MineHarvest, PermUpgrade, FirstTime, UserID], function(err, result, fields){
		 dbcon.on('error', function(err){
            console.log('[MYSQL ERROR]', err);
                res.json('Companion app error: ', err);
            })
		res.end(JSON.stringify('User Updated'));
    })
})


app.post('/getPlayerSave', (req, res, next) => { //not connected for now.
	var data = req.body;
	var UserID = data.UserID;

	dbcon.query('SELECT * FROM thetwins.MainGame WHERE UserID_FK_User=?', [UserID], function(err, result, fields){
			dbcon.on('error', function(err){
        	console.log('[MYSQL ERROR]', err);
      })
			if(result && result.length){
		 		res.end(JSON.stringify(result[0]));
	 		}
	})
})