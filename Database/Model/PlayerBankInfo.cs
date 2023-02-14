using Database.Model.Interface;

namespace Database.Model;

public class PlayerBankInfo : IEntity
{
    public Guid Id { get; set; }
    public Guid FinancialsId { get; set; }
    public string Password { get; set; }
    public double Money { get; set; }
}
