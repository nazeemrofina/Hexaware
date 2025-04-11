-- DB Crime Analysis and Reporting System (CARS)
CREATE DATABASE CARSDB
USE CARSDB

-- Creating schema for the entities

-- Incidents
CREATE TABLE Incidents(
IncidentID INT PRIMARY KEY IDENTITY,
IncidentType VARCHAR(50),
IncidentDate DATETIME,
location varchar(50),
Description TEXT,
Status VARCHAR(50),
AgencyID INT,
);
INSERT INTO Incidents ( IncidentType, IncidentDate, location, Description, Status, AgencyID)
VALUES
( 'Vandalism', '2023-01-02','Point(47.6097, -122.3331, 4326)', 'Broke street sign', 'Closed',1),
( 'Homicide', '2023-01-02','Point(40.7128, -74.0060, 4326)', 'Shot in the head', 'Open', 2),
( 'Theft', '2023-01-03','Point(34.0522, -118.2437, 4326)', 'Car theft', 'Under Investigation', 3),
( 'Assault', '2023-01-04', 'Point(41.8781, -87.6298, 4326)', 'Bypasser knocked out', 'Open', 4),
( 'Burglary', '2023-01-05','Point(29.7604, -95.3698, 4326)', 'Broke into house', 'Closed', 5),
( 'Vandalism', '2023-01-06', 'Point(37.7749, -122.4194, 4326)', 'Destroyed public property', 'Under Investigation', 6),
( 'Kidnapping', '2023-01-07', 'Point(51.5074, -0.1278, 4326)', 'Kidnapped kids', 'Open', 7)

-- Victims
CREATE TABLE Victims(
VictimID INT PRIMARY KEY IDENTITY,
IncidentID INT,
FirstName VARCHAR(255),
LastName VARCHAR(255),
DateOfBirth DATETIME,
Gender VARCHAR(10),
PhoneNumber BIGINT,
Address VARCHAR(255),
FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID)
);
INSERT INTO Victims ( IncidentID,FirstName, LastName, DateOfBirth, Gender,PhoneNumber, Address) VALUES 
( 1,'John', 'Doe', '1990-05-15', 'Male',7569842301, '123 Main St, City, Country'),
(2, 'Jane', 'Smith', '1985-08-20', 'Female',3698521470, '456 Elm St, City, Country'),
( 3,'Michael', 'Johnson', '1982-11-10', 'Male',7458963254, '789 Oak St, City, Country'),
( 4,'Emily', 'Brown', '1978-03-25', 'Female',9873214560, '101 Pine St, City, Country'),
(5, 'William', 'Wilson', '1995-09-08', 'Male',7849650312, '202 Maple St, City, Country'),
(6, 'Amanda', 'Jones', '1989-07-12', 'Female',7908465134, '303 Cedar St, City, Country'),
(7, 'David', 'Davis', '1983-12-30', 'Male',7496852031, '404 Birch St, City, Country')

-- Suspects
CREATE TABLE Suspects(
SuspectID INT PRIMARY KEY IDENTITY,
IncidentID INT,
FirstName VARCHAR(255),
LastName VARCHAR(255),
DateOfBirth DATETIME,
Gender VARCHAR(10),
PhoneNumber BIGINT,
Address VARCHAR(255),
FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID)
);
INSERT INTO Suspects ( IncidentID,FirstName, LastName, DateOfBirth, Gender,PhoneNumber, Address)
VALUES 
(1, 'Michael', 'Jones', '1988-04-18', 'Male',7985641302, '789 Elm St, City21, Country21'),
(2, 'Sarah', 'Williams', '1993-10-29', 'Female',3791648250, '456 Oak St, City22, Country22'),
(3, 'Matthew', 'Davis', '1980-07-15', 'Male',9708643512,'101 Maple St, City23, Country23'),
(4, 'Emily', 'Anderson', '1976-01-07', 'Female',7391806452, '202 Birch St, City24, Country24'),
(5, 'David', 'Wilson', '1997-08-22', 'Male',7485985696, '303 Cedar St, City25, Country25'),
( 6,'Jessica', 'Brown', '1984-03-11', 'Female',6547539578, '404 Pine St, City26, Country26'),
( 7,'John', 'Taylor', '1981-12-03', 'Male', 3690188447,'505 Elm St, City27, Country27')

