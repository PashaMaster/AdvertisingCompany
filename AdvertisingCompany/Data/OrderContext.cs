using Microsoft.EntityFrameworkCore;

namespace AdvertisingCompany.Models
{
    public class OrderContext : DbContext
    {
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ResponsibleOfficer> ResponsibleOfficers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AdditionalServise> AdditionalServises { get; set; }
        public DbSet<TypeAdvertising> TypeAdvertisings { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) 
            : base(options)
        {
        }
    }
}
