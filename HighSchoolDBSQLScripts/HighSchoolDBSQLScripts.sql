CREATE DATABASE HighSchool
GO
USE HighSchool
GO


CREATE TABLE Roles
(
	[RoleId] TINYINT CONSTRAINT pk_RoleId PRIMARY KEY,
	[RoleName] VARCHAR(20) CONSTRAINT uq_RoleName UNIQUE
);
-- Create the Person table.
CREATE TABLE [Person]
(
	[PersonID] [int] IDENTITY(1,1) CONSTRAINT pk_Person_PersonID PRIMARY KEY NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserPassword] VARCHAR(15) NOT NULL,
	[RoleId] TINYINT CONSTRAINT fk_RoleId REFERENCES Roles(RoleId),
	[Gender] CHAR CONSTRAINT chk_Gender CHECK(Gender='F' OR Gender='M') NOT NULL,
	[DateOfBirth] DATE NOT NULL,
	[Address] VARCHAR(200) NOT NULL
);

-- Create the Course table.
CREATE TABLE [Course]
(
	[CourseID] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	CONSTRAINT [PK_OnlineCourse] PRIMARY KEY
	(
	[CourseID] ASC
));

-- Create the CourseInstructor table.
CREATE TABLE [CourseInstructor]
(
	[CourseID] [int] CONSTRAINT fk_CourseInstructor_CourseID REFERENCES Course(CourseID) NOT NULL,
	[PersonID] [int] CONSTRAINT fk_CourseInstructor_PersonID REFERENCES Person(PersonID) NOT NULL,
	CONSTRAINT [PK_CourseInstructor] PRIMARY KEY 
	(
	[CourseID] ASC,
	[PersonID] ASC
));


--Create the StudentGrade table.
CREATE TABLE [StudentGrade]
(
	[PersonID] [int] CONSTRAINT fk_StudentGrade_PersonID REFERENCES Person(PersonID) NOT NULL,
	[CourseID] [int] CONSTRAINT fk_StudentGrade_CourseID REFERENCES Course(CourseID) NOT NULL,
	[Grade] [decimal](3, 2) NULL,
	CONSTRAINT [PK_StudentGrade] PRIMARY KEY
	(
	[PersonID] ASC,
	[CourseID] ASC	
));

GO





CREATE INDEX ix_RoleId ON Person(RoleId);
CREATE INDEX ix_CourseId ON Products(CourseId);
CREATE INDEX ix_EmailId ON PurchaseDetails(EmailId);
CREATE INDEX ix_ProductId ON PurchaseDetails(Product);


INSERT INTO Roles (RoleId, RoleName) VALUES (1, 'Admin');
INSERT INTO Roles (RoleId, RoleName) VALUES (2, 'Student');
INSERT INTO Roles (RoleId, RoleName) VALUES (3, 'Instructor');


INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (1, 'Abercrombie', 'Kim', '1995-03-11', 'asdf', '1','F', '62, adasd, asdasd');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (2, 'Barzdukas', 'Gytis', '2005-09-01', 'asdf', '2','M', '165, Green Road, City');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (3, 'Justice', 'Peggy', '2001-09-01',  'asdf', '2','F', '536, Icemen Road, Town');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (4, 'Fakhouri', 'Fadi', '1992-08-06', 'asdf', '3','M', '1257, Smiths Land, Town');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (5, 'Harui', 'Roger', '1998-07-01','asdf', '3','M', '1257, Smiths Land, Town');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (6, 'Li', 'Yan', '2002-09-01', 'asdf', '2','M', '6162, China Town, City');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (7, 'Norman', 'Laura', '2003-09-01', 'asdf', '2','M', '21, China Town, City');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (8, 'Olivotto', 'Nino', '2005-09-01', 'asdf', '2','M', '56, Lake Road, City');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (9, 'Tang', 'Wayne', '2005-09-01', 'asdf', '3','M', '36, Lake Road, City');
INSERT INTO Person (PersonID, LastName, FirstName, DateOfBirth, UserPassword, RoleId, Gender,Address)
VALUES (10, 'Alonso', 'Meredith', '2002-09-01', 'asdf', '3','M', '98, fasfasf, City');


INSERT INTO Course (CourseID, Title)
VALUES (1050, 'Chemistry');
INSERT INTO Course (CourseID, Title)
VALUES (1061, 'Physics');
INSERT INTO Course (CourseID, Title)
VALUES (1045, 'Calculus');
INSERT INTO Course (CourseID, Title)
VALUES (2030, 'Poetry');
INSERT INTO Course (CourseID, Title)
VALUES (2021, 'Composition');
INSERT INTO Course (CourseID, Title)
VALUES (2042, 'Literature');
INSERT INTO Course (CourseID, Title)
VALUES (4022, 'Microeconomics');
INSERT INTO Course (CourseID, Title)
VALUES (4041, 'Macroeconomics');
INSERT INTO Course (CourseID, Title)
VALUES (4061, 'Quantitative');
INSERT INTO Course (CourseID, Title)
VALUES (3141, 'Trigonometry');




INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2021, 4);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2030, 4);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2021, 5);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2042, 5);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2021, 9);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2030, 9);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (4022, 9);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (4041, 10);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (4061, 10);


INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2021, 2, 4);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2030, 2, 3.5);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2021, 3, 3);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2030, 3, 4);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2021, 6, 2.5);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2042, 6, 3.5);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2021, 7, 3.5);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2042, 7, 4);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2021, 8, 3);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (2042, 8, 3);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (4041, 8, 3.5);
INSERT INTO StudentGrade (CourseID, PersonID, Grade)
VALUES (4041, 2, null);




CREATE PROCEDURE [dbo].[usp_AddShow]
(
@ScreenID VARCHAR(8),
@Date DATETIME,
@Time VARCHAR(10),
@MovieID VARCHAR(5)
)
AS
BEGIN
BEGIN TRY 
	DECLARE @Tomorrow DATETIME=CAST(GETDATE()+1 AS DATE)
	DECLARE @ShowID VARCHAR(6) 
	IF NOT EXISTS(SELECT 1 from Screen where ScreenID=@ScreenID)
		SELECT -1
	IF NOT EXISTS(SELECT 1 from Movie where MovieId=@MovieID)
		SELECT -2
	IF NOT(@Date>=@Tomorrow)
		SELECT -3
	IF @Time NOT IN ('10 AM','2 PM','6 PM','10 PM')
		SELECT -4
	SELECT @ShowID='S'+CAST((CAST(SUBSTRING(MAX(ShowID),2,5) AS INT)+1) AS VARCHAR) from Show
	INSERT INTO Show VALUES(@ShowID,@ScreenID,@Date,@Time,@MovieId,0)
        SELECT 1

END TRY
BEGIN CATCH
    SELECT -99
END CATCH
END




