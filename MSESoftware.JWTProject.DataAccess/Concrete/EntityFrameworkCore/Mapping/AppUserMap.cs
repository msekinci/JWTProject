using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.DataAccess.Concrete.EntityFramework.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique(); //UserName unique bir alan 
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(150);
            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Cascade); //User silinirse Role 'de silinsin
        }
    }
}
