using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonorCreate
{
    public class DonorCreateCommandHandler : IRequestHandler<DonorCreateCommand, int>
    {
        private readonly IDonorRepository _donorRepo;
        public DonorCreateCommandHandler(IDonorRepository donorRepo)
        {
            _donorRepo = donorRepo;
        }
        public async Task<int> Handle(DonorCreateCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address.Street, request.Address.City, request.Address.Province, request.Address.PostalCode, 0);
       
            
            var donor = new Donor(request.FullName, request.Email, request.DoB, request.Gender, request.Weight, request.BloodType, request.RhFactor, address.Id, 0);

            return await _donorRepo.DonorCreate(donor, address, cancellationToken);
        }
    }
}
