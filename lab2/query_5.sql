-- doctors` prescriptions for the diagnosis
SELECT 
	v."Diagnosis",
	v."Prescriptions"
FROM public."Visits" v
WHERE v."Diagnosis" = 'Flu'; -- paremeter

