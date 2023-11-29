using CarRentalManagement.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalManagement.Server.Configurations.Entities
{
    public class IdentityUserRoleSeed : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            throw new NotImplementedException();
        }
    }
}
