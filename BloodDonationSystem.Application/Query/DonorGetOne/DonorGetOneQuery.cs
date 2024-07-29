using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.DTO;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonorGetOne
{
    public class DonorGetOneQuery : IRequest<DonorDetailDTO>
    {
        public int Id { get; private set; }

        public DonorGetOneQuery(int id)
        {
            Id = id;
        }
    }
}
