using Microsoft.EntityFrameworkCore;
using CarServiceCenter.Domain.Entities;

namespace CarServiceCenter.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<ServiceTypeItem> ServiceTypeItems { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingServiceItem> BookingServiceItems { get; set; }
    public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
}
