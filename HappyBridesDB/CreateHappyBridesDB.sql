USE master
IF EXISTS(select * from sys.databases where name='HappyBrides')
DROP DATABASE HappyBrides;
CREATE DATABASE HappyBrides;

CREATE TABLE HappyBrides.dbo.Couple(
	CoupleID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UserName nvarchar(150) NOT NULL,
	PassWord nvarchar(50) NOT NULL
);

CREATE TABLE HappyBrides.dbo.Wishlist(
	WishListID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UniqueCode nvarchar(8) NOT NULL,
	CoupleID int FOREIGN KEY REFERENCES HappyBrides.dbo.Couple(CoupleID) NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	SecondName nvarchar(50) NOT NULL
);
CREATE TABLE HappyBrides.dbo.Contributor(
	ContributorID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ContributorName nvarchar(50) NOT NULL,
	ContributorMessage nvarchar(500) NULL
);
CREATE TABLE HappyBrides.dbo.WishListItem(
	ItemID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Description nvarchar(250) NOT NULL,
	Price money NOT NULL,
	Position INT NOT NULL,
	IsClaimed bit NULL,
	ContributorID INT FOREIGN KEY REFERENCES HappyBrides.dbo.Contributor(ContributorID) NULL,
	ListID INT FOREIGN KEY REFERENCES HappyBrides.dbo.Wishlist(WishListID) NOT NULL
);