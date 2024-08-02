using BloodDonationSystem.Core.Repository;
using BloodDonationSystem.Infrastructure.PostalCodeService.Service;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationSystem.Application.Command.DonorCreate
{
    public class DonorCreateCommandHandler : IRequestHandler<DonorCreateCommand, int>
    {
        private readonly IDonorRepository _donorRepo;
        private readonly IPostalCodeService _postalCodeService;
        public DonorCreateCommandHandler(IDonorRepository donorRepo, IPostalCodeService postalCodeService)
        {
            _donorRepo = donorRepo;
            _postalCodeService = postalCodeService;
        }
        public async Task<int> Handle(DonorCreateCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address.Street, request.Address.City, request.Address.Province, request.Address.PostalCode, 0);

            var isPostalCodeValid = await _postalCodeService.CheckPostalCodeAPI(request.Address.PostalCode);
            if (!isPostalCodeValid)
            {
                throw new ValidationException("Postal Code does not match Canada Postal Code Database.");
            }

            var donor = new Donor(request.FullName, request.Email, request.DoB, request.Gender, request.Weight, request.BloodType, request.RhFactor, address.Id, 0);

            return await _donorRepo.DonorCreate(donor, address, cancellationToken);
        }
    }
}
