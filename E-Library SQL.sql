create database [E-Library 04]
Go

create table dbo.ClassHistory(
	ClassHistoryID int identity(1,1) PRIMARY KEY,
	Teacher varchar(500) NOT NULL,
	Subject varchar(500) NOT NULL,
	Description varchar(500) NOT NULL,
	Class varchar(500) NOT NULL,
	ClassSchedule varchar(500) NOT NULL,
	StartingDate varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL,
	Content varchar(500) NOT NULL,
	ExamDate varchar(500) NOT NULL,
	ClassCode varchar(500) NOT NULL,
	SecurityPassword varchar(500) NOT NULL,
	OtherSetting varchar(500) NOT NULL,
	SharedLink varchar(500) NOT NULL
)
Go

create table dbo.ClassroomSetting(
	ClassroomSettingID int identity(1,1) PRIMARY KEY,
	SubjectType varchar(500) NOT NULL,
	Notification varchar(500) NOT NULL,
	Status varchar(500) NOT NULL
)
Go

create table dbo.Course(
	CourseID int identity(1,1) PRIMARY KEY,
	CompletedCourse varchar(500) NOT NULL,
	UncompletedCourse varchar(500) NOT NULL
)
Go

create table dbo.DisciplinaryList(
	DisciplinaryListID int identity(1,1) PRIMARY KEY,
	StudentCode varchar(500) NOT NULL,
	StudentName varchar(500) NOT NULL,
	DateOfBirth varchar(500) NOT NULL,
	Sex varchar(500) NOT NULL,
	DisciplinaryNumber varchar(500) NOT NULL,
	DisciplinaryDate varchar(500) NOT NULL,
	DisciplinaryContent varchar(500) NOT NULL
)
Go

create table dbo.ExamGrade(
	ExamGradeID int identity(1,1) PRIMARY KEY,
	AttendanceGrade varchar(500) NOT NULL,
	OralTest varchar(500) NOT NULL,
	AQuarterHourTest varchar(500) NOT NULL,
	HalfHourTest varchar(500) NOT NULL,
	MidTermTest varchar(500) NOT NULL,
	FinalTestTest varchar(500) NOT NULL,
	YearAverageGrade varchar(500) NOT NULL,
	Pass varchar(500) NOT NULL,
	UpdateDate varchar(500) NOT NULL
)
Go

create table dbo.FileData(
	Id int identity(1,1) PRIMARY KEY,
	FileName varchar(500) NOT NULL,
	FileExtension varchar(500) NOT NULL,
	MimeType varchar(500) NOT NULL,
	FilePath varchar(500) NOT NULL
)
Go

create table dbo.Grade(
	GradeID int identity(1,1) PRIMARY KEY,
	GradeName varchar(500) NOT NULL,
	ScoreFactor varchar(500) NOT NULL,
	MinimumNumberOfColumnsForSemester1 varchar(500) NOT NULL,
	MinimumNumberOfColumnsForSemester2 varchar(500) NOT NULL
)
Go

create table dbo.Help(
	HelpID int identity(1,1) PRIMARY KEY,
	Topic varchar(500) NOT NULL,
	Description varchar(500) NOT NULL
)
Go

create table dbo.Lesson(
	LessonID int identity(1,1) PRIMARY KEY,
	LessonTopic varchar(500) NOT NULL,
	Description varchar(500) NOT NULL,
	TeachingAssistant varchar(500) NOT NULL,
	LessionTime varchar(500) NOT NULL,
	StartingDate varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL,
	SecurityPassword varchar(500) NOT NULL,
	OtherSetting varchar(500) NOT NULL,
	ShareLink varchar(500) NOT NULL
)
Go

create table dbo.ExamList(
	ExamListID int identity(1,1) PRIMARY KEY,
	Topic varchar(500) NOT NULL,
	Description varchar(500) NOT NULL,
	TeachingAssistant varchar(500) NOT NULL,
	ExamAmountOfTime varchar(500) NOT NULL,
	StartingDate varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL,
	SecurityPassword varchar(500) NOT NULL,
	OtherSetting varchar(500) NOT NULL,
	SharedLink varchar(500) NOT NULL,
	ExamContent varchar(500) NOT NULL,
	Class varchar(500) NOT NULL,
	Subject varchar(500) NOT NULL,
	Department varchar(500) NOT NULL
)
Go

