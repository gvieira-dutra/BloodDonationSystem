using BloodDonationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastructure.Persistence.Configurations
{
    public class DonationConfigurations : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
                .HasOne(a => a.Donor)
                .WithMany(d => d.Donations)
                .HasForeignKey(d => d.DonorId);
        }
    }
}
