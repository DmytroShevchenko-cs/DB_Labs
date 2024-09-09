-- Humans
INSERT INTO "Humans" ("FirstName", "LastName", "MiddleName", "Gender", "Age", "DateOfBirth")
VALUES 
('John', 'Doe', 'Michael', 'M', 35, '1989-03-25'),
('Jane', 'Smith', 'Anna', 'F', 28, '1996-07-10'),
('Richard', 'Miles', 'James', 'M', 42, '1981-01-15'),
('Sarah', 'Johnson', 'Louise', 'F', 30, '1993-09-09'),
('David', 'Brown', 'Henry', 'M', 55, '1969-11-11'),
('Emily', 'Davis', 'Grace', 'F', 24, '1999-02-12'),
('Michael', 'Wilson', 'George', 'M', 38, '1985-07-07'),
('Laura', 'Taylor', 'Marie', 'F', 31, '1992-11-22');


-- Patients
INSERT INTO "Patients" ("PatientId", "Address")
VALUES
(1, '123 Elm St'),
(2, '456 Oak Ave'),
(3, '789 Pine Ln'),
(4, '321 Maple Blvd'),
(5, '654 Cedar Ct'),
(6, '987 Walnut Rd'),
(7, '543 Pinewood St'),
(8, '789 Cedar Dr');


--Cards
INSERT INTO "Cards" ("CardCreationDate", "PolicyNumber")
VALUES
('2021-03-25', 'POL123456'),
('2022-05-12', 'POL654321'),
('2020-01-05', 'POL789012'),
('2021-09-11', 'POL345678'),
('2023-06-30', 'POL567890'),
('2022-08-22', 'POL678901'),
('2023-02-14', 'POL345432'),
('2021-11-15', 'POL567321');


-- Doctors
INSERT INTO "Doctors" ("DoctorId", "Category", "Experience", "IsActive")
VALUES
(3, 'Cardiologist', 10, true),
(1, 'General Practitioner', 5, true),
(4, 'Pediatrician', 6, true),
(5, 'Surgeon', 15, true),
(7, 'Neurologist', 9, true),
(8, 'Dermatologist', 7, true),
(2, 'Endocrinologist', 8, true),
(6, 'Cardiologist', 7, true);


--Polyclinics
INSERT INTO "Polyclinics" ("Name", "Address")
VALUES
('Central Polyclinic', '100 Main St'),
('Northside Medical Center', '200 North St'),
('Eastside Clinic', '300 East Ave'),
('Westside Healthcare', '400 West Blvd'),
('Southside Medical Plaza', '500 South St');


-- Districts
INSERT INTO "Districts" ("PolyclinicId", "Name", "Floor")
VALUES
(1, 'District 1', 2),
(1, 'District 2', 3),
(2, 'District 3', 1),
(2, 'District 4', 4),
(3, 'District 5', 2),
(4, 'District 6', 3),
(5, 'District 7', 1);


-- DoctorDistricts
INSERT INTO "DoctorDistricts" ("DoctorId", "DistrictId", "DateOfStartWork")
VALUES
(1, 1, '2018-03-25'),
(2, 2, '2019-02-24'),
(3, 3, '2021-06-09'),
(4, 4, '2020-07-16'),
(5, 5, '2021-08-01'),
(6, 6, '2023-02-21'),
(7, 7, '2022-11-12');


-- Schedule
INSERT INTO "Schedule" ("DoctorId", "DistrictId", "StartTime", "EndTime", "Day", "RoomNumber")
VALUES
(1, 1, '09:00', '17:00', 'Monday', 101),
(1, 1, '09:00', '17:00', 'Wednesday', 101),
(2, 2, '10:00', '16:00', 'Tuesday', 102),
(2, 2, '10:00', '16:00', 'Thursday', 102),
(2, 2, '08:00', '14:00', 'Monday', 103),
(3, 3, '08:00', '14:00', 'Friday', 103),
(4, 4, '12:00', '18:00', 'Tuesday', 104),
(4, 4, '12:00', '18:00', 'Friday', 104),
(5, 5, '09:00', '15:00', 'Wednesday', 105),
(5, 5, '09:00', '15:00', 'Thursday', 105),
(6, 6, '11:00', '19:00', 'Monday', 106),
(6, 6, '11:00', '19:00', 'Tuesday', 106),
(7, 7, '08:00', '13:00', 'Thursday', 107),
(7, 7, '08:00', '13:00', 'Friday', 107);


-- Visits
INSERT INTO "Visits" ("PatientId", "ScheduleId", "VisitDate", "Diagnosis", "Prescriptions", "IsSickLeaveIssued", "SickLeaveDuration")
VALUES
(1, 1, '2024-09-01 09:00:00', 'Flu', 'Paracetamol', TRUE, '2024-09-10'),
(1, 2, '2024-09-10 10:00:00', 'Headache', 'Ibuprofen', FALSE, NULL),
(2, 1, '2024-09-05 11:00:00', 'Back Pain', 'Tylenol', TRUE, '2024-09-11'),
(2, 3, '2024-09-15 14:00:00', 'Cough', 'Cough Syrup', FALSE, NULL),
(3, 2, '2024-09-07 08:30:00', 'Allergy', 'Antihistamines', FALSE, NULL),
(3, 4, '2024-09-20 13:00:00', 'Stomach Ache', 'Antacids', TRUE, '2024-09-21'),
(4, 3, '2024-09-12 15:00:00', 'Flu', 'Cough Syrup', TRUE, '2024-09-15'),
(4, 5, '2024-09-22 09:30:00', 'Headache', 'Pain Relievers', FALSE, NULL),
(5, 4, '2024-09-03 10:00:00', 'Skin Rash', 'Topical Cream', FALSE, NULL),
(5, 6, '2024-09-18 11:30:00', 'Fever', 'Antipyretics', TRUE, '2024-09-21');


-- Administrators
INSERT INTO "Administrators" ("AdministratorId", "Role", "Login", "Password")
VALUES
(5, 'Admin', 'admin1', 'adminPass1'),
(1, 'Manager', 'manager1', 'managerPass1'),
(3, 'HR', 'hr1', 'hrPass1'),
(2, 'Supervisor', 'sup1', 'supPass1'),
(4, 'IT Support', 'it1', 'itPass1');


