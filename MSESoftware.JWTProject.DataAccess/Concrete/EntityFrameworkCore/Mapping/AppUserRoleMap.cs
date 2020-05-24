using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //appUserId appRoleId
            //    1         1
            //    1         1
            //Bunun olabilme ihtimali muhtemel ve bizim bunun önüne geçmemiz gerekiyor. Bu yüzden iki column'u da Unique olarak tanımlamamız gerekiyor.
            builder.HasIndex(x => new { x.AppRoleId, x.AppUserId }).IsUnique();
        }
    }
}
