
use FullStackAssignment

create table Categories(
CategoryId int identity(101,1) constraint pk_CategoryId primary key,
CategoryName varchar(100) not null,
CategoryImage varchar(50)
)

ALTER TABLE Categories ALTER COLUMN CategoryImage VARCHAR (200);

-- upfdate a column name 
EXEC sp_rename 'Category.CateoryId', 'CategoryId', 'COLUMN';

--sp_help Category

create Table Products(
ProductId int identity(1001,1) constraint pk_ProductId primary key,
ProductName varchar(50) not null,
[Description] varchar(100),
UnitPrice Money not null constraint chk_UnitPrice check(UnitPrice >=1),
UnitsInStock int not null constraint chk_UnitsInStock check(UnitsInStock >=1),
Discontinued Bit default 1 ,
CategoryId int constraint fk_CategoryId references Categories(CategoryID) ,
CreatedDate DateTime not null default GetDate(),
ModifiedDate Datetime 
)


create Table Users(
UserId int identity(1,1) constraint pk_userId primary key,
FirstName varchar(50) not null,
LastName varchar(50) not null,
Gender char(6) constraint chk_Gender check(Gender in('Male','Female','Others')),
DateOfBirth Datetime constraint chk_DateOfBirth check(DateOfBirth <= DATEADD(YEAR, -18, GETDATE())) ,
MobileNumber char(10) constraint unk_MobileNumber Unique not null,
EmailId varchar(150) constraint unk_EmailId Unique not null,
CreatedDate DateTime not null default GetDate(),
)

Select * from Products
Select * from Categories

go
create proc usp_AddCategory(@CategoryName varchar(50), @CategoryImgUrl varchar(200))
as 
if( exists(Select 'a' from Categories Where CategoryName = @CategoryName))
	return -1
else
	begin
	Insert into Categories(CategoryName, CategoryImage) values (@CategoryName, @CategoryImgUrl);
	return 99
	end
go

go 
create proc usp_UpdateProduct(@ProductId int, @ProductName varchar(50), @Description varchar(200), @UnitPrice Money, @UnitInStock int, @Discontinued Bit, @CategoryId int)
as
if( exists(Select 'a' from Products where ProductId=@ProductId))
	begin
		Update Products Set ProductName=@ProductName, [Description]=@Description, UnitPrice=@UnitPrice, UnitsInStock=@UnitInStock, Discontinued=@Discontinued, 
		CategoryId=@CategoryId, ModifiedDate=GetDate() where ProductId=@ProductId;
		return 99
	end
else
	return -1
go




