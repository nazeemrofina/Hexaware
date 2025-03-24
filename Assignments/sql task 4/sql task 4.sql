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
where student_id=4 join enrolments
on students.student_id=enrollment.student_id

--7. Update the payment amount for a specific payment record in the "Payments" table. Choose any 
--payment record and modify the payment amount. 

update payments
set amount=13000
where amount =12000 and student_id=4

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

select * from courses select * from teacher
select * from payments
select * from students
select * from teacher

select * from payments
select * from Enrollments select * from courses
order by student_id

insert into Enrollments values (1006,6,2009,'2024-11-24'),
(1004,1,2007,'2024-09-27'),
(1005,1,2009,'2024-12-21'),
(304,5,2009,'2024-02-12'),
(856,7,2004,'2024-07-18'),
(1002,8,2003,'2024-07-04'),
(1003,5,2004,'2024-05-12'),
(1007,10,2004,'2024-10-26'),
(1008,2,2005,'2024-11-19')





--1. Write an SQL query to calculate the average number of students enrolled in each course. Use 
--aggregate functions and subqueries to achieve this.

select (e.num)  as average from (select course_id,count(student_id) as num from Enrollments
group by course_id) as e 


--2. Identify the student(s) who made the highest payment. Use a subquery to find the maximum 
--payment amount and then retrieve the student(s) associated with that amount. 


select s.first_name,s.last_name,p.student_id from payments p  join students s on
s.student_id=p.student_id
where amount=(select max(amount) from Payments) 

--3. Retrieve a list of courses with the highest number of enrollments. 
--Use subqueries to find the 
--course(s) with the maximum enrollment count. 

select max(d.counts) from ( select course_id,count(student_id) as counts from Enrollments
group by course_id) d
having d.counts=max(d.counts)



select * from courses select * from Enrollments select * from Payments

insert into teacher values(1011,'olivia','rodreger','olivia.rodreger@example.com')
--4 . Calculate the total payments made to courses taught by each teacher. Use subqueries to sum 
--payments for each teacher's courses. 

0

select sum(amounts) from payments
where()  

select student_id from students
where course_id=any(select course_id,t.teacher_id from teacher t join courses on courses.teacher_id=t.teacher_id
where courses.teacher_id=t.teacher_id)





select sum(amount),e.p.teacher_id from payments
where student_id= any(select student_id from Enrollments
where enrollments.course_id = any(select t.course_id from courses t) as p) as e
group by  


select * from teacher





--5. Identify students who are enrolled in all available courses. Use subqueries to compare a 
--student's enrollments with the total number of courses.

select * from students
where student_id=any (select d.student_id from (select student_id,count(course_id) as courses from enrollments e
group by student_id) as d
where d.courses =(select count(course_id) as [total courses] from courses))

(SINCE NO STUDENTS HAS ENROLLED FOR ALL AVAILABLE COURSES)
	
	select * from Enrollments select * from courses
--6. Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to 
--find teachers with no course assignments. 

select * from teacher
where teacher_id = any (select teacher_id from teacher t
where not exists (select 'x' from courses c
where t.teacher_id=c.teacher_id))



--7.Calculate the average age of all students. Use subqueries to calculate the age of each student 
--based on their date of birth. 


select avg(e.dates) from(select DATEDIFF_BIG(year,date_of_birth,getdate()) as dates from students) as e

--8. Identify courses with no enrollments. Use subqueries to find courses without enrollment 
--records. 

select * from courses
where course_id=(select course_id  from courses c
where not exists(select 'z' from enrollments where course_id=c.course_id))


--9. Calculate the total payments made by each student for each course they are enrolled in. Use 
--subqueries and aggregate functions to sum payments. 


select ( select first_name from students where students.student_id=Enrollments.student_id) as 'Name',
       (select course_id from courses where enrollments.course_id=courses.course_id )as 'Course',
	   (select sum(amount) from Payments where Payments.student_id=Enrollments.student_id) as 'Payments'
	   from enrollments
    












insert into payments values (21575,1,4000,'2024-09-26'),
(21576,1,4500,'2024-12-20'),
(21577,5,2500,'2024-02-11'),
(21578,5,3500,'2024-05-11'),
(21579,6,2500,'2024-11-23'),
(21580,7,3000,'2024-07-17'),
(21581,8,2500,'2024-07-04'),
(21582,10,4500,'2024-10-26'),
(21583,11,7500,'2024-03-17')




--10. Identify students who have made more than one payment. Use subqueries and aggregate 
--functions to count payments per student and filter for those with counts greater than one. 
 
 select first_name,last_name from students
 where students.student_id = any(select p.student_id from (select student_id,count(amount) as Total_number from payments
 group by student_id) as p
 where p.Total_number>1)






 --11. Write an SQL query to calculate the total payments made by each student. Join the "Students" 
--table with the "Payments" table and use GROUP BY to calculate the sum of payments for each 
--student. 

select * from students
select * from payments

select d.student_id,s.first_name,s.last_name,[total amount] from (select student_id,sum(amount) as[total amount] from payments p
group by student_id) as d right join students s on s.student_id=d.student_id



--12. Retrieve a list of course names along with the count of students enrolled in each course. Use 
--JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to 
--count enrollments.

select c.course_name,c.course_id,count(e.student_id) as [Total Enrollment] from Enrollments e
right join courses c on c.course_id=e.course_id
group by c.course_id,c.course_name

--13. Calculate the average payment amount made by students. Use JOIN operations between the 
--"Students" table and the "Payments" table and GROUP BY to calculate the average.

select first_name,last_name,p.student_id,avg(amount) as [Average Payment] from students s join payments p on
s.student_id=p.student_id
group by p.student_id,first_name,last_name







