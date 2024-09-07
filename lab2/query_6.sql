-- Who works in given room
SELECT 
	dh."FirstName",
	dh."LastName",
	dh."MiddleName"
FROM public."Schedule" sc
JOIN public."DoctorDistricts" dd ON sc."DoctorDistrictId" = dd."DoctorDistrictId"
join public."Doctors" d on dd."DoctorId" = d."DoctorId"
join public."Humans" dh on d."HumanId" = dh."HumanId"
WHERE sc."RoomNumber" = 102; -- parameter
