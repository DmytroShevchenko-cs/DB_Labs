namespace lab5.dataAccess.Database.Entities;

public class Visit
{
    public int VisitId { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; } = null!;
    public DateTime VisitDate { get; set; }
    public string Diagnosis { get; set; } = null!;
    public string Prescriptions { get; set; } = null!;
    public bool IsSickLeaveIssued { get; set; }
    public DateTime? SickLeaveDuration { get; set; }
}