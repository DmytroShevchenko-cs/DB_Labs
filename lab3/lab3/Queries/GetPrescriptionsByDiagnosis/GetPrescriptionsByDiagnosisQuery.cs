namespace lab3.Queries.GetPrescriptionsByDiagnosis;

using MediatR;

public class GetPrescriptionsByDiagnosisQuery : IRequest<List<GetPrescriptionsByDiagnosisQueryResponse>>
{
    public string Diagnosis { get; set; }
}