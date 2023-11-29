using CarRentalManagement.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalManagement.Server.Configurations.Entities
{
    public class IdentityRoleSeed : IEntityTypeConfiguration<IdentityRoleSeed>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleSeed> builder)
        {
            throw new NotImplementedException();
        }
    }
}
