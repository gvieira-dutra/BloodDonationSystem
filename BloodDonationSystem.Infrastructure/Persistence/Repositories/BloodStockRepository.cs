using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public BloodStockRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BloodStock> GetOneBloodType(int id)
        {
            return await _dbContext.BloodStocks
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

        }

        public async Task<List<BloodStockDTO>> GetAllBloodStock()
        {
            return await _dbContext.BloodStocks
                .Select(s => new BloodStockDTO(s.BloodType, s.RhFactor, s.Quantity)).ToListAsync();                
        }

        public async Task SaveChangesOnDb()
        {
            await _dbContext.SaveChangesAsync();

        }
    }
}
