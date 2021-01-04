package com.example.mainactivity

object User {
    var UserID: Int = 0
    var UserName: String = ""
}

class UserClass(
    var UserID: Int,
    var UserName: String
)

object Resources {
    var Gold: Int = -1
    var Nuggets: Int = -1
    var Bars: Int = -1
    var Minespd: Int = 0
    var MineHarvest: Int = 0
    var PermUpgrade: Int = 1
    var FirstTime: Int = 0
}

class ResourcesClass(
    var Gold: Int,
    var Nuggets: Int,
    var Bars: Int,
    var MineSpd: Int,
    var MineHarvest: Int,
    var PermUpgrade: Int,
    var FirstTime: Int
)

