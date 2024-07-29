using BloodDonationSystem.Core.DTO;
using MediatR;

namespace BloodDonationSystem.Application.Query.BloodStockGetAll
{
    public class BloodStockGetAllQuery : IRequest<List<BloodStockDTO>>
    {

    }
}
