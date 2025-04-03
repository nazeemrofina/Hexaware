
use assignment2
drop table employee
create table employee
(
empno int primary key,
ename varchar(20),
job varchar(20),
mgrId int ,
hiredate date,
sal float,
comm int null,
deptno int references dept(deptno)
)
select * from employee
select * from dept


insert into employee values (7369,'SMITH','CLERK',7902,'17-DEC-80',800,null,20),
(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,500,30),
(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
(7934,'MILLER','CLERK',7782,'23-JAN-82',1300,null,10)

select * from employee where ename = 'martin'
create table dept
(
deptno int primary key,
deptname varchar(10),
location varchar(20),
)

insert into dept values(10,'ACCOUNTING','NEW YORK'),
 (20,'RESEARCH','DALLAS'),
 (30,'SALES','CHICHAGO'), 
 (40,'OPERATIONS','BOSTON') 

 select * from dept

--1. List unique departments of the EMP table. 
select deptno from employee
group by deptno

--2. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename,sal,deptno from employee 
where sal>1500 and deptno IN(10,30)

--3. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename,job,sal from employee 
where job='manager' or job ='analyst' and sal not in (1000,3000,5000)

--4. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
select ename,sal,comm from employee
where comm*1.10>sal

--5. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
select * from employee 
where ename like '%l%l%' and deptno=30 or mgrid=7782

--6.Display the names of employees with experience of over 30 years and under 40 yrs.------------------------------------------------------------------
-- Count the total number of employees.
select count(ename) from employee
where DATEDIFF(year,hiredate,getdate())>30 and DATEDIFF(year,hiredate,getdate())<40

--7.Retrieve the names of departments in ascending order and their employees in 
--descending order. 
select d.deptname,e.ename from dept d join employee e
on d.deptno=e.deptno
group by deptname,e.ename
order by deptname asc,ename desc

select * from employee
--8.Find out experience of MILLER. 
select DATEDIFF(year,hiredate,getdate()) from employee
where ename='miller'

--9. Write a query to display all employee information where ename contains 5 or more characters
select * from employee
where len(ename)>=5

--10. Copy empno, ename of all employees from emp table who work for dept 10 into 
--a new table called emp10


