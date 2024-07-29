using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonationDelete
{
    public class DonationDeleteCommandHandler : IRequestHandler<DonationDeleteCommand, Unit>
    {
        private readonly IDonationRepository _donationRepo;

        public DonationDeleteCommandHandler(IDonationRepository donationRepo)
        {
            _donationRepo = donationRepo;
        }
        public async Task<Unit> Handle(DonationDeleteCommand request, CancellationToken cancellationToken)
        {
            await _donationRepo.DeleteDonation(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
