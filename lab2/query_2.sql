-- Surname and initials of patient
SELECT DISTINCT
    CONCAT(
		dh."LastName", 
        '.', 
        LEFT(dh."FirstName", 1), 
        '.', 
        LEFT(dh."MiddleName", 1), 
        '.'
    ) AS "DoctorInitials"
FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Humans" ph ON p."HumanId" = ph."HumanId"
JOIN public."Schedule" sc ON v."ScheduleId" =  sc."ScheduleId"
JOIN public."DoctorDistricts" dd ON sc."DoctorDistrictId" = dd."DoctorDistrictId"
JOIN public."Doctors" d ON dd."DoctorId" = d."DoctorId"
JOIN public."Humans" dh ON d."HumanId" = dh."HumanId"
WHERE v."PatientId" = 2; -- parameter
