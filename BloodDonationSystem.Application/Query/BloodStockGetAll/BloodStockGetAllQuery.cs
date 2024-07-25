using BloodDonationSystem.Application.ViewModels;
using MediatR;

namespace BloodDonationSystem.Application.Query.BloodStockGetAll
{
    public class BloodStockGetAllQuery : IRequest<List<BloodStockViewModel>>
    {

    }
}
