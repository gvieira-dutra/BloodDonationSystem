using BloodDonationSystem.Application.ViewModels;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonationGetRecent
{
    public class DonationGetRecentQuery : IRequest<List<DonationViewModel>>
    {
    }
}
