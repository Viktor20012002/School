CREATE DATABASE School
USE School

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY NOT NULL ,
Name NVARCHAR(20) NOT NULL ,
Lessons INT NOT NULL
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY NOT NULL, 
Date DATE,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY NOT NULL, 
FirstName NVARCHAR(20) NOT NULL ,
MiddleName NVARCHAR(20) ,
LastName NVARCHAR(20) NOT NULL ,
Age INT NOT NULL CHECK ( Age > 0 ) , 
Address NVARCHAR(30),
Phone NVARCHAR(10)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY NOT NULL, 
FirstName NVARCHAR(20) NOT NULL ,
LastName NVARCHAR(20) NOT NULL ,
Address NVARCHAR(30), 
Phone NVARCHAR(10) ,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id)
)
CREATE TABLE StudentsExams(
StudentId INT NOT NULL,
ExamId INT NOT NULL, 
Grade DECIMAL ( 15,2) NOT NULL CHECK ( Grade >= 2 AND Grade <= 6 ),

CONSTRAINT PK_StudentsExams PRIMARY KEY ( StudentId , ExamId),

CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamId) REFERENCES Exams (Id),
)

CREATE TABLE StudentsTeachers(
StudentId INT NOT NULL,
TeacherId INT NOT NULL,

CONSTRAINT PK_StudentsTeachers PRIMARY KEY ( StudentId , TeacherId),
CONSTRAINT FK_StudentsTeachers_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
CONSTRAINT FK_StudentsTeachers_Teachers FOREIGN KEY (TeacherId) REFERENCES Teachers (Id),
)


CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT NOT NULL,
SubjectId INT NOT NULL,
Grade DECIMAL (15,2) NOT NULL CHECK ( Grade >= 2 AND Grade <= 6 ),

CONSTRAINT FK_StudentsSubjects_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
CONSTRAINT FK_StudentsSubjects_Subjects FOREIGN KEY (SubjectId) REFERENCES Subjects (Id),
)


