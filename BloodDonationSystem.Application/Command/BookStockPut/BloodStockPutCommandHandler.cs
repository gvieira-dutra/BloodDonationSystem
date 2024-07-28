using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Command.BookStockPut
{
    public class BloodStockPutCommandHandler : IRequestHandler<BloodStockPutCommand, BloodStockViewModel>
    {
        private readonly BloodDonationDbContext _dbContext;

        public BloodStockPutCommandHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BloodStockViewModel> Handle(BloodStockPutCommand request, CancellationToken cancellationToken)
        {
            var stockToBeUpdated = await _dbContext.BloodStocks.
                Where(a => a.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (stockToBeUpdated != null)
            {
                stockToBeUpdated.UpdateStock(request.QuantityToAddOrRemove);

                await _dbContext.SaveChangesAsync(cancellationToken);

                var updatedStockVM = new BloodStockViewModel(
                    stockToBeUpdated.BloodType,
                    stockToBeUpdated.RhFactor,
                    stockToBeUpdated.Quantity);

                return updatedStockVM;
            }

            return null;
        }
    }
}
