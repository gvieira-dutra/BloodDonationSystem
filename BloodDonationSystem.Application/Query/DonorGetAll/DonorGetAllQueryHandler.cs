using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonorGetAll
{
    public class DonorGetAllQueryHandler : IRequestHandler<DonorGetAllQuery, List<DonorDTO>>
    {
        private readonly IDonorRepository _donorRepo;

        public DonorGetAllQueryHandler(IDonorRepository donorRepo)
        {
            _donorRepo = donorRepo;
        }

        public async Task<List<DonorDTO>> Handle(DonorGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _donorRepo.DonorGetAll(cancellationToken);
        }
    }
}
