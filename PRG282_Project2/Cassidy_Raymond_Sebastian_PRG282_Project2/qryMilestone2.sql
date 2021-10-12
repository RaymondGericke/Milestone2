CREATE DATABASE Milestone2;

USE Milestone2
Go

CREATE Table Students
(
	StudentNumber INT NOT NULL,
	sName VARCHAR(100),
	Surname VARCHAR(100),
	StudentIMG VARBINARY(MAX),
	DOB DATE,
	GENDER VARCHAR(20),
	PhoneNo VARCHAR(11),
	Address VARCHAR(100),
	ModCodes VARCHAR(8)
)

GO
CREATE PROCEDURE spGetStudents
AS
BEGIN
	SELECT * FROM Students
END

GO
EXECUTE spGetStudents

GO
CREATE PROCEDURE spAddStudent
(
	@StudentNumber INT,
	@sName VARCHAR(100),
	@Surname VARCHAR(100),
	@StudentIMG VARBINARY(MAX),
	@DOB DATE,
	@GENDER VARCHAR(20),
	@PhoneNo VARCHAR(11),
	@Address VARCHAR(100),
	@ModCodes VARCHAR(8)
)
AS
BEGIN
	INSERT INTO Students
	VALUES (@StudentNumber,@sName, @Surname, @StudentIMG, @DOB, @GENDER, @PhoneNo, @Address, @ModCodes)
END

GO
CREATE PROCEDURE spUpdateStudent
(
	@StudentNumber INT,
	@sName VARCHAR(100),
	@Surname VARCHAR(100),
	@StudentIMG VARBINARY(MAX),
	@DOB DATE,
	@GENDER VARCHAR(20),
	@PhoneNo VARCHAR(11),
	@Address VARCHAR(100),
	@ModCodes VARCHAR(8)
)
AS
BEGIN
	UPDATE Students
	SET StudentNumber = @StudentNumber, sName = @sName, Surname = @Surname, StudentIMG = @StudentIMG, DOB = @DOB, GENDER = @GENDER, PhoneNo =  @PhoneNo, Address = @Address, ModCodes = @ModCodes
	WHERE @StudentNumber = @StudentNumber
END

GO
CREATE PROCEDURE spDeleteStudent
(
	@StudentNumber INT
)
AS
BEGIN
	DELETE FROM Students
	WHERE StudentNumber = @StudentNumber
END

GO
CREATE PROCEDURE spSearchStudent
(
	@StudentNumber INT
)
AS
BEGIN
	SELECT * FROM Students
	WHERE StudentNumber = @StudentNumber 
END

GO
CREATE Table Modules
(
	ModCode VARCHAR(8),
	ModName VARCHAR(20),
	ModuleDesc VARCHAR(100),
	RecourceLinks NVARCHAR(max)
)

GO
CREATE PROCEDURE spAddModule
(
	@ModCode VARCHAR(8),
	@ModName VARCHAR(20),
	@ModuleDesc VARCHAR(100),
	@RecourceLinks NVARCHAR(max)
)
AS
BEGIN
	INSERT INTO Modules
	VALUES (@ModCode, @ModName, @ModuleDesc, @RecourceLinks)
END