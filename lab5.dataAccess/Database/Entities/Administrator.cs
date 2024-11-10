namespace lab5.dataAccess.Database.Entities;

using Enums;

public class Administrator
{
    public int AdministratorId { get; set; }
    public Human Human { get; set; } = null!;
    public Role Role { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}