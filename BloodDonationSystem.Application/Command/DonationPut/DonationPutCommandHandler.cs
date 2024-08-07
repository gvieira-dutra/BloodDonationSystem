using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonationPut
{
    public class DonationPutCommandHandler : IRequestHandler<DonationPutCommand, DonationDetailDTO>
    {
        private readonly IDonationRepository _donationRepo;

        public DonationPutCommandHandler(IDonationRepository donationRepo)
        {
            _donationRepo = donationRepo;
        }

        public async Task<DonationDetailDTO> Handle(DonationPutCommand request, CancellationToken cancellationToken)
        {

            return await _donationRepo.DonationUpdate(request.Id, request.NewQuantity, cancellationToken);
        }
        
    }
    
}
