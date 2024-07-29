using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Query.DonorGetOne
{
    public class DonorGetOneQueryHandler : IRequestHandler<DonorGetOneQuery, DonorDetailDTO>
    {
        private readonly IDonorRepository _donorRepo;

        public DonorGetOneQueryHandler(IDonorRepository donorRepo)
        {
            _donorRepo = donorRepo;
        }

        public async Task<DonorDetailDTO> Handle(DonorGetOneQuery request, CancellationToken cancellationToken)
        {
            return await _donorRepo.DonorGetOne(request.Id, cancellationToken);
        }
    }
}
