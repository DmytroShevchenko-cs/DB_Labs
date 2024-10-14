namespace lab3.Database.Entities;

public class Polyclinic
{
    public int PolyclinicId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public ICollection<District> Districts { get; set; }
}