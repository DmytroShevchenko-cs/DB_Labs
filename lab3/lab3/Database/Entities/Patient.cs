namespace lab3.Database.Entities;

public class Patient
{
    public int PatientId { get; set; }
    public Human Human { get; set; } = null!;
    public int CardId { get; set; }
    public Card Card { get; set; } = null!;
    public string Address { get; set; }  = null!;
    public bool IsActive { get; set; }
    public ICollection<Visit> Visits { get; set; } = null!;
}