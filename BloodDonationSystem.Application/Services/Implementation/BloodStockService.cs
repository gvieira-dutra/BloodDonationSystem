using BloodDonationSystem.Application.Interfaces;
using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Infrastructure.Persistence;

namespace BloodDonationSystem.Application.Services.Implementation
{
    public class BloodStockService : IBloodStock
    {
        private readonly BloodDonationDbContext _dbContext;

        public BloodStockService(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BloodStockViewModel> GetAll()
        {
            var stock = _dbContext.BloodStocks;

            var bloodStockViewModel = stock
                .Select(s => new BloodStockViewModel(s.BloodType, s.RhFactor, s.Quantity)).ToList();

            return bloodStockViewModel;
        }                
    }
}
