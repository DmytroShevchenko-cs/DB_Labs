namespace lab3.Database.Entities;

public class Card
{
    public int CardId { get; set; }
    public DateTime CardCreationDate { get; set; }
    public string PolicyNumber { get; set; }

    public Patient Patient { get; set; }
}