create table dbo.ListOfAward(
	ListOfAwardID int identity(1,1) PRIMARY KEY,
	StudentCode varchar(500) NOT NULL,
	StudentName varchar(500) NOT NULL,
	DateOfBirth varchar(500) NOT NULL,
	Sex varchar(500) NOT NULL,
	AwardNumber varchar(500) NOT NULL,
	AwardDate varchar(500) NOT NULL,
	AwardContent varchar(500) NOT NULL
)
Go

create table dbo.ManageExamSchedule(
	ManageExamScheduleID int identity(1,1) PRIMARY KEY,
	Semester varchar(500) NOT NULL,
	ExamDate varchar(500) NOT NULL,
	Department varchar(500) NOT NULL,
	ExamSubject varchar(500) NOT NULL,
	ExamName varchar(500) NOT NULL,
	Status varchar(500) NOT NULL,
	ExamMarkingAssignment varchar(500) NOT NULL
)
Go

create table dbo.ManagementOfTrainingLevels(
	ManagementOfTrainingLevelsID int identity(1,1) PRIMARY KEY,
	DegreeTraining varchar(500) NOT NULL,
	Status varchar(500) NOT NULL,
	FormOfTraining varchar(500) NOT NULL,
	TrainingTime varchar(500) NOT NULL,
	Notification varchar(500) NOT NULL
)
Go

create table dbo.Notification(
	NotificationID int identity(1,1) PRIMARY KEY,
	Receiver varchar(500) NOT NULL,
	Topic varchar(500) NOT NULL,
	Description varchar(500) NOT NULL
)
Go

create table dbo.OnlineClass(
	OnlineClassID int identity(1,1) PRIMARY KEY
)
Go

create table dbo.QAQuestionaire(
	QAQuestionaireID int identity(1,1) PRIMARY KEY
)
Go

create table dbo.ReservationRecord(
	ReservationRecordID int identity(1,1) PRIMARY KEY,
	StudentCode varchar(500) NOT NULL,
	StudentName varchar(500) NOT NULL,
	DateOfBirth varchar(500) NOT NULL,
	Sex varchar(500) NOT NULL,
	ReserveClass varchar(500) NOT NULL,
	ReserveDate varchar(500) NOT NULL,
	ReservePeriod varchar(500) NOT NULL,
	ReserveReason varchar(500) NOT NULL
)
Go

create table dbo.SchoolInformation(
	SchoolInformationID int identity(1,1) PRIMARY KEY,
	SchoolName varchar(500) NOT NULL,
	SchoolCode varchar(500) NOT NULL,
	ProvinceCity varchar(500) NOT NULL,
	Ward varchar(500) NOT NULL,
	District varchar(500) NOT NULL,
	Headquarter varchar(500) NOT NULL,
	SchoolType varchar(500) NOT NULL,
	PhoneNumber varchar(500) NOT NULL,
	Fax varchar(500) NOT NULL,
	Email varchar(500) NOT NULL,
	FoundedDate varchar(500) NOT NULL,
	SchoolEstablishmentModel varchar(500) NOT NULL,
	Website varchar(500) NOT NULL,
	Principal varchar(500) NOT NULL,
	PrincipalPhoneNumber varchar(500) NOT NULL,
	FacilityName varchar(500) NOT NULL,
	Address varchar(500) NOT NULL,
	SchoolPhoneNumber varchar(500) NOT NULL,
	PersonInCharge varchar(500) NOT NULL,
	CellphoneNumber varchar(500) NOT NULL
)
Go

