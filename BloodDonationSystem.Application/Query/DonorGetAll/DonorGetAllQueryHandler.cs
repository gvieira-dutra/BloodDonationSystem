using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Query.DonorGetAll
{
    public class DonorGetAllQueryHandler : IRequestHandler<DonorGetAllQuery, List<DonorViewModel>>
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorGetAllQueryHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DonorViewModel>> Handle(DonorGetAllQuery request, CancellationToken cancellationToken)
        {
            var donors = await _dbContext.Donors
            .Where(d => d.IsActive == true)
            .Select(donor => new DonorViewModel(donor.Id, donor.FullName, donor.Email, donor.Gender, donor.BloodType, donor.RhFactor))
            .ToListAsync(cancellationToken);

            return donors;
        }
    }
}
