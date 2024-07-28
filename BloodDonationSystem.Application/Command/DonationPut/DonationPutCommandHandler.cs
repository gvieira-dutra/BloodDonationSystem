using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Command.DonationPut
{
    public class DonationPutCommandHandler : IRequestHandler<DonationPutCommand, DonationDetailViewModel>
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonationPutCommandHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DonationDetailViewModel> Handle(DonationPutCommand request, CancellationToken cancellationToken)
        {
            var donation = await _dbContext.Donations
                .Where(a => a.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (donation != null)
            {
                var donor = await _dbContext.Donors
                    .Where(a => a.Id == donation.DonorId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (donor != null)
                {
                    var oldQty = donation.Quantity;

                    donation.UpdateQty(request.NewQuantity);

                    var typeToUpdate = await _dbContext.BloodStocks
                        .Where(a => a.BloodType == donor.BloodType && a.RhFactor == donor.RhFactor)
                        .FirstOrDefaultAsync(cancellationToken);

                    var netChange = request.NewQuantity - oldQty;
                    typeToUpdate.UpdateStock(netChange);

                    _dbContext.SaveChanges();

                    var donationVM = new DonationDetailViewModel(
                        donation.Id,
                        donation.DonationDate, 
                        donation.Quantity, 
                        donor.FullName, 
                        donor.Email, 
                        donor.BloodType, 
                        donor.RhFactor);

                    return donationVM;
                }
            }
            return null;
        }
    }
}
