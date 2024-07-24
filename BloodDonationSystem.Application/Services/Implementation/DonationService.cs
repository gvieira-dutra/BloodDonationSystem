using BloodDonationSystem.Application.Interfaces;
using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Services.Implementation
{
    public class DonationService(BloodDonationDbContext dbContext) : IDonation
    {
        private readonly BloodDonationDbContext _dbContext = dbContext;

        public DonationViewModel CreateOne(DonationInputModel newDonation)
        {
            var donor = _dbContext.Donors.FirstOrDefault(a => a.Id == newDonation.DonorId);

            var donations = _dbContext.Donations;
            
            var bloodStock = _dbContext.BloodStocks.FirstOrDefault(a => a.RhFactor == donor.RhFactor && a.BloodType == donor.BloodType);

            var donation = new Donation(newDonation.DonorId, newDonation.Quantity);

            donor.Donations.Add(donation);

            donations.Add(donation);

            bloodStock.updateQuantity(newDonation.Quantity);

            var donationViewModel = new DonationViewModel(newDonation.DonorId, newDonation.Quantity);

            _dbContext.SaveChanges();

            return donationViewModel;
        }

        public List<DonationViewModel> GetRecent()
        {
            
            var donations = _dbContext.Donations
                .Where(a => a.DonationDate >= DateTime.Now.AddDays(-7))
                .Include(a => a.Donor);

            var donationsViewModel = donations.Select(donation => new DonationViewModel(donation.Id, donation.Quantity)).ToList();

            return donationsViewModel;
        }
    }
}
