using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppRole).HasForeignKey(x => x.AppRoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
