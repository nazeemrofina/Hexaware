
--1. Provide a SQL script that initializes the database for the Pet Adoption Platform ”PetPals”.
--4. Ensure the script handles potential errors, such as if the database or tables already exist.
create database petpals 
use petpals


--2. Create tables for pets, shelters, donations, adoption events, and participants.


create table pets
(
petId int primary key,
Petname varchar(20),
Age int,
Breed varchar(20),
PetType varchar(20),
AvailForAdoption tinyint,
ownerid int references shelters(shelterid)
)

create table shelters
(
shelterId int primary key,
sheltername varchar(20),
locations varchar (20)
)



create table adoptionevents
(
EventID int Primary Key ,
EventName varchar(20), 
EventDate datetime,
eventLocation varchar(20) 
)

--3. Define appropriate primary keys, foreign keys, and constraints.
create table participants
(
ParticipantID int Primary Key,
ParticipantName varchar(20),
ParticipantType varchar(20),
EventID int references adoptionevents(eventid)
)
create table donation
(
DonationID  int Primary Key,
DonorName varchar(20),
DonationType varchar(20),
DonationAmount decimal(6,2),
DonationItem varchar(20),
DonationDate datetime,
shelterid int references shelters(shelterid)
)

select * from participants



insert into pets values(1,'mark',2,'Labrador','dog',1,1002),
(2,'may',1,'golden retriever','dog',0,1004),
(3,'andrew',3,'german sheperd','dog',1,1005),
(4,'nicky',4,'noodle','cat',0,1001),
(5,'mani',5,'boxer','cat',1,1003)


insert into shelters values(1001,'lanny','churchstreet'),
(1002,'can','applegarden'),
(1003,'lucy','temple road'),
(1004,'lizo','pollachi'),
(1005,'mike','cbe')

select  getdate()

insert into donation values(2001,'jan','cash',1000,null,'2024-11-08 10:20:00',1002),
(2002,'dile','item',null,'dog food','2024-11-09 09:06:45',1001),
(2003,'maran','cash',3000,null,'2024-09-05 07:04:12',1003),
(2004,'vijay','item',null,'medicine','2024-04-02 04:06:12',1004),
(2005,'daniel','cash',7000,null,'2024-11-04 12:00:00',1005)

insert into adoptionevents values(3001,'carey','2024-11-08 10:20:00','tamilnadu'),
(3002,'lid','2024-12-08 10:20:00','kerala'),
(3003,'animals','2024-01-08 10:20:00','tamilnadu')

insert into participants values(5001,'may','adopter',3001),
(5002,'sept','adopter',3002),
(5003,'oct','shelter',3003)

/*5. Write an SQL query that retrieves a list of available pets (those marked as available for adoption)
from the "Pets" table. Include the pet's name, age, breed, and type in the result set. Ensure that
the query filters out pets that are not available for adoption.*/

select petname,age,breed,PetType from pets
where AvailForAdoption<>0

/*6. Write an SQL query that retrieves the names of participants (shelters and adopters) registered
for a specific adoption event. Use a parameter to specify the event ID. Ensure that the query
joins the necessary tables to retrieve the participant names and types.*/

select ParticipantName,EventName from participants p join adoptionevents ae
on p.EventID=ae.EventID

/*7. Create a stored procedure in SQL that allows a shelter to update its information (name and
location) in the "Shelters" table. Use parameters to pass the shelter ID and the new information.
Ensure that the procedure performs the update and handles potential errors, such as an invalid
shelter ID.*/
select * from adoptionevents
select * from participants

insert into adoptionevents values(3005,'PetAdopt','2025-05-09 10:20:00','Kerala')

create procedure updateshelters1
@name varchar(20),
@location varchar(20),
@shelterid int
as 
begin
update shelters
set sheltername=@name,
locations=@location
where shelterId=@shelterid
end

exec updateshelters1 @name='vanny',@location='bangalore',@shelterid=1001


/*8. Write an SQL query that calculates and retrieves the total donation amount for each shelter (by
shelter name) from the "Donations" table. The result should include the shelter name and the
total donation amount. Ensure that the query handles cases where a shelter has received no
donations.*/

select sheltername,sum(donationamount) from donation d join shelters s
on s.shelterId=d.shelterid
group by sheltername


/*9. Write an SQL query that retrieves the names of pets from the "Pets" table that do not have an
owner (i.e., where "OwnerID" is null). Include the pet's name, age, breed, and type in the result
set.*/
select * from pets
select * from shelters

select petname,petId,ownerid from pets p left join shelters s
on p.ownerid=s.shelterId
where s.shelterId is null


/*10. Write an SQL query that retrieves the total donation amount for each month and year (e.g.,
January 2023) from the "Donations" table. The result should include the month-year and the
corresponding total donation amount. Ensure that the query handles cases where no donations
were made in a specific month-year.*/

select * from donation
where DonationDate=


/*11. Retrieve a list of distinct breeds for all pets that are either aged between 1 and 3 years or older
than 5 years.*/

select * from pets

select breed from pets
where age between 1 and 3 or age>5


/*12. Retrieve a list of pets and their respective shelters where the pets are currently available for
adoption.*/

select * from pets
select * from shelters

select petname,shelterid,sheltername,AvailForAdoption from pets p join shelters s
on p.ownerid=s.shelterId
where AvailForAdoption=1

/*13. Find the total number of participants in events organized by shelters located in specific city.
Example: City=Chennai*/


select eventlocation,count(participantid) as [Total counts] from participants p join adoptionevents ae
on p.EventID=ae.EventID
where eventLocation='chennai'
group by eventlocation

/*14. Retrieve a list of unique breeds for pets with ages between 1 and 5 years.*/

select distinct pettype from pets
where age  between 1 and 5


/*15. Find the pets that have not been adopted by selecting their information from the 'Pet' table.*/

select petid,Petname from pets
where isadopted='no'

or


select petid,petname from pets
where AvailForAdoption=1




/*16. Retrieve the names of all adopted pets along with the adopter's name from the 'Adoption' and
'User' tables.*/
select petname,sheltername as Owner from pets p join shelters s on
p.ownerid=s.shelterId
where AvailForAdoption=0

/*17. Retrieve a list of all shelters along with the count of pets currently available for adoption in each
shelter.*/
select * from shelters
select * from pets

select sheltername,count(availforadoption)  'Adoption Count' from shelters s left join pets p
on s.shelterId=p.ownerid
group by sheltername

/*18. Find pairs of pets from the same shelter that have the same breed.*/

select * from pets select * from shelters


select petname,sheltername,pettype,breed from pets p join shelters s
on p.ownerid=s.shelterId 
where pettype = (select pettype from pets p1 where  p.petid<>p1.petId and p.Breed=p1.Breed)



/*19. List all possible combinations of shelters and adoption events.*/

select * from shelters s cross join adoptionevents ae 

/*20. Determine the shelter that has the highest number of adopted pets.*/

select * from shelters 
where shelterId=(
select top 1 ownerid from(
select count(petid) as counts,ownerid from pets
group by ownerid) as e
order by counts desc)
