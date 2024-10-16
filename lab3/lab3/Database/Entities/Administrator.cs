namespace lab3.Database.Entities;

using Enum;

public class Administrator
{
    public int AdministratorId { get; set; }
    public Human Human { get; set; }
    public Role Role { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}