using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;

namespace BloodDonationSystem.Application.Command.BookStockPut
{
    public class BloodStockPutCommandHandler : IRequestHandler<BloodStockPutCommand, BloodStockDTO>
    {
        private readonly IBloodStockRepository _bloodRepository;

        public BloodStockPutCommandHandler(BloodDonationDbContext dbContext, IBloodStockRepository bloodRepository)
        {
            _bloodRepository = bloodRepository;
        }

        public async Task<BloodStockDTO> Handle(BloodStockPutCommand request, CancellationToken cancellationToken)
        {
            var stockToBeUpdated = await _bloodRepository.GetOneBloodType(request.Id);

            if (stockToBeUpdated != null)
            {
                stockToBeUpdated.UpdateStock(request.QuantityToAddOrRemove);

                await _bloodRepository.SaveChangesOnDb();

                var updatedStockVM = new BloodStockDTO(
                    stockToBeUpdated.BloodType,
                    stockToBeUpdated.RhFactor,
                    stockToBeUpdated.Quantity);

                return updatedStockVM;
            }

            return null;
        }
    }
}
