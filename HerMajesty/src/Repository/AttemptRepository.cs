using Microsoft.EntityFrameworkCore;

using HerMajesty.Context;
using HerMajesty.Entity;

namespace HerMajesty.Repository;

public class AttemptRepository : IAttemptRepository
{
    private readonly PostgresDbContext _context;

    public AttemptRepository(PostgresDbContext context)
        => _context = context;

    public async Task<AttemptEntity?> GetAttemptByNumberAsync(int attemptNumber)
        => await _context.Attempts
            .Include(c => c.Contenders)
            .FirstOrDefaultAsync(a => a.AttemptNumber == attemptNumber);
    
    public async Task<IEnumerable<AttemptEntity>?> GetAllAttemptsAsync()
        => await _context.Attempts
            .Include(c => c.Contenders)
            .ToListAsync();
}