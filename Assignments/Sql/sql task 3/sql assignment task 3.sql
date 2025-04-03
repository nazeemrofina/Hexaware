create database sisdb
use sisdb

select * from students
select * from teacher
select * from courses
select * from payments
select * from Enrollments
where course_id=2011


select course_name,count(student_id) from enrollments e join courses c
on e.course_id=c.course_id
group by e.course_id,c.course_name
having course_name='SQL'

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


--1. Write an SQL query to calculate the total payments made by a specific student. You will need to 
--join the "Payments" table with the "Students" table based on the student's ID. 

select students.student_id,students.first_name,sum(amount) from payments join 
 students on Payments.student_id=students.student_id
where students.student_id=7
group by students.student_id,students.first_name
--2. Write an SQL query to retrieve a list of courses along with the count of students enrolled in each 
--course. Use a JOIN operation between the "Courses" table and the "Enrollments" table.

select c.course_name,c.course_id,count(e.student_id) as total_enrollment from Enrollments e
join courses c on c.course_id=e.course_id
group by c.course_id,c.course_name



--3. Write an SQL query to find the names of students who have not enrolled in any course. Use a 
--LEFT JOIN between the "Students" table and the "Enrollments" table to identify students 
--without enrollments. 
select s.first_name,s.last_name,s.student_id,e.course_id from students s left join Enrollments as e 
on s.student_id=e.student_id
where e.student_id is null



--4. Write an SQL query to retrieve the first name, last name of students, and the names of the 
--courses they are enrolled in. Use JOIN operations between the "Students" table and the 
--"Enrollments" and "Courses" tables. 

select s.first_name,s.last_name,e.course_id,c.course_name from students s join enrollments e
on s.student_id=e.student_id join courses c on e.course_id=c.course_id


--5. Create a query to list the names of teachers and the courses they are assigned to. Join the 
--"Teacher" table with the "Courses" table. 

select t.first_name,t.last_name,c.course_name from teacher t join courses c on 
c.teacher_id=t.teacher_id



--6. Retrieve a list of students and their enrollment dates for a specific course. You'll need to join the 
--"Students" table with the "Enrollments" and "Courses" tables. 
 
 select s.first_name,s.last_name,e.enrollment_date,c.course_id,c.course_name from students s join Enrollments e
on s.student_id=e.student_id join courses c on e.course_id=c.course_id



--7. Find the names of students who have not made any payments. Use a LEFT JOIN between the 
--"Students" table and the "Payments" table and filter for students with NULL payment records. 

select s.first_name,s.last_name,p.student_id from students s left join payments p
on s.student_id=p.student_id
where p.student_id is null



--8. Write a query to identify courses that have no enrollments. You'll need to use a LEFT JOIN 
--between the "Courses" table and the "Enrollments" table and filter for courses with NULL 
--enrollment records.

select c.course_id,c.course_name from courses c left join enrollments e
on e.course_id=c.course_id
where e.course_id is null


--9. Identify students who are enrolled in more than one course. Use a self-join on the "Enrollments" 
--table to find students with multiple enrollment records. 

select s1.student_id,s1.course_id as [courses enrolled] from enrollments s1 join enrollments s2
on s1.student_id=s2.student_id
where s1.course_id <> s2.course_id



--10. Find teachers who are not assigned to any courses. Use a LEFT JOIN between the "Teacher" 
--table and the "Courses" table and filter for teachers with NULL course assignments.

select t.teacher_id,t.first_name,t.last_name from teacher t left join courses c
on t.teacher_id=c.teacher_id
where c.teacher_id is null