-- patients that are on treatment with current doctor
SELECT 
    ph."FirstName" AS "PatientFirstName",
    ph."LastName" AS "PatientLastName",
    v."VisitDate",
    v."SickLeaveDuration"

FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Humans" ph ON p."HumanId" = ph."HumanId"
JOIN public."Schedule" sc ON v."ScheduleId" =  sc."ScheduleId"
JOIN public."DoctorDistricts" dd ON sc."DoctorDistrictId" = dd."DoctorDistrictId"
WHERE dd."DoctorId" = 3 -- parameter
and v."SickLeaveDuration" > CURRENT_DATE; -- trouble with time zones