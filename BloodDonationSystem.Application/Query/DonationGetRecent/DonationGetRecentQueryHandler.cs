using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonationGetRecent
{

    public class DonationGetRecentQueryHandler : IRequestHandler<DonationGetRecentQuery, List<DonationDetailDTO>>
    {

        private readonly IDonationRepository _donationRepo;

        public DonationGetRecentQueryHandler(IDonationRepository donationRepo)
        {
            _donationRepo = donationRepo;
        }

        public async Task<List<DonationDetailDTO>> Handle(DonationGetRecentQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepo.DonationGetRecent();

            return donations;
        }
    }
}
