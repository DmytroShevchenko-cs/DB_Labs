-- How many patient visited the doctor in a given month
SELECT 
	COUNT(*) AS "VisitCount"
FROM public."Visits" v
join public."Patients" p on v."PatientId" = p."PatientId"
join public."Humans" ph on p."HumanId" = ph."HumanId"
WHERE v."PatientId" = 1 -- parameter
AND EXTRACT(YEAR FROM v."VisitDate") = 2024 -- parameter
AND EXTRACT(MONTH FROM v."VisitDate") = 9; -- parameter
; 

