namespace HerMajesty.Entity;

/// <summary>
/// An entity for attempt to be stored in a database
/// </summary>
public class AttemptEntity
{
    public int Id { get; set; }
    public int AttemptNumber { get; set; }
    public List<ContenderEntity> Contenders { get; set; }
}