using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonationCreate
{
    public class DonationCreateCommandHandler : IRequestHandler<DonationCreateCommand, int>
    {
        private readonly IDonationRepository _donationRepo;

        public DonationCreateCommandHandler(IDonationRepository donationRepo)
        {
            _donationRepo = donationRepo;
        }

        public async Task<int> Handle(DonationCreateCommand request, CancellationToken cancellationToken)
        {
            var newDonation = new Donation(request.DonorId, request.Quantity, 0);

            return await _donationRepo.CreateDonation(newDonation);
        }

    }
}
