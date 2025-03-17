CREATE TABLE Center (
    CenterID CHAR(10),
    NameCenter NVARCHAR(50),
    StaffID CHAR(10),
    EquipmentID CHAR(10),
    ActivityID CHAR(10),
    FinancialID CHAR(10),
    CharityActivityID CHAR(10),
    ChildID CHAR(10),
    FeedbackID CHAR(10),
	CustomerID char(10),
	VolunteerID Char(10),
	DonateID CHAR(10)

    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    FOREIGN KEY (EquipmentID) REFERENCES Equipment(EquipmentID),
    FOREIGN KEY (ActivityID) REFERENCES Activity(ActivityID),
    FOREIGN KEY (FinancialID) REFERENCES Financial(FinancialID),
    FOREIGN KEY (CharityActivityID) REFERENCES CharityActivity(CharityActivityID),
    FOREIGN KEY (ChildID) REFERENCES Children(ChildID),
    FOREIGN KEY (FeedbackID) REFERENCES Feedback(FeedbackID),
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
	FOREIGN KEY (VolunteerID) REFERENCES Volunteer(VolunteerID),
	FOREIGN KEY (DonateID) REFERENCES Donate(DonateID),
);

CREATE TABLE Account (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    UserType NVARCHAR(50) NOT NULL
);

CREATE TABLE Staff (
    StaffID Char(10) PRIMARY KEY,
	FirstName NVARCHAR(100),
	LastName NVARCHAR(100),
	Gender BIT,
	Age INT,
	DateOfBirth DATE,
	Email NVARCHAR(255),
	PhoneNumber NVARCHAR(20),
	Address VARCHAR(255),
	Salary DECIMAL(10, 2),
	Position VARCHAR(25),
	StartWorkDate Date,
	-- Add other relevant columns for customer information
    UserID INT FOREIGN KEY REFERENCES Account(UserID)
);

CREATE TABLE Volunteer (
    VolunteerID Char(10) PRIMARY KEY,
	FirstName NVARCHAR(100),
	LastName NVARCHAR(100),
	Gender BIT,
	Age INT,
	DateOfBirth DATE,
	DateStartVolunteer Date,
	Email NVARCHAR(255),
	PhoneNumber NVARCHAR(20),
	Address VARCHAR(255),
	Position VARCHAR(25),
);

CREATE TABLE Customers (
    CustomerID Char(10) PRIMARY KEY,
	FirstName NVARCHAR(100),
	LastName NVARCHAR(100),
	Gender BIT,
	Age INT,
	DateOfBirth DATE,
	Email NVARCHAR(255),
	PhoneNumber NVARCHAR(20),
	Address VARCHAR(255),
    -- Add other relevant columns for customer information
    UserID INT FOREIGN KEY REFERENCES Account(UserID)
);

CREATE TABLE Children (
  ChildID CHAR(10) PRIMARY KEY,
  FirstName NVARCHAR(100),
  LastName NVARCHAR(100),
  Gender BIT,
  Age INT,
  DateOfBirth DATE,
  DateGetIntoCenter date
);

CREATE TABLE Equipment (
  EquipmentID CHAR(10) PRIMARY KEY,
  EquipmentName NVARCHAR(100),
  Amount INT
);

CREATE TABLE CharityActivity (
  CharityActivityID CHAR(10) PRIMARY KEY,
  CharityName NVARCHAR(100),
  CharityDescription VARCHAR(MAX),
  CharityDateTime DATETIME,
  Location VARCHAR(255),
  Organizer NVARCHAR(100),
  MoneyDonate DECIMAL(10, 2)
);

CREATE TABLE Activity (
  ActivityID CHAR(10) PRIMARY KEY,
  Name NVARCHAR(100),
  Time DATETIME,
  Location VARCHAR(255),
  Description VARCHAR(1000)
);

