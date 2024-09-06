-- romm number and work time
SELECT 
	dd."RoomNumber",
	dd."StartTime",
	dd."EndTime"
FROM public."DoctorDistricts" dd
JOIN public."Doctors" d ON dd."DoctorId" = d."DoctorId"
WHERE dd."DoctorId" = 1; -- parameter
