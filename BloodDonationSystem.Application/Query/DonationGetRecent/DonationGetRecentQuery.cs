using BloodDonationSystem.Core.DTO;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonationGetRecent
{
    public class DonationGetRecentQuery : IRequest<List<DonationDetailDTO>>
    {
    }
}
