-- Who works in given room
SELECT DISTINCT
	dh."FirstName",
	dh."LastName",
	dh."MiddleName"
FROM public."Schedule" sc
join public."Humans" dh on sc."DoctorId" = dh."HumanId"
WHERE sc."RoomNumber" = 102; -- parameter
