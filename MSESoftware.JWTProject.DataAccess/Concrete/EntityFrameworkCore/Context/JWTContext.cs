using Microsoft.EntityFrameworkCore;
using MSESoftware.JWTProject.DataAccess.Concrete.EntityFramework.Mapping;
using MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class JWTContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Serkan-Ekinci;Database=JWTProjectTutorial;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
 