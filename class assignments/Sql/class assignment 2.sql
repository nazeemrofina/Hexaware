
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
 --1. List all employees whose name begins with 'A'. 
 select * from employee where ename like 'A%'

 --2. Select all those employees who dont have a manager. 
 select * from employee where mgrid is null
 select mgrId from employee where ename='king'

  --3.List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
  select ename,empno,sal from employee where sal between 1200 and 1400

  
  --4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise
  update employee set sal=sal*10/100+sal from employee
  
  

  --5. Find the number of CLERKS employed. Give it a descriptive heading.
  select count(empno) as [no of clerks] from employee where job='clerk'

  --6. Find the average salary for each job type and the number of people employed in each job. 
  select job,avg(sal),count(ename) from employee group by job

  --7.List the employees with the lowest and highest salary. 
  select min(sal),max(sal) from employee 

  
  --8. List full details of departments that dont have any employees. 
  select d.deptno,d.deptname,d.location from dept d left join employee e 
  on e.deptno=d.deptno
  where e.deptno is null

  
  
  --9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. 
  --Sort the answer by ascending order of name. 

  select ename,sal from employee 
  where job='clerk' and sal>1200 and deptno=20
  order by ename asc
  
  --10. For each department, list its name and number together with the total salary paid to employees in that department. 
  --select deptno,deptname,employee(sal) from dept group by 

  select  dept.deptno,dept.deptname,sum(sal) as total from employee join dept
  on employee.deptno=dept.deptno
  group by dept.deptno,dept.deptname

  --11.Find out salary of both MILLER and SMITH.
  select ename,sal from employee where ename in('miller','smith')

  --12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
  select * from employee where ename like '[A,M]%'

  --13. Compute yearly salary of SMITH.
  select ename,sal*12 from employee where ename='smith'


  --14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
  select ename,sal from employee where sal not between 1500 and 2850


  --15. Find all managers who have more than 2 employees reporting to them
  select mgrId from employee 
  group by mgrId 
  having count(mgrId)>1
   

   