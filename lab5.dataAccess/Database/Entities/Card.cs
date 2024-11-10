namespace lab5.dataAccess.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Card
{
    public int CardId { get; set; }
    public DateTime CardCreationDate { get; set; }
    public string PolicyNumber { get; set; } = null!;

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}