--all visits of patient (just for comparing)
SELECT 
    h."FirstName" AS "PatientFirstName",
    h."LastName" AS "PatientLastName",	
    p."Address" AS "PatientAddress",
    v."VisitDate",
    v."Diagnosis"
FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Humans" h ON p."HumanId" = h."HumanId"
WHERE p."PatientId" = 2;

--last visits of patient
SELECT 
    h."FirstName" AS "PatientFirstName",
    h."LastName" AS "PatientLastName",	
    p."Address" AS "PatientAddress",
    v."VisitDate",
    v."Diagnosis"
FROM public."Visits" v
JOIN public."Patients" p ON v."PatientId" = p."PatientId"
JOIN public."Humans" h ON p."HumanId" = h."HumanId"
WHERE p."PatientId" = 2
AND v."VisitDate" = (
    SELECT MAX(v2."VisitDate")
    FROM public."Visits" v2
    JOIN public."Patients" p2 ON v2."PatientId" = p2."PatientId"
    WHERE p2."PatientId" = p."PatientId"
);
