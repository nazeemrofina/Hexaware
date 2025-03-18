create database sisdb
use sisdb

select * from students
select * from teacher
select * from courses
select * from payments
select * from Enrollments

drop table courses
drop table teacher
drop table students
drop table enrollments
drop table payments
create table students
(
student_id int Primary Key,
first_name varchar(10),
last_name varchar(10),
date_of_birth date,
email varchar(40),
phone_number bigint
)


create table teacher
(
teacher_id int Primary Key,
first_name varchar(10),
last_name varchar(10),
email varchar(40)
)
 
 
create table courses
(
course_id int Primary Key, 
course_name varchar(20),
credits int,
teacher_id int Foreign Key references teacher(teacher_id)
)


create table Enrollments
(
enrollment_id int Primary Key, 
student_id int Foreign Key references students(student_id), 
course_id int Foreign Key references courses(course_id), 
enrollment_date date
)

create table Payments
(
payment_id int Primary Key, 
student_id int Foreign Key references students(student_id),
amount float,
payment_date date
)

insert into students values
(1,'john','smith','2000-may-15','johnsmith@gmail.com',9865758962),
(2,'emily','johnson','2001-FEB-22','emilyjohnson@gmail.com',8248491919),
(3,'micheal','brown','1999-november-12','michealbrown4@gmail.com',9087047555),
(4,'sophia','davis','2002-august-25','sophia.davis25@gmail.com',9967474187),
(5,'william','miller','2000-january-05','williammiller21@gmail.com',7894561239),
(6,'olivia','wilson','2001-september-18','oliviawilson@gmail.com',9123758642),
(7,'james','moore','1999-june-28','jamesmoore21@gmail.com',7584961524),
(8,'ava','taylor','2003-november-08','avataylor08h@gmail.com',7391468257),
(9,'Benjamin','anderson','2000-march-19','benjaminander@gmail.com',8264753951),
(10,'charles','thomas','2002-april-26','charlesthomas@gmail.com',9856742749)


insert into teacher values(1001,'Ariel','benya','ariel.benya@example.com'),
(1002,'nancy','infancia','nancy.infancia@example.com'),
(1003,'fredrick','rodreger','fredrick.rodger@example.com'),
(1004,'faisal','hassim','faisal.hassim@example.com'),
(1005,'kris','jenner','kris.jenner@example.com'),
(1006,'ancy','maeson','ancy.maeson@example.com'),
(1007,'freddy','tes','freddy.tes@example.com'),
(1008,'may','tragor','may.tragor@example.com'),
(1009,'franny','can','franny.can@example.com'),
(1010,'daniel','lindon','daniel.lindon@example.com')


insert into courses values(2001,'physics',4,1004),
(2002,'maths',6,1006),
(2003,'chemistry',8,1002),
(2004,'AI',10,1007),
(2005,'machine learning',2,1003),
(2006,'embedded circuits',3,1010),
(2007,'digital electronics',1,1001),
(2008,'PLM',5,1005),
(2009,'data science',7,1008),
(2010,'VLSI',9,1009)

insert into enrollments values (121,4,2010,'05-october-2024'),
(251,2,2004,'21-august-2024'),
(457,1,2006,'4-june-2024'),
(751,5,2007,'25-jan-2024'),
(920,8,2001,'15-march-2024'),
(784,6,2003,'30-may-2024'),
(654,9,2005,'27-april-2024'),
(473,3,2002,'16-july-2024'),
(852,7,2008,'05-FEB-2024'),
(701,10,2009,'24-september-2024')

truncate table enrollments
truncate table payments


insert into payments values(21564,4,12000,'2024-05-10'),
(21565,1,10000,'2024-09-15'),
(21567,3,11000,'2024-11-25'),
(21568,7,17000,'2024-12-07'),
(21569,9,9000,'2024-08-14'),
(21570,10,4500,'2024-04-25'),
(21571,2,6000,'2024-07-17'),
(21572,5,8500,'2024-06-04'),
(21573,6,9900,'2024-10-30'),
(21574,8,17000,'2024-03-15')

--1.Write an SQL query to insert a new student into the "Students" table with the following details: 
--a. First Name: John  
--b. Last Name: Doe 
--c. Date of Birth: 1995-08-15 
--d. Email: john.doe@example.com 
--e. Phone Number: 1234567890 

insert into students values(11,'john','doe','1995-08-15','john.doe@example.com',1234567890)

--2.Write an SQL query to enroll a student in a course. Choose an existing student and course and 
--insert a record into the "Enrollments" table with the enrollment date. 
 
 insert into Enrollments values (840,11,2001,'2025-03-17')

 --3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and 
 -- modify their email address. 

 update teacher
 set email='arielbenya24@example.com'
 where email='ariel.benya@example.com';

--4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select 
--an enrollment record based on the student and course. 

delete from enrollments
where student_id=2 and course_id=2004

select * from students
select * from Enrollments

--5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and 
--teacher from the respective tables. 

update courses
set teacher_id=1010
where course_name='digital electronics'

--6. Delete a specific student from the "Students" table and remove all their enrollment records 
--from the "Enrollments" table. Be sure to maintain referential integrity.

delete from students
where student_id=4 

 delete from Enrollments
 where student_id=4

  delete from Payments
 where student_id=4

--7. Update the payment amount for a specific payment record in the "Payments" table. Choose any 
--payment record and modify the payment amount. 

update payments
set amount=13000
where amount =12000 and student_id=4