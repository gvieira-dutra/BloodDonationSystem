using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Command.DonationDelete
{
    public class DonationDeleteCommandHandler : IRequestHandler<DonationDeleteCommand, Unit>
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonationDeleteCommandHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DonationDeleteCommand request, CancellationToken cancellationToken)
        {
            var donation = await _dbContext.Donations
                .Where(d => d.Id == request.Id)
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

                await _dbContext.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
