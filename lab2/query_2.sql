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
JOIN public."Schedule" sc ON v."ScheduleId" =  sc."ScheduleId"
JOIN public."Humans" dh ON sc."DoctorId" = dh."HumanId"
WHERE v."PatientId" = 2; -- parameter
