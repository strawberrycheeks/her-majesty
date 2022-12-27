using HerMajesty.Entity;

namespace HerMajesty.Repository;

public interface IAttemptRepository
{
    public Task<AttemptEntity?> GetAttemptByNumberAsync(int attemptNumber);

    public Task<IEnumerable<AttemptEntity>?> GetAllAttemptsAsync();
}