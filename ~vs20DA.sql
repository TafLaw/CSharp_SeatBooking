USE master;
GO

CREATE DATABASE SeatBooking;
GO

USE SeatBooking
Go

CREATE TABLE Company(
	CompanyID int IDENTITY(1,1) NOT NULL,
	CompanyEmail varchar(120) NOT NULL,
	CompanyPassword varchar(120) NOT NULL,
	CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);
GO

CREATE TABLE Users(
	UserID int IDENTITY(1,1) NOT NULL,
	UserEmail varchar(120) NOT NULL,
	UserPassword varchar(120) NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);
GO

CREATE TABLE Cart
(
    ID int NOT NULL,
    UserId Int IDENTITY PRIMARY KEY,
    SeatId Varchar(255) NOT NULL,
    EventId int NOT NULL,
)

CREATE TABLE Event_
(
    EventID int IDENTITY PRIMARY KEY NOT NULL,
    EventName Varchar(255) NOT NULL,
    EventImage Varchar(255) NULL,
    EventDesc Varchar(255) NULL,
    VenueID int NOT NULL
)

INSERT INTO Event_
	(
		EventName,
		VenueID
	)
	VALUES ('The Teminator, the dark faith', 1),('Gemini Man', 1),('Joker', 1)
CREATE TABLE Seat
(
    SeatID int IDENTITY (1,1) PRIMARY KEY,
    UserID int NULL,
	VenueID int NOT NULL,
	SeatNumber int NOT NULL,
    SeatCatergory int NOT NULL,
    SeatXCordinate int NOT NULL,
    SeatYCordinate int NOT NULL
)

CREATE TABLE Venue
(
    VenueID int IDENTITY PRIMARY KEY NOT NULL,
    FisrtName Varchar(255) NOT NULL,
    CompanyID int NOT NULL,
)

CREATE TABLE AddVenue
(CompanyId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
VenueName varchar(255),
Map varchar(255)
); 

CREATE TABLE Product
(ProductID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Maker varchar (255),
    ProductUrl varchar(255),
    ProductImg varchar(255),
    ProductTitle varchar(255),
    ProductDescription varchar(255),
    ProductRatings int,
    );
	
	CREATE TABLE SeatList
( UserId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
 EventID varchar (255),
 SeatList varchar (255)
 );