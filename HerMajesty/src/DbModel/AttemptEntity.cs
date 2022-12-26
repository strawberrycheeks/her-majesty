namespace HerMajesty.DbModel;

/// <summary>
/// An attempt entity 
/// </summary>
public class AttemptEntity
{
    public int Id { get; set; }
    public string AttemptNumber { get; set; }
    public List<ContenderEntity> Contenders { get; set; }
}