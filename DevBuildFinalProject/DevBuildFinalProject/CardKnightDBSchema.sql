create database CardKnight
go
use CardKnight
go
create table Character (
	Id int identity(1,1) primary key not null,
	CharName nvarchar(20) not null,
	Hp int not null,
	Ap int not null,
	Progress int not null,
	Player bit not null
);
go
create table Card (
	Id int identity(1,1) primary key not null,
	CardName varchar(100) not null,
	Cost int not null,
	Info varchar(120) not null,
	Modifier int not null,
	CardType varchar(20) not null
);
go
create table Deck (
	Id int identity(1,1) primary key not null,
	CharId int foreign key references Character(Id),
	CardId int foreign key references Card(Id)
);
go
create table Equipment (
	Id int identity(1,1) primary key not null,
	EquipName varchar(30) not null,
	Info varchar(120) not null,
	Modifier int not null,
	EquipType varchar(20) not null
);
go
create table PremadeDeck (
	Id int identity(1,1) primary key not null,
	DeckId int not null,
	DeckName varchar(30) not null,
	CardId int foreign key references Card(Id)
);
go
create table CurrentUser (
	Id int identity(1,1) primary key not null,
	UserId int foreign key references Character(Id)
);
go
--end create DB

--populate DB

--cards
INSERT INTO Card (CardName, Cost, Info, Modifier, CardType)
VALUES('Heavy Cleave',3,'This is a heavy attack dealing high damage',8,'Attack'),
('Strike',1,'This is a basic attack dealing low damage',2,'Attack'),
('Mid Strike',2,'This attack provides mid level damage',5,'Attack'),
('Mass Slight cure Wounds',1,'heals player for small amount of health',3,'Heal'),
('Cure Major Damage',3,'Cures large amount of HP',7,'Heal'),
('Mid cure wounds',2,'heals player mid amount of health',5,'Heal'),
('Block',1,'Defend agaisnt small amount of damage',3,'Defend'),
('Harder block',2,'Defend agaisnt normal amount of damage',6,'Defend'),
('Fortress',3,'Defends agaisnt heavy amount of damage',10,'Defend'),
('Lighting Strike',2,'Basic lightning attack',4,'Attack'),
('Twin Lighting Dragon',4,'Lightning attack with AOE damage',11,'Attack'),
('Round House Kick',1,'Kicks enemy with sweeping motion',2,'Attack'),
('Head-Butt',3,'Attacks enemy with a headbutt that cracks earth',7,'attack'),
('Dodge',2,'Dodges in coming attack, limiting damage',6,'Defend'),
('groin shot',1,'cheap shot to opponents groin',3,'Attack'),
('The Goal of all life is death',4,'Wide range AOE spell dealing massive damage to everyone on the field',10,'Attack'),
('Greater Heal',4,'Massivily heals player HP',11,'Heal'),
('Holy Smite',2,'Calls Holy light down to damage foes',6,'Attack'),
('Black Hole',2,'Summons a black hole to devour enemies',5,'Attack'),
('Quick Evasion',1,'edvades small amount of damage from incoming attack',4,'Defend'),
('Tempest',3,'Deals massive damage to foes',9,'Attack'),
('FireBall',1,'summons a small fire ball',4,'Attack'),
('Grasp Heart',4,'crushes foes heart from long distance',11,'Attack'),
('Crystal Wall',2,'Summons a wall of crsytal to protect player',6,'Defend'),
('Healing Mist',3,'create mist that restores HP',9,'Heal'),
('Power of Gaia',4,'Summons Gaia to restore massive HP',12,'Heal'),
('Sharks Cyclone',4,'summons a torando filled with 6 meter long sharks',15,'Heal'),
('Rock Bottom',3,'The Most Electrifying Move in Sports Enterainment',9,'Attack'),
('Sweet Chin Music',2,'Super fast Side kick to foe''s face',6,'Attack'),
('Fox Sleep',2,'Defend from slight damage',6,'Defend'),
('Lysol Uppercut',2,'Deals damage while cleaning!',5,'Attack');
go
--Enemies/player
INSERT INTO Character (CharName, HP, AP, Progress, Player)
VALUES ('PlayerOne', 20, 3, 0, 1), 
('Goblin',15,3,0,0),
('Slime',10,1,1,0),
('Rabid Beast',10,3,2,0),
('Troll',25,3,3,0),
('Dragon',35,4,4,0);
go
--Equipment
INSERT INTO Equipment (EquipName, Info, Modifier, EquipType)
VALUES ('Great Sword', 'This sword was forged from rare metals. Grants 3 attack damage ', 3, 'Attack'),
('War Hammer',  'This hammer grants 2 AP', 2, 'AP-Boost'),
('Mage Staff',  'You shall not pass. Adds 5 to HP', 5, 'HP'),
('Necklace', 'Created from a dragon''s tears. Grants 3 defense', 3, 'Defense');
go 
--Starter Deck
insert into PremadeDeck (DeckId, DeckName, CardId)
values(1, 'Starter Deck', 1),
(1, 'Starter Deck', 2),
(1, 'Starter Deck', 3),
(1, 'Starter Deck', 4),
(1, 'Starter Deck', 5),
(1, 'Starter Deck', 6),
(1, 'Starter Deck', 7),
(1, 'Starter Deck', 8),
(1, 'Starter Deck', 9),
(1, 'Starter Deck', 10);
--end populate DB



----dummy data/testing data
--insert into card (CardName, Cost, Info, Modifier, CardType) 
--values ('Slash', 2, 'Standard sword slash', 3, 'Attack'),
--('Wild Swing', 1, 'Wildly swing around', 2, 'Attack')
--go

--insert into Character (CharName, Hp, Ap, Progress, Player)
--values ('Soc', 20, 3, 0, 1),
--('Brandon', 20, 3, 0, 1),
--('O', 20, 3, 0, 1) 
--go

--insert into deck (CharId, CardId)
--values (1,2)
--go

----Return Char with id 1 and all cards associated

--select Character.CharName, Card.*
--from Deck
--	left join Card on Card.Id = Deck.CardId
--	left join Character on Character.Id = Deck.CharId
--where CharId = 1
--go
