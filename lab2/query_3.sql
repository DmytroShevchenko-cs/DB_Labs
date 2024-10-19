-- room number and work time
SELECT 
	sc."RoomNumber",
	sc."StartTime",
	sc."EndTime",
	sc."Day"
FROM public."Schedule" sc
WHERE sc."DoctorId" = 1; -- parameter