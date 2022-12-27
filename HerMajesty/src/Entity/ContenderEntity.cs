namespace HerMajesty.Entity;

/// <summary>
/// An entity for contender to be stored in a database
/// </summary>
public class ContenderEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Score { get; set; }
    
    public int Order { get; set; }
    
    public AttemptEntity AttemptEntity { get; set; }
}