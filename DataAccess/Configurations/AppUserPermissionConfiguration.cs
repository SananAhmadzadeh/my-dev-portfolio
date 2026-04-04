using Core.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AppUserPermissionConfiguration : IEntityTypeConfiguration<AppUserPermission>
    {
        public void Configure(EntityTypeBuilder<AppUserPermission> builder)
        {
            builder.HasKey(x => new { x.AppUserId, x.PermissionId });

            builder.Property(x => x.GrantedByUserId)
                .HasMaxLength(450);

            builder.HasOne(x => x.AppUser)
                .WithMany(u => u.AppUserPermissions)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Permission)
                .WithMany(p => p.AppUserPermissions)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
