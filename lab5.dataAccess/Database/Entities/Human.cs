namespace lab5.dataAccess.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums;

public class Human
{
    public int HumanId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public Administrator Administrator { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}