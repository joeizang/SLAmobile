using Microsoft.EntityFrameworkCore;
using SLAMobileApi.DomainModels;

namespace SLAMobileApi.Data;

public class SlaMobileContext : DbContext
{
    public SlaMobileContext(DbContextOptions<SlaMobileContext> options) : base(options)
    {
        
    }
    
    public DbSet<Challenge> Challenges { get; set; } = null!;

    public DbSet<Stash> Stashes { get; set; } = null!;

    public DbSet<Savings> Savings { get; set; } = null!;
}