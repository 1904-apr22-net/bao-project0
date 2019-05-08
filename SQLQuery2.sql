--CREATE DATABASE GameStore;


--DROP TABLE Store;
CREATE TABLE Store(
	StoreId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	State NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_StoreId PRIMARY KEY (StoreId)
);

--DROP TABLE Customer;
CREATE TABLE Customer(
	CustomerId INT NOT NULL IDENTITY,
	FirstName NVARCHAR(200) NOT NULL,
	LastName NVARCHAR(200) NOT NULL,
	DefaultStore INT,
	CONSTRAINT PK_CustomerId PRIMARY KEY(CustomerId),
	FOREIGN KEY (DefaultStore) REFERENCES Store(StoreId)
);

--DROP TABLE Game;
CREATE TABLE Game(
	GameId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Price MONEY NOT NULL,
	CONSTRAINT PK_GameId PRIMARY KEY(GameId)
);

--DROP TABLE GameOrder;
CREATE TABLE GameOrder(
	OrderId INT NOT NULL IDENTITY,
	CustomerId INT,
	StoreId INT,
	OrderTime DATETIME NOT NULL,
	CONSTRAINT PK_OrderId PRIMARY KEY(OrderId),
	FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
	FOREIGN KEY (StoreId) REFERENCES Store(StoreId)
);

--DROP TABLE OrderItem;
CREATE TABLE OrderItem(
	OrderItemId INT NOT NULL IDENTITY,
	OrderId INT,
	GameId INT,
	Quantity INT DEFAULT 0,
	CONSTRAINT PK_OrderItemId PRIMARY KEY(OrderItemId),
	FOREIGN KEY (OrderId) REFERENCES GameOrder(OrderId), 
	FOREIGN KEY (GameId) REFERENCES Game(GameId)
);

--DROP TABLE ItemInventory;
CREATE TABLE ItemInventory(
	ItemInventoryId INT NOT NULL IDENTITY,
	StoreId INT,
	GameId INT,
	Quantity INT DEFAULT 0,
	CONSTRAINT PK_ItemInventoryId PRIMARY KEY(ItemInventoryId),
	FOREIGN KEY (StoreId) REFERENCES Store(StoreId),
	FOREIGN KEY (GameId) REFERENCES Game(GameId)
);

--Store
INSERT INTO GameStore (Name, State) VALUES
	('GameStop','Illinois');

INSERT INTO Store (Name, State) VALUES
	('Target','Michigan');

INSERT INTO Store (Name, State) VALUES
	('Disc Replay','Oregon');

INSERT INTO Store (Name, State) VALUES
	('Walmart','Florida');

INSERT INTO Store (Name, State) VALUES
	('Best Buy','Virginia');

--Customer
INSERT INTO Customer(FirstName, LastName, DefaultStore) VALUES
	('John','Smith',1);

INSERT INTO Customer(FirstName, LastName, DefaultStore) VALUES
	('Jane','Smith', 3);

INSERT INTO Customer(FirstName, LastName, DefaultStore) VALUES
	('Jackie','Chan', 1);

INSERT INTO Customer(FirstName, LastName, DefaultStore) VALUES
	('Willian','Mendez', 5);

--Game
INSERT INTO Game(Name, Price) VALUES
	('Call of Duty', 59.99);

INSERT INTO Game(Name, Price) VALUES
	('Halo 4', 49.99);

INSERT INTO Game(Name, Price) VALUES
	('Final Fantasy XV', 59.99);

INSERT INTO Game(Name, Price) VALUES
	('Gears of War 4', 49.99);

INSERT INTO Game(Name, Price) VALUES
	('Chess', 9.99);

INSERT INTO Game(Name, Price) VALUES
	('Sonic Adventure 2', 29.99);

INSERT INTO Game(Name, Price) VALUES
	('Summoners War', 0);

--GameOrder
INSERT INTO GameOrder (CustomerId, StoreId, OrderTime) VALUES
	(4, 5, '2014-1-6');

INSERT INTO GameOrder (CustomerId, StoreId, OrderTime) VALUES
	(1,3, '2018-4-7 12:47:31');

INSERT INTO GameOrder (CustomerId, StoreId,OrderTime) VALUES
	(3,3,'2019-3-4 01:12:50');

INSERT INTO GameOrder (CustomerId, StoreId,OrderTime) VALUES
	(2,2,'2019-4-29 19:21:01');


--OrderItem
INSERT INTO OrderItem (Quantity,GameId, OrderId) VALUES 
	(2, 4, 1);

INSERT INTO OrderItem (Quantity,GameId, OrderId) VALUES 
	(1, 2, 2);

INSERT INTO OrderItem (Quantity,GameId, OrderId) VALUES 
	(1, 6, 3);

INSERT INTO OrderItem (Quantity,GameId, OrderId) VALUES 
	(1, 7, 4);

--ItemInventory

INSERT INTO ItemInventory (StoreId, GameId, Quantity) VALUES
	(4,1,50);

INSERT INTO ItemInventory (StoreId, GameId, Quantity) VALUES
	(3,2,50);

INSERT INTO ItemInventory (StoreId, GameId, Quantity) VALUES
	(4,2,50);

INSERT INTO ItemInventory (StoreId, GameId, Quantity) VALUES
	(1,3,50);

INSERT INTO ItemInventory (StoreId, GameId, Quantity) VALUES
	(2,3,50);

INSERT INTO ItemInventory (StoreId, GameId, Quantity) VALUES
	(5,1,50);

