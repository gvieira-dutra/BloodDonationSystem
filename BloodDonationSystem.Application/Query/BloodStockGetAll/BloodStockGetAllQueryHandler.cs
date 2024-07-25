using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Query.BloodStockGetAll
{
    public class BloodStockGetAllQueryHandler : IRequestHandler<BloodStockGetAllQuery, List<BloodStockViewModel>>
    {

        private readonly BloodDonationDbContext _dbContext;

        public BloodStockGetAllQueryHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BloodStockViewModel>> Handle(BloodStockGetAllQuery request, CancellationToken cancellationToken)
        {          
                var stock = _dbContext.BloodStocks;

                var bloodStockViewModel = await stock
                    .Select(s => new BloodStockViewModel(s.BloodType, s.RhFactor, s.Quantity)).ToListAsync();

                return bloodStockViewModel;
            
        }
    }
}
