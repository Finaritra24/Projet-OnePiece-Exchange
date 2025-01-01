CREATE TABLE Team (
    teamID INT PRIMARY KEY IDENTITY(1,1),
    denomination NVARCHAR(100)
);

CREATE TABLE Pirate (
    pirateID INT PRIMARY KEY IDENTITY(1,1),
    denomination NVARCHAR(100),
    teamID INT,
    status NVARCHAR(50) NULL,
    FOREIGN KEY (teamID) REFERENCES Team(teamID)
);

CREATE TABLE Category (
    catagoryID INT PRIMARY KEY IDENTITY(1,1),
    denomination NVARCHAR(100)
);

CREATE TABLE Treasure (
    treasureID INT PRIMARY KEY IDENTITY(1,1),
    categoryID INT,
    denomination NVARCHAR(100),
    password NVARCHAR(100),
    description NVARCHAR(255),
    price DECIMAL(18, 2),
    pirateID INT,
    dateCreation DATE DEFAULT GETDATE(),
    FOREIGN KEY (pirateID) REFERENCES Pirate(pirateID),
    FOREIGN KEY (categoryID) REFERENCES Category(categoryID)
);

CREATE TABLE Proposal (
    proposalID INT PRIMARY KEY IDENTITY(1,1),
    proposedTreasureID INT,
    proposingPirateID INT,
    requestingPirateID INT,
    proposedOfferAmount DECIMAL(18, 2) NULL,
    counterOfferAmount DECIMAL(18, 2) NULL,
    category INT NULL,
    state INT DEFAULT 0,
    dateProposal DATE DEFAULT GETDATE(),
    dateReplyProposal DATE,
    FOREIGN KEY (proposingPirateID) REFERENCES Pirate(pirateID),
    FOREIGN KEY (requestingPirateID) REFERENCES Pirate(pirateID),
    FOREIGN KEY (proposedTreasureID) REFERENCES Treasure(treasureID)
);

