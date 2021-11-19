using Microsoft.EntityFrameworkCore;
using SLAMobileApi.Data;
using SLAMobileApi.DomainModels;

namespace SLAMobileApi.Services;

public class GenericDataService<T> : IDataService<T> where T : SlaBaseMoneyType
{
    private readonly SlaMobileContext _context;

    public GenericDataService(SlaMobileContext context)
    {
        _context = context;
        EntitySet = _context.Set<T>();
    }
    public DbSet<T> EntitySet { get; private set; }
    
    public async Task Commit(CancellationToken token)
    {
        await _context.SaveChangesAsync(token).ConfigureAwait(false);
    }
}