CREATE TABLE Adoption (
  AdoptionActivityID CHAR(10) PRIMARY KEY,
  ChildID CHAR(10),
  AdopterName NVARCHAR(100),
  AdopterContactInfo NVARCHAR(255),
  DateOfAdoption DATETIME,
  Status VARCHAR(50) DEFAULT 'Waiting' CHECK (Status IN ('Waiting', 'Completed', 'Cancelled', 'In Progress', 'Postponed')),
  Description varchar(1000),
  UserID int,
  FOREIGN KEY (UserID) REFERENCES Account(UserID) ON DELETE CASCADE,
  FOREIGN KEY (ChildID) REFERENCES Children(ChildID) ON DELETE CASCADE
);

CREATE TABLE IntroductionActivity (
  IntroductionActivityID CHAR(10) PRIMARY KEY,
  IntroducerName NVARCHAR(100),
  IntroducerContactInfo NVARCHAR(255),
  DateOfIntroduction DATE,
  Status VARCHAR(50) DEFAULT 'Waiting' CHECK (Status IN ('Waiting', 'Completed', 'Cancelled', 'In Progress', 'Postponed')), -- Default value set to 'Waiting'
  Description NVARCHAR(MAX),
  ChildrendName NVARCHAR(50),
  ChildrendLastName NVARCHAR(50),
  Gender BIT,
  DateOfBirth DATE,
  UserID int,
  FOREIGN KEY (UserID) REFERENCES Account(UserID) ON DELETE CASCADE,
);

CREATE TABLE Feedback (
  FeedbackID CHAR(10) PRIMARY KEY,
  UserId INT,
  Topic NVARCHAR(50),
  ContactInfo NVARCHAR(50),
  FeedbackDate DATETIME DEFAULT GETDATE(),
  FOREIGN KEY (UserID) REFERENCES Account(UserID) ON DELETE CASCADE
);

CREATE TABLE FeedbackMessages (
  MessageID INT IDENTITY(1,1) PRIMARY KEY,
  FeedbackID CHAR(10),
  UserId INT,
  MessageText VARCHAR(MAX),
  MessageDate DATETIME DEFAULT GETDATE(),
  FOREIGN KEY (FeedbackID) REFERENCES Feedback(FeedbackID) ON DELETE CASCADE, -- This line specifies the cascading delete constraint
  FOREIGN KEY (UserID) REFERENCES Account(UserID)
);

CREATE TABLE Financial (
  FinancialID CHAR(10) PRIMARY KEY,
  Description VARCHAR(1000),
  TotalMoney DECIMAL(10, 2),
  AmountSpend DECIMAL(10, 2),
  DataEntryDate date
);

CREATE TABLE Donate (
  DonateID CHAR(10) PRIMARY KEY,
  RequestName varchar(100),
  AmountRequest DECIMAL(10, 2),
  Description varchar(MAX),
  RequestDate date,
  Status VARCHAR(50) DEFAULT 'Waiting' CHECK (Status IN ('Waiting', 'Completed', 'Cancelled')),
);

-- Inserting data into the Account table
INSERT INTO Account (UserID, Username, Password, UserType)
VALUES 
(0, 'a', 'a', 'Admin'),
(1, 's', '1', 'Staff'),
(2, 'c', '1', 'Customer'),
(3, 'michael_johnson', 'pass123', 'Staff'),
(4, 'sarah_brown', 'password', 'Staff'),
(5, 'david_wilson', 'pwd123', 'Staff'),
(6, 'alice_smith', 'customerpwd', 'Customer'),
(7, 'emma_davis', 'emma123', 'Customer'),
(8, 'james_miller', 'millerpass', 'Customer'),
(9, 'olivia_wilson', 'olivia321', 'Customer'),
(10, 'ethan_jones', 'ethanpwd', 'Customer');

