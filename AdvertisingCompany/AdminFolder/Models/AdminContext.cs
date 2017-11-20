using Microsoft.EntityFrameworkCore;

namespace AdvertisingCompany.AdminFolder.Models
{
    public class AdminContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }
    }
}