-- Law Enforcement Agencies
CREATE TABLE LawEnforcementAgencies(
AgencyID INT PRIMARY KEY IDENTITY,
AgencyName VARCHAR(255),
Jurisdiction VARCHAR(255),
PhoneNumber BIGINT,
Address VARCHAR(255),
);
INSERT INTO LawEnforcementAgencies ( AgencyName, Jurisdiction,PhoneNumber, Address) 
VALUES
( 'City Police Department', 'Washington',9865836608, '123 Main St, Washington'),
( 'County Sheriff Office', 'Tenesse', 7845963210,'456 Oak Ave, Tenesse'),
( 'State Highway Patrol', 'Texas',7539514562, '789 Elm St, Texas'),
( 'Federal Bureau of Investigation', 'National', 8745963210,'101 Federal Way, National'),
( 'Drug Enforcement Administration', 'National',4568523570, '202 Narcotics St, National'),
( 'City Police Department', 'Mephis',9137468275, '345 Maple Ave, Mephis'),
( 'County Sheriff Office', 'Blaine County',3571598520, '678 Pine St, Blaine County')

-- Officers
CREATE TABLE Officers(
OfficerID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(255),
LastName VARCHAR(255),
BadgeNumber INT,
[Rank] INT,
PhoneNumber BIGINT,
Address VARCHAR(255),
AgencyID INT,
FOREIGN KEY (AgencyID) REFERENCES LawEnforcementAgencies(AgencyID)
);
INSERT INTO Officers ( FirstName, LastName, BadgeNumber, Rank, PhoneNumber,Address, AgencyID)
VALUES
( 'Michael', 'Anderson', 1001, 1, 5552187439,'123 Mapplewood Drive,Brookville,NY', 1),
( 'Jessica', 'Wilson', 1022, 2, 5559021673,' 87 Westlake Ave Portland 97209', 2),
( 'Christopher', 'Taylor', 1003, 3, 5557643882 ,'241 Sunset Blvd Los Angeles CA 90026', 3),
( 'Amanda', 'Martin', 1004, 4,5553310845,' 56 Riverbend Rd Austin TX 78704 ', 4),
( 'Matthew', 'Thomas', 1005, 5,5556492791,'309 Cherry Hill Ln Atlanta GA 30309 ', 5),
( 'Samantha', 'Garcia', 1006, 6, 5554135720,' 1701 Oakcrest St Madison WI 53705', 6),
( 'David', 'Hernandez', 1007, 7, 5552886604,' 78 Pine Needle Ct Denver CO 80206', 7)

-- Evidences
CREATE TABLE Evidences(
EvidenceID INT PRIMARY KEY IDENTITY,
Description TEXT,
LocationFound VARCHAR(255),
IncidentID INT,
FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID)
);
-- Insert data into Evidence
INSERT INTO Evidences ( Description, LocationFound, IncidentID) 
VALUES
( 'Fingerprint', 'Point(47.6097, -122.3331, 4326)', 1),
( 'Bloodstain', 'Point(40.7128, -74.0060, 4326)', 2),
( 'Weapon',' Point(34.0522, -118.2437, 4326)', 3),
( 'Footprint', 'Point(41.8781, -87.6298, 4326)', 4),
( 'Hair Strand', 'Point(29.7604, -95.3698, 4326)', 5),
( 'Drug Bag', 'Point(33.7490, -84.3880, 4326)', 6),
( 'DNA Sample', 'Point(37.7749, -122.4194, 4326)', 7)

