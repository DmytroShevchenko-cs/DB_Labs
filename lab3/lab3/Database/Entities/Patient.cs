namespace lab3.Database.Entities;

public class Patient
{
    public int PatientId { get; set; }
    public Human Human { get; set; }
    public int CardId { get; set; }
    public Card Card { get; set; }
    public string Address { get; set; } 
    public bool IsActive { get; set; }
    public ICollection<Visit> Visits { get; set; }
}