-- Inserting data into the Staff table
INSERT INTO Staff (StaffID, FirstName, LastName, Gender, Age, DateOfBirth, Email, PhoneNumber, Address, Salary, Position, StartWorkDate, UserID)
VALUES 
('S001', 'John', 'Doe', 1, 30, '1994-05-10', 'john@example.com', '1234567890', '123 Main St, City', 50000.00, 'Manager', '2020-01-01', 1),
('S002', 'Michael', 'Johnson', 1, 35, '1989-07-20', 'michael@example.com', '5556667777', '789 Oak St, City', 45000.00, 'Supervisor', '2019-09-10', 3),
('S003', 'Sarah', 'Brown', 0, 28, '1996-03-15', 'sarah@example.com', '9876543210', '456 Elm St, City', 40000.00, 'Assistant', '2021-03-15', 4),
('S004', 'David', 'Wilson', 1, 30, '1994-04-05', 'david@example.com', '1122334455', '321 Maple St, City', 42000.00, 'Coordinator', '2023-01-01', 5);

-- Inserting data into the Customers table
INSERT INTO Customers (CustomerID, FirstName, LastName, Gender, Age, DateOfBirth, Email, PhoneNumber, Address, UserID)
VALUES 
('C001', 'Alice', 'Smith', 0, 35, '1989-12-05', 'alice@example.com', '1112223333', '789 Oak St, City', 2),
('C002', 'Emma', 'Davis', 0, 40, '1984-06-20', 'emma@example.com', '4445556666', '456 Pine St, City', 7),
('C003', 'James', 'Miller', 1, 28, '1996-08-15', 'james@example.com', '9998887777', '123 Elm St, City', 8),
('C004', 'Olivia', 'Wilson', 0, 25, '1999-04-10', 'olivia@example.com', '3334445555', '789 Cedar St, City', 9),
('C005', 'Ethan', 'Jones', 1, 30, '1994-10-20', 'ethan@example.com', '6667778888', '321 Oak St, City', 10);

-- Inserting data into the Volunteer table
INSERT INTO Volunteer (VolunteerID, FirstName, LastName, Gender, Age, DateOfBirth, DateStartVolunteer, Email, PhoneNumber, Address, Position)
VALUES 
('V0001', 'Alice', 'Johnson', 0, 28, '1996-03-12', '2023-05-10', 'alice.johnson@example.com', '1234567890', '456 Elm St, Town, Country', 'Volunteer'),
('V0002', 'Michael', 'Smith', 1, 35, '1989-08-21', '2023-03-15', 'michael.smith@example.com', '2345678901', '789 Oak St, City, Country', 'Volunteer'),
('V0003', 'Emily', 'Brown', 0, 42, '1982-12-05', '2023-06-20', 'emily.brown@example.com', '3456789012', '123 Pine St, Village, Country', 'Volunteer'),
('V0004', 'Daniel', 'Martinez', 1, 25, '1999-01-18', '2023-07-01', 'daniel.martinez@example.com', '4567890123', '890 Maple St, Suburb, Country', 'Volunteer'),
('V0005', 'Olivia', 'Anderson', 0, 30, '1994-06-28', '2023-08-05', 'olivia.anderson@example.com', '5678901234', '456 Walnut St, Town, Country', 'Volunteer'),
('V0006', 'Matthew', 'Wilson', 1, 40, '1983-09-17', '2023-09-10', 'matthew.wilson@example.com', '6789012345', '789 Cherry St, City, Country', 'Volunteer'),
('V0007', 'Sophia', 'Taylor', 0, 22, '2002-11-30', '2023-10-15', 'sophia.taylor@example.com', '7890123456', '123 Oak St, Village, Country', 'Volunteer'),
('V0008', 'Ethan', 'Clark', 1, 32, '1990-04-07', '2023-11-20', 'ethan.clark@example.com', '8901234567', '890 Pine St, Town, Country', 'Volunteer');

