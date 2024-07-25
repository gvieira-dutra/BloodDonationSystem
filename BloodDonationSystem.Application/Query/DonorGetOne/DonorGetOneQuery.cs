using BloodDonationSystem.Application.ViewModels;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonorGetOne
{
    public class DonorGetOneQuery : IRequest<DonorDetailViewModel>
    {
        public int Id { get; private set; }

        public DonorGetOneQuery(int id)
        {
            Id = id;
        }
    }
}