create table dbo.SchoolTransferAdmission(
	SchoolTransferAdmissionID int identity(1,1) PRIMARY KEY,
	StudentName varchar(500) NOT NULL,
	StudentCode varchar(500) NOT NULL,
	DateOfBirth varchar(500) NOT NULL,
	Sex varchar(500) NOT NULL,
	TransferDate varchar(500) NOT NULL,
	TransferSemester varchar(500) NOT NULL,
	ProvinceCity varchar(500) NOT NULL,
	District varchar(500) NOT NULL,
	TransferFrom varchar(500) NOT NULL,
	TransferReason varchar(500) NOT NULL,
	Department varchar(500) NOT NULL
)
Go

create table dbo.SchoolYear(
	SchoolYearID int identity(1,1) PRIMARY KEY,
	Serial varchar(500) NOT NULL,
	SchoolYearTime varchar(500) NOT NULL,
	StartingDate varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL,
	SemesterName varchar(500) NOT NULL,
	SemesterStartDate varchar(500) NOT NULL,
	SemesterEndDate varchar(500) NOT NULL
)
Go

create table dbo.Department(
	DepartmentID int identity(1,1) PRIMARY KEY,
	DepartmentCode varchar(500) NOT NULL,
	DepartmentName varchar(500) NOT NULL,
	Dean varchar(500) NOT NULL
)
Go

create table dbo.Class(
	ClassID int identity(1,1) PRIMARY KEY,
	ClassCode varchar(500) NOT NULL,
	ClassDate varchar(500) NOT NULL,
	ClassName varchar(500) NOT NULL,
	HomeroomTeacher varchar(500) NOT NULL,
	StudentNumber varchar(500) NOT NULL,
	ClassClassify varchar(500) NOT NULL,
	Description varchar(500) NOT NULL,
	SchoolYearID int FOREIGN KEY REFERENCES SchoolYear(SchoolYearID),
	DepartmentID int FOREIGN KEY REFERENCES Department(DepartmentID)
)
Go

create table dbo.Student(
	StudentID int identity(1,1) PRIMARY KEY,
	FullName varchar(500) NOT NULL,
	StudentCode varchar(500) NOT NULL,
	DateOfAdmission varchar(500) NOT NULL,
	DateOfBirth varchar(500) NOT NULL,
	Sex varchar(500) NOT NULL,
	PlaceOfBirth varchar(500) NOT NULL,
	Ethnic varchar(500) NOT NULL,
	Religion varchar(500) NOT NULL,
	Class varchar(500) NOT NULL,
	GraduateForm varchar(500) NOT NULL,
	StudyStatus varchar(500) NOT NULL,
	ProvinceCity varchar(500) NOT NULL,
	District varchar(500) NOT NULL,
	Wards varchar(500) NOT NULL,
	Address varchar(500) NOT NULL,
	Email varchar(500) NOT NULL,
	PhoneNumber varchar(500) NOT NULL,
	FatherFullName varchar(500) NOT NULL,
	MotherFullName varchar(500) NOT NULL,
	GuardianFullName varchar(500) NOT NULL,
	FatherDateOfBirth varchar(500) NOT NULL,
	MotherDateOfBirth varchar(500) NOT NULL,
	GuardianDateOfBirth varchar(500) NOT NULL,
	FatherOccupation varchar(500) NOT NULL,
	MotherOccupation varchar(500) NOT NULL,
	GuardianOccupation varchar(500) NOT NULL,
	FatherPhoneNumber varchar(500) NOT NULL,
	MotherPhoneNumber varchar(500) NOT NULL,
	GuardianPhoneNumber varchar(500) NOT NULL,
)
Go

create table dbo.Subject(
	SubjectID int identity(1,1) PRIMARY KEY,
	SubjectCode varchar(500) NOT NULL,
	SubjectName varchar(500) NOT NULL,
	SubjectType varchar(500) NOT NULL,
	FirstSemesterLession varchar(500) NOT NULL,
	SecondSemesterLession varchar(500) NOT NULL
)
Go

create table dbo.SubjectGroup(
	SubjectGroupID int identity(1,1) PRIMARY KEY,
	SubjectGroupName varchar(500) NOT NULL,
	HeadOfDepartment varchar(500) NOT NULL,
	SubjectID int FOREIGN KEY REFERENCES Subject(SubjectID)
)
Go

