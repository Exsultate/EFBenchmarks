using Database.Model.Interface;

namespace Database.Model;

public class Player : IEntity
{
    public Guid Id { get; set; }
    public string Name => $"{First_Name} {Last_Name}";
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public int Age { get; set; }
    public List<Player> Friends { get; set; }
    public Financials Financials { get; set; }
}
