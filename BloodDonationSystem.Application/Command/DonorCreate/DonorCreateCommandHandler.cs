using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonorCreate
{
    public class DonorCreateCommandHandler : IRequestHandler<DonorCreateCommand, int>
    {
        private readonly BloodDonationDbContext _dbContext;
        public DonorCreateCommandHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(DonorCreateCommand request, CancellationToken cancellationToken)
        {            
            var address = new Address(request.Address.Street, request.Address.City, request.Address.Province, request.Address.PostalCode, 0);
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();

            var donor = new Donor(request.FullName, request.Email, request.DoB, request.Gender, request.Weight, request.BloodType, request.RhFactor, address.Id, 0);
            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();

            return donor.Id;
        }
    }
}
