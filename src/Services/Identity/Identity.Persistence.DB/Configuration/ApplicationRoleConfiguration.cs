using Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Identity.Persistence.DB.Configuration
{
    public class ApplicationRoleConfiguration
    {
        public ApplicationRoleConfiguration(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            //Se crea un rol por defecto como relleno.
            entityBuilder.HasData(
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            entityBuilder.HasMany(e => e.UserRoles).WithOne(e => e.Role).HasForeignKey(e => e.RoleId).IsRequired();
        }
    }
}
