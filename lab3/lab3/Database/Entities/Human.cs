namespace lab3.Database.Entities;

using Enum;

public class Human
{
    public int HumanId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public Administrator Administrator { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
}