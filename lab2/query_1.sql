--all visits of patient (just for comparing)
SELECT 
    h."FirstName" AS "PatientFirstName",
    h."LastName" AS "PatientLastName",	
    p."Address" AS "PatientAddress",
    v."VisitDate",
    v."Diagnosis"
FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Humans" h ON p."PatientId" = h."HumanId"
WHERE p."PatientId" = 2;

SELECT DISTINCT ON (v."PatientId")
    p."Address" AS "PatientAddress",
    v."VisitDate",
    v."Diagnosis"
FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
WHERE v."PatientId" = 2
ORDER BY v."PatientId", v."VisitDate" DESC;