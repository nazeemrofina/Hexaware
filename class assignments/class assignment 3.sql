
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

 
--1. Retrieve a list of MANAGERS. 

select e1.empno,e1.ename from employee e1  join employee e2
on e1.empno=e2.mgrid
where e1.empno=e2.mgrid

select e1.ename as 'Employee Name' , e2.ename as 'Manager Name' from employee e1 join employee e2
on e1.empno = e2.mgrid

--2.. Find out the names and salaries of all employees earning more than 1000 per 
--month. 
select ename,sal from employee
where sal>1000

--3. Display the names and salaries of all employees except JAMES. 

select ename,sal from employee
where ename not in ('james')

--4. Find out the details of employees whose names begin with ‘S’. 

select * from employee 
where ename like 's%'

--5.Find out the names of all employees that have ‘A’ anywhere in their name.
select ename from employee
where ename like '%a%'

--6. Find out the names of all employees that have ‘L’ as their third character in 
--their name.
select ename from employee
where ename like '__L%'

--7. Compute daily salary of JONES. 
select sal/12 from employee
where ename='jones'

--8. Calculate the total monthly salary of all employees. 
select sum(sal) from employee

--9.Print the average annual salary 

select avg(sal) from employee

--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 

select ename,job,sal,deptno from employee
where job<>'salesman' or deptno<>30
