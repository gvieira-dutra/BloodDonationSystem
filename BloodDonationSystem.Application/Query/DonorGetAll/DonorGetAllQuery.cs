
using BloodDonationSystem.Core.DTO;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonorGetAll
{
    public class DonorGetAllQuery : IRequest<List<DonorDTO>>
    {
    }
}
