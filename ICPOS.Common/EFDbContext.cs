using ICPOS.EntityFramwork.Model;
using Microsoft.EntityFrameworkCore;

namespace ICPOS.Common
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Authorized> Authorized { get; set; }
    }
}
