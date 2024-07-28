using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Command.DonorPut
{
    public class DonorPutCommandHandler : IRequestHandler<DonorPutCommand, DonorViewModel>
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorPutCommandHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DonorViewModel> Handle(DonorPutCommand request, CancellationToken cancellationToken)
        {
            var donor = await _dbContext.Donors
                .Where(d => d.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (donor != null)
            {
                donor.UpdateDonorInfo(
                    request.FullName,
                    request.Email, 
                    request.DoB, 
                    request.Gender, 
                    request.Weight, 
                    request.BloodType, 
                    request.RhFactor);

                await _dbContext.SaveChangesAsync();

            var donorDetailVM = new DonorViewModel(
                donor.Id, 
                donor.FullName, 
                donor.Email, 
                donor.Gender, 
                donor.BloodType, 
                donor.RhFactor
                );
                
                return donorDetailVM;
            }

            return null;
        }
    }
}
