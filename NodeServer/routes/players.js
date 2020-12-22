var express = require('express');
var router = express.Router();
router.get('/list', function(req, res) {
let sql = `SELECT username, score FROM players`;
dbcon.query(sql, function(err, players, fields) {
if (err) throw err;
res.json({players})
})
});

router.post('/new', function(req, res) {
let sql = `INSERT INTO players(username, password, score) VALUES (?)`;
let values = [
req.body.username,
req.body.password,
0
];
dbcon.query(sql, [values], function(err, data, fields) {
if (err) throw err;
res.json({
status: 200,
message: "New player added successfully"
})
})
});

router.post('/setscore', function(req, res) {
let sql = `UPDATE players SET score = ? WHERE id = ?`;
let values = [
req.body.score,
req.body.id
];
dbcon.query(sql, values, function(err, data, fields) {
if (err) throw err;
res.json({
status: 200,
message: "Score updated successfully"
})
})
});
module.exports = router;