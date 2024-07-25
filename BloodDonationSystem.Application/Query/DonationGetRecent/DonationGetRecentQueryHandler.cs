using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Query.DonationGetRecent
{

    public class DonationGetRecentQueryHandler : IRequestHandler<DonationGetRecentQuery, List<DonationViewModel>>
    {

        private readonly BloodDonationDbContext _dbContext;

        public DonationGetRecentQueryHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DonationViewModel>> Handle(DonationGetRecentQuery request, CancellationToken cancellationToken)
        {
            var donations = await _dbContext.Donations
              .Where(a => a.DonationDate >= DateTime.Now.AddDays(-7))
              .Include(d => d.Donor)
              .ToListAsync(cancellationToken);

            var donationsViewModel = donations.Select(donation => new DonationViewModel(donation.DonationDate, donation.Quantity, donation.Donor.FullName, donation.Donor.Email, donation.Donor.BloodType, donation.Donor.RhFactor)).ToList();

            return donationsViewModel;
        }
    }
}
