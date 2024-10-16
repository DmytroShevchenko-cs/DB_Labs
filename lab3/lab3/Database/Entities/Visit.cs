namespace lab3.Database.Entities;

using NodaTime;

public class Visit
{
    public int VisitId { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
    public DateTime VisitDate { get; set; }
    public string Diagnosis { get; set; }
    public string Prescriptions { get; set; }
    public bool IsSickLeaveIssued { get; set; }
    public DateTime? SickLeaveDuration { get; set; }
}