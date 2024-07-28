using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Command.DonorDelete
{
    public class DonorDeleteCommandHandler : IRequestHandler<DonorDeleteCommand, Unit>
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorDeleteCommandHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DonorDeleteCommand request, CancellationToken cancellationToken)
        {
            var donor = await _dbContext.Donors
                .Where(d => d.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if(donor != null)
            {
                donor.SetDonorInactive();

                await _dbContext.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
