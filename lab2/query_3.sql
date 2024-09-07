-- room number and work time
SELECT 
	sc."RoomNumber",
	sc."StartTime",
	sc."EndTime",
	sc."Day"
FROM public."Schedule" sc
JOIN public."DoctorDistricts" dd ON sc."DoctorDistrictId" = dd."DoctorDistrictId"
WHERE dd."DoctorId" = 1; -- parameter