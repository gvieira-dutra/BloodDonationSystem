
using BloodDonationSystem.Application.ViewModels;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonorGetAll
{
    public class DonorGetAllQuery : IRequest<List<DonorViewModel>>
    {
    }
}