create table dbo.Exam(
	ExamID int identity(1,1) PRIMARY KEY,
	ExamTopic varchar(500) NOT NULL,
	TestForm varchar(500) NOT NULL,
	Grade varchar(500) NOT NULL,
	ExamTime varchar(500) NOT NULL,
	ExamClassify varchar(500) NOT NULL,
	StartingDate varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL,
	Description varchar(500) NOT NULL,
	OtherSetting varchar(500) NOT NULL,
	SubjectGroupID int FOREIGN KEY REFERENCES SubjectGroup(SubjectGroupID)
)
Go

create table dbo.SubjectSetting(
	SubjectSettingID int identity(1,1) PRIMARY KEY,
	SubjectType varchar(500) NOT NULL,
	Notification varchar(500) NOT NULL,
	Status varchar(500) NOT NULL
)
Go

create table dbo.TeacherWordHistory(
	TeacherWordHistoryID int identity(1,1) PRIMARY KEY,
	Teacher varchar(500) NOT NULL,
	Agency varchar(500) NOT NULL,
	Position varchar(500) NOT NULL,
	StartingDate datetime NOT NULL,
	EndingDate datetime NOT NULL
)
Go

create table dbo.Teacher(
	TeacherID int identity(1,1) PRIMARY KEY,
	TeacherCode varchar(500) NOT NULL,
	FullName varchar(500) NOT NULL,
	DateOfBirth varchar(500) NOT NULL,
	Sex varchar(500) NOT NULL,
	SubjectGroup varchar(500) NOT NULL,
	Position varchar(500) NOT NULL,
	Ethnic varchar(500) NOT NULL,
	StartingDate datetime NOT NULL,
	Nationality varchar(500) NOT NULL,
	Religion varchar(500) NOT NULL,	
	Status varchar(500) NOT NULL,	
	Aliases varchar(500) NOT NULL,
	ProvinceCity varchar(500) NOT NULL,
	Ward varchar(500) NOT NULL,
	District varchar(500) NOT NULL,
	Address varchar(500) NOT NULL,
	Email varchar(500) NOT NULL,
	PhoneNumber varchar(500) NOT NULL,
	UnionMembers varchar(500) NOT NULL,
	PartyMembers varchar(500) NOT NULL,
	DateOfJoiningTheUnion datetime NOT NULL,
	DateOfJoiningTheParty datetime NOT NULL
)
Go

create table dbo.TeachingAssignment(
	TeachingAssignmentID int identity(1,1) PRIMARY KEY,
	Classroom varchar(500) NOT NULL,
	StartingDate varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL,
	Description varchar(500) NOT NULL
)
Go

create table dbo.TopicList(
	TopicListID int identity(1,1) PRIMARY KEY,
	Topic varchar(500) NOT NULL,
	Description varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL
)
Go

create table dbo.TrainingProgram(
	TrainingProgramID int identity(1,1) PRIMARY KEY,
	Teacher varchar(500) NOT NULL,
	TrainingFacilities varchar(500) NOT NULL,
	UniversityMajor varchar(500) NOT NULL,
	StartingDate varchar(500) NOT NULL,
	EndingDate varchar(500) NOT NULL,
	FormsOfTraining varchar(500) NOT NULL,
	DiplomasAndCertificates varchar(500) NOT NULL
)
Go

create table dbo.UserGroup(
	UserID int identity(1,1) PRIMARY KEY,
	GroupName varchar(500) NOT NULL,
	UserNumber varchar(500) NOT NULL,
	Notification varchar(500) NOT NULL,
	Decentralization varchar(500) NOT NULL,
	DataDeclaration varchar(500) NOT NULL,
	StudentProfile varchar(500) NOT NULL,
	TeacherProfile varchar(500) NOT NULL,
	Examination varchar(500) NOT NULL,
	SystemUpdate varchar(500) NOT NULL
)
Go

create table dbo.UserList(
	UserListID int identity(1,1) PRIMARY KEY,
	Username varchar(500) NOT NULL,
	Email varchar(500) NOT NULL,
	UserGroup varchar(500) NOT NULL,
	Status varchar(500) NOT NULL
)
Go