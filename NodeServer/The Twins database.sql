CREATE DATABASE TheTwins;
USE TheTwins;
CREATE TABLE User(
    UserID int auto_increment not null, 
    UserName varchar(255),
    UserPassword varchar(255),
    primary key (UserID)
);
CREATE TABLE MainGame(
    UserID_FK_MainGame int,
    CurrentSwordID int,
    CurrentArmorID int,
    CurrentHP int,
    MaxHP int,
    Gold int,
    Nuggets int,
    Bars int,
    Potions int,
    Arrows int,
    CurrentLevel int,
    constraint foreign key (UserID_FK_MainGame) references User(UserID)
    );
CREATE TABLE CurrentEnchant(
    UserID_FK_Enchant int,
    EquipID int,
    EnchantTier int,
    constraint foreign key (UserID_FK_Enchant) references User(UserID)
);
CREATE TABLE Delivery(
	UserID_FK_Delivery int,
    BarsForCapp int,
    OresForCapp int,
    BarsForGame int,
    OresForGame int,
	constraint foreign key (UserID_FK_Delivery) references User(UserID)
);
CREATE TABLE CApp(
    UserID_FK_CApp int,
    Gold int,
    Nuggets int,
    Bars int,
    MineSpd int,
    MineHarvest int,
    PermUpgrade int,
    FirstTime int,
    constraint foreign key(UserID_FK_CApp) references User(UserID)
);