using HerMajesty.Context;
using HerMajesty.DbModel;
using HerMajesty.Model;

namespace HerMajestyDatabase;

public static class AttemptGenerator
{
    /// <summary>
    /// Generates <paramref name="attemptCount"/> of attempts and saves it in the database
    /// </summary>
    /// <param name="dbc"> Context for database where attempts is saved </param>
    /// <param name="attemptCount"> Number of generated attempts </param>
    public static async Task GenerateAsync(PostgresDbContext dbc, int attemptCount)
    {
        IContenderListGenerator contenderListGenerator = new ContenderListGenerator();
        
        for (var i = 1; i <= attemptCount; i++)
        {
            var contenders = contenderListGenerator.GenerateContenderList();
            dbc.Attempts.Add(new AttemptEntity
            {
                AttemptNumber = i.ToString(),
                Contenders = MapToDbEntities(contenders)
            });
        }
        await dbc.SaveChangesAsync();
    }
    
    /// <summary>
    /// Maps a collection of app entities to the collection of database entities
    /// </summary>
    /// <param name="contenders"> A collection to be mapped </param>
    /// <returns> Returns a mapped collection of database entities </returns>
    private static List<ContenderEntity> MapToDbEntities(IEnumerable<Contender> contenders)
    {
        var order = 0;
        return contenders.Select(c => new ContenderEntity()
        {
            Name = c.Name,
            Score = c.Score,
            Order = order++
        }).ToList();
    }
}