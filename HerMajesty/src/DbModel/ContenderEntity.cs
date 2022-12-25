namespace HerMajestyDatabase.DbModel;

/// <summary>
/// A contender entity
/// </summary>
public class ContenderEntity
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public int Score { get; set; }
    
    public int Order { get; set; }
    
    public AttemptEntity AttemptEntity { get; set; }
}