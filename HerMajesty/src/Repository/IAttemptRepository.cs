using HerMajesty.DbModel;

namespace HerMajesty.Repository;

public interface IAttemptRepository
{
    public Task<AttemptEntity?> GetAttemptByNumberAsync(string attemptNumber);

    public Task<IEnumerable<AttemptEntity>?> GetAllAttemptsAsync();
    
    // void AddBlog(AttemptEntity blog);
    //
    // void SaveChanges();
}