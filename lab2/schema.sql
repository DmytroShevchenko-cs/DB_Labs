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

CREATE TABLE "Patients"(
	"PatientId" SERIAL PRIMARY KEY,
	"Address" varchar(255),
	"HumanId" int REFERENCES "Humans"("HumanId") ON DELETE CASCADE
);

CREATE TABLE "Cards"(
	"CardId" SERIAL PRIMARY KEY,
	"PatientId" int REFERENCES "Patients"("PatientId") ON DELETE CASCADE,
	"CardCreationDate" date,
	"PolicyNumber" varchar(50)
);

CREATE TABLE "Doctors"(
	"DoctorId" SERIAL PRIMARY KEY,
	"HumanId" int REFERENCES "Humans"("HumanId") ON DELETE CASCADE,
	"Category" varchar(50),
	"Experience" int CHECK ("Experience" > 1),  -- Ensure experience is more than internship
	"IsActive" bool 
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
	"DoctorDistrictId" SERIAL PRIMARY KEY,
	"DoctorId" int REFERENCES "Doctors"("DoctorId") ON DELETE RESTRICT,
	"DistrictId" int REFERENCES "Districts"("DistrictId") ON DELETE RESTRICT
);

CREATE TYPE Weekday AS ENUM ('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');

CREATE TABLE "Schedule"(
	"ScheduleId" SERIAL PRIMARY KEY,
	"DoctorDistrictId" int REFERENCES "DoctorDistricts"("DoctorDistrictId") ON DELETE RESTRICT,
	"StartTime" time,
	"EndTime" time,
	"Day" Weekday,
	"RoomNumber" int
);

CREATE TABLE "Visits"(
	"VisitId" SERIAL PRIMARY KEY,
	"PatientId" int REFERENCES "Patients"("PatientId") ON DELETE RESTRICT,
	"ScheduleId" int REFERENCES "Schedule"("ScheduleId") ON DELETE RESTRICT,
	"CardId" int REFERENCES "Cards"("CardId") ON DELETE RESTRICT,
	"VisitDate" TIMESTAMP,
	"Diagnosis" text,
	"Prescriptions" text,
	"IsSickLeaveIssued" bool,
	"SickLeaveDuration" date
);

CREATE TABLE "Administrators"(
	"AdministratorId" SERIAL PRIMARY KEY,
	"HumanId" int REFERENCES "Humans"("HumanId") ON DELETE CASCADE,
	"Role" varchar(50),
	"Login" varchar(20),
	"Password" varchar(16)
);
