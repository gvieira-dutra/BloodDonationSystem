using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonationRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DonationDetailDTO>> DonationGetRecent()
        {
            var donations = await _dbContext.Donations
              .Where(a => a.DonationDate >= DateTime.Now.AddDays(-30) && a.IsActive == true)
              .Include(d => d.Donor)
              .ToListAsync();

            var donationsViewModel = donations.Select(donation => new DonationDetailDTO(
                donation.Id,
                donation.DonationDate,
                donation.Quantity,
                donation.Donor.FullName,
                donation.Donor.Email,
                donation.Donor.BloodType,
                donation.Donor.RhFactor))
                .ToList();

            return donationsViewModel;
        }

        public async Task<int> CreateDonation(Donation aDonation)
        {
            if (aDonation != null)
            {
                var donor = await _dbContext.Donors.FirstOrDefaultAsync(a => a.Id == aDonation.DonorId);

                var donations = _dbContext.Donations;

                var bloodStock = await _dbContext.BloodStocks.FirstOrDefaultAsync(a => a.RhFactor == donor.RhFactor && a.BloodType == donor.BloodType);
                var donation = new Donation(aDonation.DonorId, aDonation.Quantity, 0);
                donor.Donations.Add(donation);

                donations.Add(donation);

                bloodStock.UpdateStock(aDonation.Quantity);

                var donationViewModel = new DonationDetailDTO(
                    donation.Id,
                    DateTime.Now,
                    donation.Quantity,
                    donor.FullName,
                    donor.Email,
                    donor.BloodType,
                    donor.RhFactor
                    );

                await SaveDbChanges();

                return donor.Id;
            }
                return 0;
        }

        public async Task DeleteDonation(int donationId, CancellationToken cancellationToken)
        {
            var donation = await _dbContext.Donations
            .Where(d => d.Id == donationId)
                .FirstOrDefaultAsync(cancellationToken);

            var donor = await _dbContext.Donors
                .Where(d => d.Id == donation.DonorId)
                .FirstOrDefaultAsync(cancellationToken);

            var typeToUpdate = await _dbContext.BloodStocks
                .Where(s => s.BloodType == donor.BloodType && s.RhFactor == donor.RhFactor)
                .FirstOrDefaultAsync(cancellationToken);

            if (donation != null)
            {
                donation.DeleteDonation();

                typeToUpdate.UpdateStock(- donation.Quantity);

                await SaveDbChanges();
            }
        }

        public async Task<DonationDetailDTO> DonationUpdate(int donationId, int newQty, CancellationToken cancellationToken)
        {

            var donation = await _dbContext.Donations
                .Where(a => a.Id == donationId)
                .FirstOrDefaultAsync(cancellationToken);

            if (donation != null)
            {
                var donor = await _dbContext.Donors
                    .Where(a => a.Id == donation.DonorId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (donor != null)
                {
                    var oldQty = donation.Quantity;

                    donation.UpdateQty(newQty);

                    var typeToUpdate = await _dbContext.BloodStocks
                        .Where(a => a.BloodType == donor.BloodType && a.RhFactor == donor.RhFactor)
                        .FirstOrDefaultAsync(cancellationToken);

                    var netChange = newQty - oldQty;
                    typeToUpdate.UpdateStock(netChange);

                    await SaveDbChanges();

                    var donationVM = new DonationDetailDTO(
                        donation.Id,
                        donation.DonationDate,
                        donation.Quantity,
                        donor.FullName,
                        donor.Email,
                        donor.BloodType,
                        donor.RhFactor);

                    
                }
            }
                return null;
        }


        public async Task SaveDbChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
