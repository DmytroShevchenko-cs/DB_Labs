DROP DATABASE IF EXISTS lab2;

CREATE ROLE testuser LOGIN;

--For linux
CREATE DATABASE lab2 ENCODING 'UTF-8' LC_COLLATE 'en_US.UTF-8' LC_CTYPE 'en_US.UTF-8' TEMPLATE template0 OWNER testuser;

\c lab2

SET ROLE testuser;

CREATE TABLE "Humans"(
	"HumanId" SERIAL PRIMARY KEY,
	"FirstName" varchar(50),
	"LastName" varchar(50),
	"MiddleName" varchar(50),
	"Gender" CHAR(1) CHECK ("Gender" IN ('M', 'F')),  -- M for Male, F for Female
    "Age" INT CHECK ("Age" >= 18), 
	"DateOfBirth" date
);

CREATE TABLE "Cards"(
	"CardId" SERIAL PRIMARY KEY,
	"CardCreationDate" date,
	"PolicyNumber" varchar(50)
);

CREATE TABLE "Patients"(
	"PatientId" int PRIMARY KEY REFERENCES "Humans"("HumanId") ON DELETE RESTRICT,
	"CardId" int REFERENCES "Cards"("CardId") ON DELETE RESTRICT,
	"Address" varchar(255),
	"IsActive" bool DEFAULT TRUE
);

CREATE TABLE "Doctors"(
	"DoctorId" int PRIMARY KEY REFERENCES "Humans"("HumanId") ON DELETE RESTRICT,
	"Category" varchar(50),
	"Experience" int CHECK ("Experience" > 1),  -- Ensure experience is more than internship
	"IsActive" bool DEFAULT TRUE
);

CREATE TABLE "Administrators"(
	"AdministratorId" int PRIMARY KEY REFERENCES "Humans"("HumanId") ON DELETE RESTRICT,
	"Role" varchar(50),
	"Login" varchar(20),
	"Password" varchar(16)
);


CREATE TABLE "Polyclinics"(
	"PolyclinicId" SERIAL PRIMARY KEY,
	"Name" varchar(50),
	"Address" varchar(50)
);


CREATE TABLE "Districts"(
	"DistrictId" SERIAL PRIMARY KEY,
	"PolyclinicId" int REFERENCES "Polyclinics"("PolyclinicId") ON DELETE RESTRICT,
	"Name" varchar(50),
	"Floor" int
);

CREATE TABLE "DoctorDistricts"(
    "DoctorId" int REFERENCES "Doctors"("DoctorId") ON DELETE RESTRICT,
    "DistrictId" int REFERENCES "Districts"("DistrictId") ON DELETE RESTRICT,
	"DateOfStartWork" date not null,
	"DateOfEndWork" date,
    PRIMARY KEY ("DoctorId", "DistrictId")
);

CREATE TYPE Weekday AS ENUM ('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');

CREATE TABLE "Schedule"(
    "ScheduleId" SERIAL PRIMARY KEY,
    "DoctorId" int,
    "DistrictId" int,
    "StartTime" time,
    "EndTime" time,
    "Day" Weekday,
    "RoomNumber" int,
    FOREIGN KEY ("DoctorId", "DistrictId") REFERENCES "DoctorDistricts"("DoctorId", "DistrictId") ON DELETE RESTRICT
);

CREATE TABLE "Visits"(
	"VisitId" SERIAL PRIMARY KEY,
	"PatientId" int REFERENCES "Patients"("PatientId") ON DELETE RESTRICT,
	"ScheduleId" int REFERENCES "Schedule"("ScheduleId") ON DELETE RESTRICT,
	"VisitDate" TIMESTAMP,
	"Diagnosis" text,
	"Prescriptions" text,
	"IsSickLeaveIssued" bool,
	"SickLeaveDuration" date
);


