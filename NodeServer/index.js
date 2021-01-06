const mysql = require('mysql2');
const express = require('express');
const path = require("path");
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
//registers the player

app.post('/register', (req, res, next) => {

	var data = req.body;

	var Username = data.Username;
	var Password = data.Password;

	dbcon.query('SELECT * FROM User WHERE UserName=?', [Username], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
		})
		if(result && result.length) //user already exists
		{	
			res.json(1);
		}
		else
		{
			dbcon.query('INSERT INTO `user`(`UserName`, `UserPassword`) VALUES (?,?)', [Username, Password], function(err, result, fields){
				dbcon.on('error', function(err){
					console.log('[MYSQL ERROR]', err);
					res.json('Register user error: ', err);
				})
				res.json(0);
			})
		}
	})
});
//logs the player
app.post('/login', (req, res, next) => {

	var data = req.body;

	var Username = data.Username;
	var Password = data.Password;

	dbcon.query('SELECT * FROM User WHERE UserName=?', [Username], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
		})
		if(result && result.length)
		{
			if(Password == result[0].UserPassword)
			{//meter status good job
				res.end(JSON.stringify(result[0]));
			}
			else
			{//meter status wrong passs
				res.end(JSON.stringify(result[0]));
			}
		}
		else{//meter status no user
			res.json('User does not exists');
		}
	})
});

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
});

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
});

app.post('/getGameCurrency', (req, res, next) => {
	var data = req.body;
	var UserID = data.UserID;
	dbcon.query('SELECT * FROM thetwins.GameCurrency WHERE UserID_FK_GameCurrency=?', [UserID], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
		})
		if (result && result.length >= 1)
		{
			res.end(JSON.stringify(result[0]));
		}
		else
		{
			dbcon.query('INSERT INTO `GameCurrency`(`UserID_FK_GameCurrency`, `Bars`, `Ores`) Values (?,?,?) ', [UserID, 0, 0], function(err, result, fields){
				dbcon.on('error', function(err){
					console.log('[MYSQL ERROR]', err);
				})
				dbcon.query('SELECT * FROM thetwins.GameCurrency WHERE UserID_FK_GameCurrency=?', [UserID], function(err, result, fields){ 
					dbcon.on('error', function(err){
						console.log('[MYSQL ERROR]', err);
					})
					res.end(JSON.stringify(result[0]));
				})
			})
		}
	})
});

app.post('/saveCurrency', (req, res, next) => {
	var data = req.body;
	dbcon.query('UPDATE thetwins.GameCurrency SET Ores = ?, Bars = ? WHERE UserID_FK_GameCurrency = ?', [data.Ores, data.Bars, data.UserID], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
			res.json('Currency Error: ', err);
		})
		if(result && result.length){
			res.end("yaaaaay");
		}
		res.end(JSON.stringify('User Updated'));

	})
});

app.post('/loadRun', (req, res, next) => {
	var data = req.body;
	console.log("e boa");
	dbcon.query('SELECT * FROM thetwins.MainGame WHERE UserID_FK_MainGame = ?', [data.UserID], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
		})
		if(result && result.length){
			if ((result[0].currentLvl == 0) || (result[0].currentHP <= 0)){
				dbcon.query('UPDATE TheTwins.MainGame SET eSwordID = ?, eArmorID = ?, currentLvl = ?, currentHP = ?, oreArrowAmount = ?, normalArrowAmount = ?, potsAmount = ?, gold = ? WHERE UserID_FK_MainGame = ?', [0, 4, 0, 100, 0, 0, 0, 200, data.UserID], function(err, result, fields){
					dbcon.on('error', function(err){
						console.log('[MYSQL ERROR]', err);
					})
					dbcon.query('SELECT * FROM thetwins.MainGame WHERE UserID_FK_MainGame = ?', [data.UserID], function(err, result0, fields){
						dbcon.on('error', function(err){
							console.log('[MYSQL ERROR]', err);
						})
						res.end(JSON.stringify(result0[0]));
					})
				})
			}else{
				res.end(JSON.stringify(result[0]));
			}
		}
		else
		{
			dbcon.query('INSERT INTO TheTwins.MainGame (UserID_FK_MainGame,eSwordID, eArmorID, currentLvl, currentHP, oreArrowAmount, normalArrowAmount, potsAmount, gold) VALUES (?,?,?,?,?,?,?,?,?)', [data.UserID,0, 0, 0, 100, 0, 0, 0, 200], function(err, result, fields){
				dbcon.on('error', function(err){
					console.log('[MYSQL ERROR]', err);
				})
				dbcon.query('SELECT * FROM thetwins.MainGame WHERE UserID_FK_MainGame = ?', [data.UserID], function(err, result0, fields){
					dbcon.on('error', function(err){
						console.log('[MYSQL ERROR]', err);
					})
					res.end(JSON.stringify(result0[0]));
				})
			})
		}
	})
});

app.post('/saveRun', (req, res, next) => {
	var data = req.body;

	dbcon.query('UPDATE TheTwins.MainGame SET eSwordID = ?, eArmorID = ?, currentLvl = ?, currentHP = ?, oreArrowAmount = ?, normalArrowAmount = ?, potsAmount = ?, gold = ? WHERE UserID_FK_MainGame = ?', [data.eSwordID, data.eArmorID, data.currentLvl, data.currentHP, data.oreArrowAmount, data.normalArrowAmount, data.potsAmount, data.gold, data.UserID], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
		})
		if(result && result.length){
			res.end("yaaaaay");
		}
	})
});

app.post('/loadEnchants', (req, res, next) => {
	var data = req.body;
	console.log("pessoa.")
	dbcon.query('SELECT * FROM thetwins.CurrentEnchant WHERE UserID_FK_Enchant = ?', [data.UserID], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
		})
		if(result && result.length){
			res.end(JSON.stringify(result[0]));
		}
		else
		{
			dbcon.query('	INSERT INTO `CurrentEnchant` (`UserID_FK_Enchant`, `e0tier`, `e1tier`, `e2tier`, `e3tier`, `e4tier`, `e5tier`, `e6tier`, `e7tier`) Values (?,?,?,?,?,?,?,?,?)', [data.UserID, 0,0,0,0,0,0,0,0], function(err, result, fields){
				dbcon.on('error', function(err){
					console.log('[MYSQL ERROR]', err);
				})
				dbcon.query('SELECT * FROM thetwins.CurrentEnchant WHERE UserID_FK_Enchant = ?', [data.UserID], function(err, result0, fields){
					dbcon.on('error', function(err){
						console.log('[MYSQL ERROR]', err);
					})
					if(result && result.length){
						console.log("hueheuheuehue");
						console.log(result0[0]);
						result.end(JSON.stringify(result0[0]));
					}
				})
			})
		}
	})
});

app.post('/saveEnchants', (req, res, next) => {
	var data = req.body;

	dbcon.query('UPDATE TheTwins.CurrentEnchant SET e0tier = ?,e1tier = ?,e2tier = ?,e3tier = ?,e4tier = ?,e5tier = ?,e6tier = ?,e7tier = ?  WHERE UserID_FK_Enchant = ?', [data.e0tier, data.e1tier, data.e2tier, data.e3tier, data.e4tier, data.e5tier, data.e6tier, data.e7tier, data.UserID], function(err, result, fields){
		dbcon.on('error', function(err){
			console.log('[MYSQL ERROR]', err);
		})
		if(result && result.length){
			res.end("yaaaaay");
		}
	})
});