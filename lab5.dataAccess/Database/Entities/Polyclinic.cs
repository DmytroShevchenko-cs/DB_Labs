namespace lab5.dataAccess.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Polyclinic
{
    public int PolyclinicId { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;

    public ICollection<District> Districts { get; set; } = null!;
}