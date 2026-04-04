using Core.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(x => x.Code)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.HasIndex(x => x.Code)
                    .IsUnique();

            builder.HasData(
                  // System-level / Admin permissions
                  new Permission { Id = 1, Code = "PERMISSION.VIEW", Description = "View all permissions" },
                  new Permission { Id = 2, Code = "PERMISSION.ASSIGN", Description = "Assign permissions to users" },
                  new Permission { Id = 3, Code = "ROLE.MANAGE", Description = "Create, update, delete roles" },
                  new Permission { Id = 4, Code = "USER.MANAGE", Description = "Create, update, delete users" },
                  new Permission { Id = 5, Code = "DASHBOARD.ACCESS", Description = "Access admin dashboard" },
                  new Permission { Id = 6, Code = "REPORTS.VIEW", Description = "View system reports" },

                  new Permission { Id = 7, Code = "BLOG.CREATE", Description = "Create blog" },
                  new Permission { Id = 8, Code = "BLOG.UPDATE", Description = "Update blog" },
                  new Permission { Id = 9, Code = "BLOG.DELETE", Description = "Delete blog" },

                  new Permission { Id = 10, Code = "SKILL.CREATE", Description = "Create skill" },
                  new Permission { Id = 11, Code = "SKILL.UPDATE", Description = "Update skill" },
                  new Permission { Id = 12, Code = "SKILL.DELETE", Description = "Delete skill" },

                  new Permission { Id = 13, Code = "VIDEO.READ", Description = "Read video" },
                  new Permission { Id = 14, Code = "VIDEO.CREATE", Description = "Create video" },
                  new Permission { Id = 15, Code = "VIDEO.UPDATE", Description = "Update video" },
                  new Permission { Id = 16, Code = "VIDEO.DELETE", Description = "Delete video" }
  );

        }
    }
}
