namespace HerMajestyDatabase.DbModel;

public class AttemptEntity
{
    public int Id { get; set; }
    public List<ContenderEntity> Contenders { get; set; }
}