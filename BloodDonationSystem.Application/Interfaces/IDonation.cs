using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.Entities;

namespace BloodDonationSystem.Application.Interfaces
{
    public interface IDonation
    {
        DonationViewModel CreateOne(DonationInputModel newDonation);
        List<DonationViewModel> GetRecent();
    }
}
