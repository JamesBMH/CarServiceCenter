using Microsoft.EntityFrameworkCore;
using CarServiceCenter.Domain;

namespace CarServiceCenter.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    
    public DbSet<Booking> Bookings { get; set; }
}
