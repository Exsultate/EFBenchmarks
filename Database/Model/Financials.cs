using Database.Model.Interface;

namespace Database.Model;

public class Financials : IEntity
{
    public Guid Id { get; set; }
    public Guid PlayerId { get; set; }
    public double Cash { get; set; }
    public PlayerBankInfo BankInfo { get; set; }
}