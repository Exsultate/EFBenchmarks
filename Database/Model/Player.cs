using Database.Model.Interface;

namespace Database.Model;

public class Player : IEntity
{
    public Guid Id { get; set; }
}
