-- get all visits with joins
SELECT 
    v."VisitId",
    p."FirstName" AS "PatientFirstName",
    p."LastName" AS "PatientLastName",
    d."FirstName" AS "DoctorFirstName",
    d."LastName" AS "DoctorLastName",
    dis."Address" AS "DistrictAddress",
    dd."RoomNumber",
    v."VisitDate", 
    v."Diagnosis", 
    v."Prescriptions", 
    v."IsSickLeaveIssued", 
    v."SickLeaveDuration"
FROM public."Visits" v
JOIN public."DoctorDistricts" dd ON v."DoctorDistrictsId" = dd."DoctorDistrictId"
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Doctors" d ON dd."DoctorId" = d."DoctorId"
JOIN public."Districts" dis ON dd."DistrictId" = dis."DistrictId";