-- Reports
CREATE TABLE Reports(
ReportID INT PRIMARY KEY IDENTITY,
IncidentID INT,
ReportingOfficer INT,
ReportDate DATETIME,
ReportDetails TEXT,
Status VARCHAR(50),
FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID),
FOREIGN KEY (ReportingOfficer) REFERENCES Officers(officerID)
);
INSERT INTO Reports ( IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES 
( 1, 5, '2023-05-01', 'Police enquiry', 'Open'),
( 2, 4, '2024-04-02', 'Crimscene closed', 'Closed'),
( 7, 2, '2022-02-21', 'No evidence found', 'Under Investigation'),
( 4, 3, '2023-02-11', 'Evidence not found', 'Draft'),
( 5, 8, '2024-05-05', 'Fingerprints found', 'Finalized'),
( 6, 6, '2024-05-06', 'Murder weapon found', 'Open'),
( 3, 7, '2024-05-07', '2 eye witnesses', 'Closed')

-- Creating Incident -> Agency relation
ALTER TABLE Incidents
ADD CONSTRAINT FK_Incident_Agency
FOREIGN KEY (AgencyID) REFERENCES LawEnforcementAgencies(AgencyID);

ALTER TABLE Incidents
ADD CONSTRAINT Check_IncidentStatus
CHECK (Status IN ('Open', 'Closed', 'Under Investigation'));

ALTER TABLE Reports
ADD CONSTRAINT Check_Reports
CHECK (Status IN ('Draft', 'Finalized'));

ALTER TABLE Incidents
ADD CONSTRAINT Def_IncidentStatus
DEFAULT 'Open' FOR Status;

select * from officers
ALTER TABLE Officers
ALTER COLUMN Rank VARCHAR(50);

update Officers
set Role='Police'

Update officers
set Rank='Assistant PC'
where Rank='6'
ALTER TABLE Officers
ADD Email VARCHAR(255) ,
Password VARCHAR(255) ;

ALTER TABLE Officers
ADD Role VARCHAR(50);

select * from incidents
select * from Officers
select * from victims
select * from LawEnforcementAgencies
select * from Reports
select * from Suspects
select * from evidences
select * from LawEnforcementAgencies
insert into LawEnforcementAgencies values('EnforcedAgency','Chennai',9874563214,'annapooranilyout')
truncate table incidents insert into Officers values('Nazeem','Rofina',151,01,6379191900,'4,Annapoorani',01,'nazeemrofina@gmail.com','Rofizara08@','Officer')
insert into Officers values('Nazeem','Rofina',151,01,6379191900,'4,Annapoorani',02,'nazeemrfina@gmail.com','Rofizar08@','Admin')
insert into LawEnforcementAgencies values('EnforcdAgency','Chenni',9874563214,'annapooranilyout')

ALTER TABLE Officers
ADD CONSTRAINT OF_UNIQUE
Unique (password)


-- Insert data into Victims
delete from incidents
where IncidentId=8
delete from Evidences
where IncidentID=8

-- Insert data into Suspects



-- Insert data into Officers




-- Insert data into LawEnforcementAgencies




-- Insert data into Incidents






-- Insert data into Reports



-- Insert data into Cases
INSERT INTO Cases VALUES
(1, 'Murder Case', 'Open', 2),
(2, 'Theft Investigation', 'Under Investigation', 3),
(3, 'Assault Case', 'Closed', 4),
(4, 'Littering', 'Closed', 11);

drop table incidents
drop table Suspects
drop table Victims
drop table Evidences
drop table LawEnforcementAgencies
drop table Officers
drop table Reports



Update officers
set Role='Admin'
where OfficerID=8
select * from Officers
select * from LawEnforcementAgencies
select * from suspects
select * from incidents
select * from victims
select * from evidences
select * from reports


select * from Incidents where IncidentDate between '2023-01-02' and '2023-01-02'