-- Inserting data into the Children table
INSERT INTO Children (ChildID, FirstName, LastName, Gender, Age, DateOfBirth, DateGetIntoCenter) 
VALUES 
('CH001', 'Emily', 'Johnson', 0, 6, '2018-03-10', '2024-01-05'),
('CH002', 'Michael', 'Smith', 1, 5, '2019-05-20', '2024-02-10'),
('CH003', 'Sophia', 'Williams', 0, 7, '2017-12-15', '2024-03-20'),
('CH004', 'Jacob', 'Brown', 1, 8, '2016-09-30', '2024-04-15'),
('CH005', 'Olivia', 'Taylor', 0, 4, '2020-08-05', '2024-05-01');

-- Inserting data into the Equipment table
INSERT INTO Equipment (EquipmentID, EquipmentName, Amount) 
VALUES 
('E001', 'Playground Set', 5),
('E002', 'Art Supplies', 100),
('E003', 'Computers', 10),
('E004', 'Sports Equipment', 20),
('E005', 'Musical Instruments', 15);

-- Inserting data into the CharityActivity table
INSERT INTO CharityActivity (CharityActivityID, CharityName, CharityDescription, CharityDateTime, Location, Organizer, MoneyDonate) 
VALUES 
('CA001', 'Children Charity Event', 'Fundraiser for orphaned children', '2024-06-15 10:00:00', 'Central Park', 'Charity Foundation XYZ', 5000.00),
('CA002', 'Holiday Toy Drive', 'Collecting toys for underprivileged children', '2024-12-10 09:00:00', 'Community Center', 'Charity Organization ABC', 3000.00),
('CA003', 'Food Drive', 'Collecting non-perishable food items for the homeless', '2024-11-20 11:00:00', 'Local Church', 'Charity Group DEF', 2000.00),
('CA004', 'Fundraising Gala', 'Annual gala to raise funds for children in need', '2024-09-30 18:00:00', 'Hotel Ballroom', 'Charity Association GHI', 10000.00),
('CA005', 'Medical Aid Campaign', 'Raising funds for medical treatment of sick children', '2024-08-05 13:00:00', 'Hospital Auditorium', 'Healthcare Foundation JKL', 7000.00);

-- Inserting data into the Activity table
INSERT INTO Activity (ActivityID, Name, Time, Location, Description) 
VALUES 
('A001', 'Outdoor Games', '2024-05-20 15:00:00', 'Community Park', 'Fun outdoor games for children'),
('A002', 'Art and Craft Workshop', '2024-06-10 10:00:00', 'Center Hall', 'Creative activities for kids to express themselves'),
('A003', 'Sports Day', '2024-07-15 09:00:00', 'Sports Complex', 'Competitive sports events and games for children'),
('A004', 'Music Class', '2024-08-25 14:00:00', 'Music Room', 'Learning musical instruments and singing'),
('A005', 'Storytelling Session', '2024-09-10 11:00:00', 'Library', 'Engaging storytelling sessions for children');

-- Inserting data into the Adoption table
INSERT INTO Adoption (AdoptionActivityID, ChildID, AdopterName, AdopterContactInfo, DateOfAdoption, Status, Description, UserID) 
VALUES 
('AD001', 'CH001', 'Michael Johnson', 'michael.johnson@example.com', '2024-04-10', 'Completed', 'I like him', 2),
('AD002', 'CH002', 'Sarah Wilson', 'sarah.wilson@example.com', '2024-03-15', 'Completed', 'I like him', 2),
('AD003', 'CH003', 'David Miller', 'david.miller@example.com', '2024-02-20', 'Completed', 'I like him', 3),
('AD004', 'CH004', 'Emma Taylor', 'emma.taylor@example.com', '2024-01-25', 'Completed', 'I like him', 3),
('AD005', 'CH005', 'James Brown', 'james.brown@example.com', '2024-05-05', 'Waiting', 'I like him', 4);

