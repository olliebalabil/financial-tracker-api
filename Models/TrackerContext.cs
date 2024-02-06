using Microsoft.EntityFrameworkCore;

namespace TrackerApi.Models;

public class TrackerContext : DbContext
{
    public TrackerContext(DbContextOptions<TrackerContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Account { get; set; }
    public DbSet<Transaction> Transactions {get;set;}
}