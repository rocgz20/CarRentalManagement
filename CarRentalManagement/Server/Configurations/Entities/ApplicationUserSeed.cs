using CarRentalManagement.Server.Models;
using CarRentalManagement.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalManagement.Server.Configurations.Entities
{
    public class ApplicationUserSeed : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            throw new NotImplementedException();
        }
    }
}
