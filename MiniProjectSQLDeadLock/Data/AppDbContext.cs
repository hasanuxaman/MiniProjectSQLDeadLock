using Microsoft.EntityFrameworkCore;
using MiniProjectSQLDeadLock.Models;


namespace MiniProjectSQLDeadLock.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<PurchaseRequest> Requests { get; set; }
        public DbSet<ErrorViewModel> ErrorViewModel { get; set; }
    }
}
