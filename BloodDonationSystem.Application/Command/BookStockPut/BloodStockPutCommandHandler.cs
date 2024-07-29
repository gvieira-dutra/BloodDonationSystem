using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.Repository;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Command.BookStockPut
{
    public class BloodStockPutCommandHandler : IRequestHandler<BloodStockPutCommand, BloodStockViewModel>
    {
        private readonly IBloodStockRepository _bloodRepository;

        public BloodStockPutCommandHandler(BloodDonationDbContext dbContext, IBloodStockRepository bloodRepository)
        {
            _bloodRepository = bloodRepository;
        }

        public async Task<BloodStockViewModel> Handle(BloodStockPutCommand request, CancellationToken cancellationToken)
        {
            var stockToBeUpdated = await _bloodRepository.GetOneBloodType(request.Id);

            if (stockToBeUpdated != null)
            {
                stockToBeUpdated.UpdateStock(request.QuantityToAddOrRemove);

                await _bloodRepository.SaveChangesOnDb();

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
