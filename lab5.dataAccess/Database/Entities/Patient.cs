namespace lab5.dataAccess.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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