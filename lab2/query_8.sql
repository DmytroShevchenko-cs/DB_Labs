-- How much patients were served by all doctors in given polyclinic
SELECT 
	pl."Name" AS "PolyclinicName",
    CONCAT(
		dh."FirstName", 
        ' ', 
        COALESCE(CONCAT(SUBSTRING(dh."MiddleName" FROM 1 FOR 1), '. '), ''), 
        dh."LastName"
    ) AS "DoctorName",
    COUNT(DISTINCT p."PatientId") AS "PatientCount"
FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Schedule" sc ON v."ScheduleId" =  sc."ScheduleId"
JOIN public."Districts" dist ON sc."DistrictId" = dist."DistrictId"
JOIN public."Polyclinics" pl ON dist."PolyclinicId" = pl."PolyclinicId"
JOIN public."Humans" dh ON sc."DoctorId" = dh."HumanId"
WHERE pl."PolyclinicId" = 1
GROUP BY 
    pl."Name",
    dh."FirstName",
    dh."MiddleName",
    dh."LastName"
ORDER BY 
    dh."LastName";
