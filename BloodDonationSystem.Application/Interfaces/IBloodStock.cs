using BloodDonationSystem.Application.ViewModels;

namespace BloodDonationSystem.Application.Interfaces
{
    public interface IBloodStock
    {
        List<BloodStockViewModel> GetAll();

    }
}
