Create database Rana

use Rana

Create table Country
(
CountryId int primary key identity(1,1),
CountryName nvarchar(50)
)

Create table State
(
StateId int primary key identity(1,1),
StateName nvarchar(50),
CountId int
)

Create table City
(
CityId int primary key identity(1,1),
CityName nvarchar(50),
StatId int
)

Create table Department
(
DeptId int primary key identity(1,1),
DepartmentName nvarchar(50)
)

Create procedure sp_GetDepartments
as
begin
Select * from Department
end

Create table Employee
(
Id int primary key identity(1,1),
Name nvarchar(50),
Email nvarchar(50),
Phone nvarchar(10),
Country int,
State int,
City int,
Dob date,
Salary decimal(10,2),
Department int,
Photo nvarchar(max),
Role bit default 1,
IsDeleted bit default 1,
CreateOn Datetime Default GetDate()
)
use RANA
Create procedure sp_InsertEmployeeData
(
@Name nvarchar(50),
@Email nvarchar(50),
@Phone nvarchar(10),
@Country int,
@State int,
@City int,
@Dob date,
@Salary Decimal(10,2),
@Department int,
@Photo nvarchar(max)
)
as
begin
Insert into Employee
(Name,Email,Phone,Country,State,City,Dob,Salary,Department,Photo)values
(@Name,@Email,@Phone,@Country,@State,@City,@Dob,@Salary,@Department,@Photo)
end





ALTER TABLE Employee
ADD Photo nvarchar(max);

Create procedure sp_GetCountry
as
begin
Select * from Country
end

Create procedure sp_State
(
@CountId int
)
as
begin 
Select * from State where CountId=@CountId
end

Create procedure sp_City
(
@stateID int
)
as
begin
Select * from City where StatId=@StateID;
end
use Rana

Create procedure sp_GetEmployeeList
as
begin
Select * from Employee inner join Country on Employee.Country=Country.CountryId
inner join State on Employee.State=State.StateId inner join City on Employee.City=City.CityId
inner join Department on Department.DeptId=Employee.Department
end

Create procedure sp_GetEmployeeDetails
(
@Id int
)
as
begin
Select * from Employee inner join Country on Employee.Country=Country.CountryId
inner join State on Employee.State=State.StateId inner join City on Employee.City=City.CityId
inner join Department on Department.DeptId=Employee.Department where Id=@Id
end

Create procedure sp_UpdateEmployee
(
@Id int,
@Name nvarchar(50),
@Email nvarchar(50),
@Phone nvarchar(10),
@Country int,
@State int,
@City int,
@Dob Date,
@Salary Decimal(10,2),
@Department int,
@Photo nvarchar(max)=null
)
as
begin
update Employee set Name=@Name,Email=@Email,Phone=@Phone,Country=@Country,
State=@State,City=@City,Dob=@Dob,Salary=@Salary,Department=@Department,
Photo=Case 
when @Photo is null OR @Photo=''
then Photo
else @Photo
end
where Id=@Id
end

select * from Employee

exec sp_UpdateEmployee 1,'Vikrant','vikrantsinghrana@gmail.com','9678657345',1,2,2,'2000-02-02',50700,2,''

select * from Employee

delete from Employee where Id=1