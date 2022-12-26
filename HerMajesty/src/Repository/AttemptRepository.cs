using Microsoft.EntityFrameworkCore;

using HerMajesty.Context;
using HerMajesty.Entity;

namespace HerMajesty.Repository;

public class AttemptRepository : IAttemptRepository
{
    private readonly PostgresDbContext _dbc;

    public AttemptRepository(PostgresDbContext dbc)
        => _dbc = dbc;

    public async Task<AttemptEntity?> GetAttemptByNumberAsync(string attemptNumber)
        => await _dbc.Attempts
            .Include(c => c.Contenders)
            .FirstOrDefaultAsync(a => a.AttemptNumber == attemptNumber);
    
    public async Task<IEnumerable<AttemptEntity>?> GetAllAttemptsAsync()
        => await _dbc.Attempts
            .Include(c => c.Contenders)
            .ToListAsync();
}