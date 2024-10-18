namespace lab3.Services.AppService;

using MediatR;
using Queries.GetDoctorByRoom;
using Queries.GetDoctorInfoById;
using Queries.GetDoctorsInitialsByPatientId;
using Queries.GetNumbersOfPatients;
using Queries.GetPatientsByDoctorId;
using Queries.GetPrescriptionsByDiagnosis;
using Queries.GetVisitByPatientId;
using Queries.GetVisitCountWithinMonthByPatientId;

public class App : IApp
{
    private readonly IMediator _mediator;

    public App(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Run()
    {
        var isWork = true;
        while (isWork)
        {
            Console.WriteLine("Chose the request");
            int.TryParse(Console.ReadLine(), out var choice);
            
            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var visit = await _mediator.Send(new GetVisitByPatientIdQuery());
                    
                    Console.WriteLine($"{visit.Address} | {visit.VisitDate} | {visit.Diagnosis}");
                    
                    
                    break;
                }
                case 2:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var doctors = await _mediator.Send(new GetDoctorsInitialsByPatientIdQuery());

                    foreach (var visit in doctors)
                    {
                        Console.WriteLine($"{visit.DoctorInfo}");
                    }
                    break;
                }
                case 3:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var doctorDays = await _mediator.Send(new GetDoctorDaysByIdQuery());
                    
                    foreach (var doctorDay in doctorDays)
                    {
                        Console.WriteLine($"{doctorDay.Day} | {doctorDay.StartTime} | {doctorDay.EndTime} | {doctorDay.RoomNumber}");
                    }
                    
                    break;
                }
                case 4:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var patients = await _mediator.Send(new GetPatientsByDoctorIdQuery());
                    
                    foreach (var doctorDay in patients)
                    {
                        Console.WriteLine($"{doctorDay.FirstName} | {doctorDay.LastName} | {doctorDay.VisitDate} | {doctorDay.SickLeaveDuration}");
                    }
                    
                    break;
                }
                case 5:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var prescriptions = await _mediator.Send(new GetPrescriptionsByDiagnosisQuery());
                    
                    foreach (var doctorDay in prescriptions)
                    {
                        Console.WriteLine($"{doctorDay.Diagnosis} | {doctorDay.Prescriptions}");
                    }
                    
                    break;
                }
                case 6:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var prescriptions = await _mediator.Send(new GetDoctorByRoomQuery());
                    
                    foreach (var doctorDay in prescriptions)
                    {
                        Console.WriteLine($"{doctorDay.LastName} | {doctorDay.FirstName} | {doctorDay.MiddleName}");
                    }
                    
                    break;
                }
                case 7:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var prescriptions = await _mediator.Send(new GetVisitCountWithinMonthByPatientIdQuery());
                    
                    Console.WriteLine($"{prescriptions}");
                    
                    break;
                }
                case 8:
                {
                    Console.WriteLine($"Your choice is {choice}");
                    
                    var prescriptions = await _mediator.Send(new GetNumbersOfPatientsQuery());
                    
                    foreach (var doctorDay in prescriptions)
                    {
                        Console.WriteLine($"{doctorDay.DoctorName} | {doctorDay.PolyclinicName} | {doctorDay.PatientCount}");
                    }
                    
                    break;
                }
                case 9:
                {
                    isWork = false;
                    break;
                }
            }

           
        }
    }
}