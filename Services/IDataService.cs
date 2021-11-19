using Microsoft.EntityFrameworkCore;
using SLAMobileApi.DomainModels;

namespace SLAMobileApi.Services;

public interface IDataService<T> where T : SlaBaseMoneyType
{
    DbSet<T> EntitySet { get; }
    Task Commit(CancellationToken token);
}