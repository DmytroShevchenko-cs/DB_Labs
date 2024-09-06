DROP DATABASE IF EXISTS lab2;

CREATE ROLE testuser LOGIN;

--For linux
CREATE DATABASE lab2 ENCODING 'UTF-8' LC_COLLATE 'en_US.UTF-8' LC_CTYPE 'en_US.UTF-8' TEMPLATE template0 OWNER testuser;

\c lab2

SET ROLE testuser;

CREATE TABLE "Patients"(
	"PatientId" SERIAL PRIMARY KEY,
	"FirstName" varchar(50),
	"LastName" varchar(50),
	"MiddleName" varchar(50),
	"Gender" CHAR(1) CHECK ("Gender" IN ('M', 'F')),  -- M for Male, F for Female
    "Age" INT CHECK ("Age" >= 3), 
	"CardCreationDate" date
);

CREATE TABLE "Doctors"(
	"DoctorId" SERIAL PRIMARY KEY,
	"FirstName" varchar(50),
	"LastName" varchar(50),
	"MiddleName" varchar(50),
	"Category" varchar(50),
	"Experience" int CHECK ("Experience" >= 0),  -- Ensure experience is non-negative
	"DateOfBirth" date
);

CREATE TABLE "Districts"(
	"DistrictId" SERIAL PRIMARY KEY,
	"DistrictName" varchar(50),
	"Address" varchar(50)
);

CREATE TABLE "DoctorDistricts"(
	"DoctorDistrictId" SERIAL PRIMARY KEY,
	"DoctorId" int REFERENCES "Doctors"("DoctorId") ON DELETE CASCADE,
	"DistrictId" int REFERENCES "Districts"("DistrictId") ON DELETE CASCADE,
	"StartTime" time,
	"EndTime" time,
	"RoomNumber" int
);

CREATE TABLE "Visits"(
	"VisitId" SERIAL PRIMARY KEY,
	"PatientId" int REFERENCES "Patients"("PatientId") ON DELETE SET NULL,
	"DoctorDistrictsId" int REFERENCES "DoctorDistricts"("DoctorDistrictId") ON DELETE SET NULL,
	"VisitDate" date,
	"Diagnosis" text,
	"Prescriptions" text,
	"IsSickLeaveIssued" bool,
	"SickLeaveDuration" text
);

CREATE TABLE "Administrators"(
	"AdministratorId" SERIAL PRIMARY KEY,
	"FirstName" varchar(50),
	"LastName" varchar(50),
	"MiddleName" varchar(50),
	"Role" varchar(50),
	"Login" varchar(20),
	"Password" varchar(16)
);

