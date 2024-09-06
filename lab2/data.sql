-- Patients
INSERT INTO "Patients" ("FirstName", "LastName", "MiddleName", "Gender", "Age", "CardCreationDate")
VALUES
('John', 'Doe', 'A', 'M', 30, '2024-01-15'),
('Jane', 'Smith', 'B', 'F', 45, '2023-11-30'),
('Michael', 'Brown', 'C', 'M', 60, '2024-03-22'),
('Emily', 'Davis', 'D', 'F', 25, '2024-02-01'),
('Sarah', 'Wilson', 'E', 'F', 35, '2024-01-25');

-- Doctors
INSERT INTO "Doctors" ("FirstName", "LastName", "MiddleName", "Category", "Experience", "DateOfBirth")
VALUES
('Alice', 'Johnson', 'M', 'Cardiologist', 15, '1980-04-12'),
('Bob', 'Williams', 'N', 'Orthopedic', 20, '1975-09-25'),
('Charlie', 'Jones', 'O', 'Pediatrician', 10, '1990-07-08'),
('Diana', 'Garcia', 'P', 'Dermatologist', 5, '1985-12-30'),
('Ethan', 'Martinez', 'Q', 'Neurologist', 8, '1988-03-14');

-- Districts
INSERT INTO "Districts" ("DistrictName", "Address")
VALUES
('Central District', '123 Main St, Cityville'),
('North District', '456 Elm St, Cityville'),
('South District', '789 Oak St, Cityville'),
('East District', '101 Pine St, Cityville'),
('West District', '202 Maple St, Cityville');

-- DoctorDistricts
INSERT INTO "DoctorDistricts" ("DoctorId", "DistrictId", "StartTime", "EndTime", "RoomNumber")
VALUES
(1, 1, '09:00:00', '17:00:00', 101),
(2, 2, '10:00:00', '18:00:00', 202),
(3, 3, '08:00:00', '16:00:00', 303),
(4, 4, '11:00:00', '19:00:00', 404),
(5, 5, '07:00:00', '15:00:00', 505);

-- Visits
INSERT INTO "Visits" ("PatientId", "DoctorDistrictsId", "VisitDate", "Diagnosis", "Prescriptions", "IsSickLeaveIssued", "SickLeaveDuration")
VALUES
(1, 1, '2024-01-20', 'Flu', 'Flu medication', true, '5 days'),
(2, 2, '2024-02-10', 'Back Pain', 'Pain relief', false, NULL),
(3, 3, '2024-03-05', 'Rash', 'Topical cream', true, '2 days'),
(4, 4, '2024-04-15', 'Check-up', 'Routine examination', false, NULL),
(5, 5, '2024-05-25', 'Headache', 'Painkiller', true, '3 days');

-- Administrators
INSERT INTO "Administrators" ("FirstName", "LastName", "MiddleName", "Role", "Login", "Password")
VALUES
('Michael', 'Adams', 'K', 'Admin', 'madams', 'password123'),
('Laura', 'Baker', 'L', 'HR', 'lbaker', 'password456'),
('James', 'Clark', 'M', 'Manager', 'jclark', 'password789'),
('Sophia', 'Miller', 'N', 'Support', 'smiller', 'password012'),
('Daniel', 'Taylor', 'O', 'Admin', 'dtaylor', 'password345');
