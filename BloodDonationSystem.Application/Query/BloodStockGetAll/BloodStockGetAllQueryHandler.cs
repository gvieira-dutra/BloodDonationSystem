using BloodDonationSystem.Infrastructure.Persistence;
using BloodDonationSystem.Core.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BloodDonationSystem.Core.Repository;

namespace BloodDonationSystem.Application.Query.BloodStockGetAll
{
    public class BloodStockGetAllQueryHandler : IRequestHandler<BloodStockGetAllQuery, List<BloodStockDTO>>
    {

        private readonly IBloodStockRepository _bloodStockRepo;

        public BloodStockGetAllQueryHandler(IBloodStockRepository bloodStockRepo)
        {
            _bloodStockRepo = bloodStockRepo;
        }

        public async Task<List<BloodStockDTO>> Handle(BloodStockGetAllQuery request, CancellationToken cancellationToken)
        {          
                var stock = await _bloodStockRepo.GetAllBloodStock();

                return stock;            
        }
    }
}
