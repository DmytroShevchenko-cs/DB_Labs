namespace lab3.Queries.GetPrescriptionsByDiagnosis;

using Database;
using GetPatientsByDoctorId;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetPrescriptionsByDiagnosisQueryHandler : IRequestHandler<GetPrescriptionsByDiagnosisQuery, List<GetPrescriptionsByDiagnosisQueryResponse>>
{
    private readonly HospitalDbContext _dbContext;

    public GetPrescriptionsByDiagnosisQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetPrescriptionsByDiagnosisQueryResponse>> Handle(GetPrescriptionsByDiagnosisQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var prescriptions = await _dbContext.Visits
                .Where(v => v.Diagnosis.ToLower().Contains("flu"))
                .Select(r => new GetPrescriptionsByDiagnosisQueryResponse
                {
                    Diagnosis = r.Diagnosis,
                    Prescriptions = r.Prescriptions
                })
                .ToListAsync(cancellationToken);

            return prescriptions;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}