-- Inserting values into the IntroductionActivity table
INSERT INTO IntroductionActivity (IntroductionActivityID, IntroducerName, IntroducerContactInfo, DateOfIntroduction, Status, Description, ChildrendName, ChildrendLastName, Gender, DateOfBirth, UserID)
VALUES 
('IA001', 'John Doe', 'john@example.com', '2023-05-10', 'Waiting', 'Introduction program', 'Liam', 'Smith', 1, '2018-04-25', 2),
('IA002', 'Jane Smith', 'jane@example.com', '2024-03-20', 'Completed', 'Orientation session', 'Sophia', 'Miller', 0, '2018-09-20', 2),
('IA003', 'Emma Davis', 'emmadavis@example.com', '2024-03-20', 'Waiting', 'Orientation session', 'Jade', 'Manson', 1, '2018-03-21', 3);

-- Inserting data into the Feedback table
INSERT INTO Feedback (FeedbackID, UserId, Topic, ContactInfo) 
VALUES ('FB001', 2, 'Product Quality', 'customer@example.com');

-- Insert Feedback Message from Customer
INSERT INTO FeedbackMessages (FeedbackID, UserId, MessageText) 
VALUES ('FB001', 2, 'I am not satisfied with the product quality.');

-- Insert Feedback Message from Staff
INSERT INTO FeedbackMessages (FeedbackID, UserId, MessageText) 
VALUES ('FB001', 1, 'We are sorry to hear that. Can you provide more details?');

SELECT F.Topic, F.ContactInfo, U.UserName, M.MessageText, M.MessageDate
FROM Feedback F
JOIN FeedbackMessages M ON F.FeedbackID = M.FeedbackID
JOIN Account U ON M.UserId = U.UserId
WHERE F.FeedbackID = 'FB001'
ORDER BY M.MessageDate;

-- Inserting data into the Financial table
INSERT INTO Financial (FinancialID, Description, TotalMoney, AmountSpend, DataEntryDate)
VALUES ('F001', 'Office Supplies', 5000.00, 2000.00, '2024-03-12'),
       ('F002', 'Salaries', 10000.00, 8000.00, '2024-04-17'),
       ('F003', 'Rent', 3000.00, 3000.00, '2024-05-22');

-- Inserting data into the Donate table
INSERT INTO Donate (DonateID, RequestName, AmountRequest, Description, Status, RequestDate)
VALUES ('DN001', 'Donor A', 1000.00, 'Donation for office supplies', 'Completed', '2024-05-10'),
       ('DN002', 'Donor B', 1500.00, 'Donation for salaries', 'Waiting', '2024-05-15'),
       ('DN003', 'Donor C', 2000.00, 'Donation for rent', 'Cancelled', '2024-05-23');


-- Just alter no need to execute
-- Step 2: Add the new foreign key constraint with ON DELETE CASCADE
ALTER TABLE IntroductionActivity
ADD CONSTRAINT FK_IntroductionActivity_UserID
FOREIGN KEY (UserID) REFERENCES Account(UserID)
ON DELETE CASCADE;

ALTER TABLE Adoption
ADD CONSTRAINT FK_AdoptionActivity_UserID
FOREIGN KEY (UserID) REFERENCES Account(UserID)
ON DELETE CASCADE;

ALTER TABLE Adoption
ADD CONSTRAINT FK_AdoptionActivity_ChildID
FOREIGN KEY (ChildID) REFERENCES Children(ChildID)
ON DELETE CASCADE;

ALTER TABLE Staff
ADD CONSTRAINT FK_ss_UserID
FOREIGN KEY (UserID) REFERENCES Account(UserID)
ON DELETE CASCADE;

ALTER TABLE Customers
ADD CONSTRAINT FK_ctm_UserID
FOREIGN KEY (UserID) REFERENCES Account(UserID)
ON DELETE CASCADE;

ALTER TABLE Feedback
ADD CONSTRAINT FK_fb_UserID
FOREIGN KEY (UserID) REFERENCES Account(UserID)
ON DELETE CASCADE;

ALTER TABLE FeedbackMessages
ADD CONSTRAINT FK_fbm_UserID
FOREIGN KEY (UserID) REFERENCES Account(UserID)
ON DELETE CASCADE;
