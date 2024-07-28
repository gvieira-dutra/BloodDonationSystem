using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Query.DonorGetOne
{
    public class DonorGetOneQueryHandler : IRequestHandler<DonorGetOneQuery, DonorDetailViewModel>
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorGetOneQueryHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DonorDetailViewModel> Handle(DonorGetOneQuery request, CancellationToken cancellationToken)
        {
            var donations = await _dbContext.Donations
                .Where(d => d.DonorId == request.Id)
                .Select(d => new DonationViewModel(d.Id, d.DonationDate, d.Quantity))
                .ToListAsync(cancellationToken);

            var donor = await _dbContext.Donors
                .Include(a => a.Address)
                .FirstOrDefaultAsync(a => a.Id == request.Id);

            var donorVM = new DonorDetailViewModel(
                donor.FullName, 
                donor.Email, 
                donor.DoB, 
                donor.Gender, 
                donor.Weight, 
                donor.BloodType, 
                donor.RhFactor, 
                donor.Address);

            donorVM.SetDonations(donations);
            donorVM.SetStatus();

            return donorVM;
        }
    }
}
