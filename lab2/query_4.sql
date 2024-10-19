-- patients that are on treatment with current doctor
SELECT 
    ph."FirstName" AS "PatientFirstName",
    ph."LastName" AS "PatientLastName",
    v."VisitDate",
    v."SickLeaveDuration"

FROM public."Visits" v
JOIN public."Humans" ph ON v."PatientId" = ph."HumanId"
JOIN public."Schedule" sc ON v."ScheduleId" =  sc."ScheduleId"
WHERE sc."DoctorId" = 3 -- parameter
and v."SickLeaveDuration" > CURRENT_DATE; -- trouble with time zones