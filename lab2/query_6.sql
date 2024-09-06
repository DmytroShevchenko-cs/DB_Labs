-- Who works in current room
SELECT 
	dh."FirstName",
	dh."LastName",
	dh."MiddleName"
FROM public."DoctorDistricts" dd
join public."Doctors" d on dd."DoctorId" = d."DoctorId"
join public."Humans" dh on d."HumanId" = dh."HumanId"
WHERE dd."RoomNumber" = 102; -- parameter
