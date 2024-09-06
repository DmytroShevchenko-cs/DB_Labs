-- patients that are on treatment with current doctor
SELECT 
    ph."FirstName" AS "PatientFirstName",
    ph."LastName" AS "PatientLastName",

	dh."FirstName" AS "DoctorFirstName",
    dh."LastName" AS "DoctorLastName",
    v."VisitDate",
    v."SickLeaveDuration"

FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Humans" ph ON p."HumanId" = ph."HumanId"
JOIN public."DoctorDistricts" dd ON v."DoctorDistrictsId" = dd."DoctorDistrictId"
JOIN public."Doctors" d ON dd."DoctorId" = d."DoctorId"
JOIN public."Humans" dh ON d."HumanId" = dh."HumanId"
WHERE dd."DoctorId" = 3 -- parameter
and v."SickLeaveDuration" > CURRENT_DATE; -- trouble with time zones