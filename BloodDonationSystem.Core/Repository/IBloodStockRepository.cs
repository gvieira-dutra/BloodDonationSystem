using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Entities;

namespace BloodDonationSystem.Core.Repository
{
    public interface IBloodStockRepository
    {
        Task<BloodStock> GetOneBloodType(int id);
        Task<List<BloodStockDTO>> GetAllBloodStock();

        Task SaveChangesOnDb();
    }
}
