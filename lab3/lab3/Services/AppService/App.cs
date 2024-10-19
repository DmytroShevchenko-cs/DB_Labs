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
            Console.WriteLine("\nChose the request");
            Console.WriteLine("1 - Адреса даного хворого, дата останнього відвідування поліклініки та діагноз");
            Console.WriteLine("2 - Прізвище та ініціали лікаря даного хворого");
            Console.WriteLine("3 - Номер кабінету, дні та години прийому даного лікаря");
            Console.WriteLine("4 - Хворі, що знаходяться в даний момент на лікуванні у даного лікаря");
            Console.WriteLine("5 - Призначення лікарів при вказаному захворюванні");
            Console.WriteLine("6 - Хто працює зараз у вказаному кабінеті");
            Console.WriteLine("7 - Скільки разів за місяць звертався до поліклініки вказаний хворий");
            Console.WriteLine("8 - Яку кількість хворих обслужив за місяць кожен із лікарів поліклініки");
            Console.WriteLine("9 - Exit");
            
            int.TryParse(Console.ReadLine(), out var choice);
            
            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write("PatientId id > ");
                    int.TryParse(Console.ReadLine(), out var patientId);
                    
                    var visit = await _mediator.Send(new GetVisitByPatientIdQuery
                    {
                        PatientId = patientId
                    });
                    
                    Console.WriteLine($"{visit.Address} | {visit.VisitDate} | {visit.Diagnosis}");
                    
                    break;
                }
                case 2:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write("Patient id > ");
                    int.TryParse(Console.ReadLine(), out var patientId);
                    
                    var doctors = await _mediator.Send(new GetDoctorsInitialsByPatientIdQuery
                    {
                        PatientId = patientId
                    });

                    foreach (var visit in doctors)
                    {
                        Console.WriteLine($"{visit.DoctorInfo}");
                    }
                    
                    break;
                }
                case 3:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write("Doctor id > ");
                    int.TryParse(Console.ReadLine(), out var doctorId);
                    
                    var doctorDays = await _mediator.Send(new GetDoctorDaysByIdQuery
                    {
                        DoctorId = doctorId
                    });
                    
                    foreach (var doctorDay in doctorDays)
                    {
                        Console.WriteLine($"{doctorDay.Day} | {doctorDay.StartTime} | {doctorDay.EndTime} | {doctorDay.RoomNumber}");
                    }
                    
                    break;
                }
                case 4:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write("Doctor id > ");
                    int.TryParse(Console.ReadLine(), out var doctorId);
                    
                    var patients = await _mediator.Send(new GetPatientsByDoctorIdQuery
                    {
                        DoctorId = doctorId
                    });
                    
                    foreach (var doctorDay in patients)
                    {
                        Console.WriteLine($"{doctorDay.FirstName} | {doctorDay.LastName} | {doctorDay.VisitDate} | {doctorDay.SickLeaveDuration}");
                    }
                    
                    break;
                }
                case 5:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write("Diagnosis > ");
                    var diagnosis = Console.ReadLine();
                    var prescriptions = await _mediator.Send(new GetPrescriptionsByDiagnosisQuery
                    {
                        Diagnosis = diagnosis!
                    });
                    
                    foreach (var doctorDay in prescriptions)
                    {
                        Console.WriteLine($"{doctorDay.Diagnosis} | {doctorDay.Prescriptions}");
                    }
                    
                    break;
                }
                case 6:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write("Room number > ");
                    int.TryParse(Console.ReadLine(), out var roomNumber);
                    
                    var prescriptions = await _mediator.Send(new GetDoctorByRoomQuery
                    {
                        RoomNumber = roomNumber
                    });
                    
                    foreach (var doctorDay in prescriptions)
                    {
                        Console.WriteLine($"{doctorDay.LastName} | {doctorDay.FirstName} | {doctorDay.MiddleName}");
                    }
                    
                    break;
                }
                case 7:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write("Patient id > ");
                    int.TryParse(Console.ReadLine(), out var patientId);
                    Console.Write("Month > ");
                    int.TryParse(Console.ReadLine(), out var month);
                    Console.Write("Year > ");
                    int.TryParse(Console.ReadLine(), out var year);
                    
                    var prescriptions = await _mediator.Send(new GetVisitCountWithinMonthByPatientIdQuery
                    {
                        PatientId = patientId,
                        Month = month,
                        Year = year
                    });
                    
                    Console.WriteLine($"{prescriptions}");
                    
                    break;
                }
                case 8:
                {
                    Console.WriteLine($"\nYour choice is {choice}");
                    
                    Console.Write($"Polyclinic id > ");
                    int.TryParse(Console.ReadLine(), out var polyclinicId);
                    
                    var prescriptions = await _mediator.Send(new GetNumbersOfPatientsQuery
                    {
                        PolyclinicId = polyclinicId
                    });
                    
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