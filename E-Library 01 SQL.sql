create database [E-Library 01]
Go

create table subject_management (
	subjectID int identity(1,1) primary key,
	subject_name varchar(500) NOT NULL
)
Go
create table lession_management (
	lessionID int identity(1,1) primary key,
	lession_name varchar(500) NOT NULL
)
Go
create table resource_management (
	resourceID int identity(1,1) primary key,
	resource_name varchar(500) NOT NULL
)
Go
create table exam_and_test_management (
	exam_and_test_ID int identity(1,1) primary key,
	exam_and_test_name varchar(500) NOT NULL
)
Go
create table notification_management (
	notificationID int identity(1,1) primary key,
	notification_name varchar(500) NOT NULL
)
Go
create table help_management (
	helpID int identity(1,1) primary key,
	help_name varchar(500) NOT NULL
)
Go
create table teacher (
	teacherID int identity(1,1) primary key,
	teacher_name varchar(500) NOT NULL,
	teacher_username varchar(15) NOT NULL,
	teacher_password varchar(20) NOT NULL,
	subjectID int FOREIGN KEY REFERENCES subject_management(subjectID),
	lessionID int FOREIGN KEY REFERENCES lession_management(lessionID),
	resourceID int FOREIGN KEY REFERENCES resource_management(resourceID),
	exam_and_test_ID int FOREIGN KEY REFERENCES exam_and_test_management(exam_and_test_ID),
	notificationID int FOREIGN KEY REFERENCES notification_management(notificationID),
	helpID int FOREIGN KEY REFERENCES help_management(helpID),
	userID int FOREIGN KEY REFERENCES user_management(userID)
)
Go
create table user_management (
	userID int identity(1,1) primary key,
	username varchar(500) NOT NULL,
	password varchar(500) NOT NULL,
	role varchar(500) NOT NULL
)
Go
create table system_management (
	systemID int identity(1,1) primary key,
	system_name varchar(500) NOT NULL
)
Go
create table exam_bank_management (
	exam_bankID int identity(1,1) primary key,
	exam_bank_name varchar(500) NOT NULL
)
Go
create table file_management (
	fileID int identity(1,1) primary key,
	file_name varchar(500) NOT NULL
)
Go
create table admin (
	adminID int identity(1,1) primary key,
	admin_name varchar(500) NOT NULL,
	admin_username varchar(20) NOT NULL,
	admin_password varchar(20) NOT NULL,
	teacherID int FOREIGN KEY REFERENCES teacher(teacherID),
	userID int FOREIGN KEY REFERENCES user_management(userID),
	roleID int FOREIGN KEY REFERENCES role_management(roleID),
	systemID int FOREIGN KEY REFERENCES system_management(systemID),
	subjectID int FOREIGN KEY REFERENCES subject_management(subjectID),
	exam_bankID int FOREIGN KEY REFERENCES exam_bank_management(exam_bankID),
	fileID int FOREIGN KEY REFERENCES file_management(fileID),
	notificationID int FOREIGN KEY REFERENCES notification_management(notificationID)
)
Go
select * from dbo.subject_management
Go
