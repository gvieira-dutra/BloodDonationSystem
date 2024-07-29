using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonorPut
{
    public class DonorPutCommandHandler : IRequestHandler<DonorPutCommand, DonorDTO>
    {
        private readonly IDonorRepository _donorRepo;

        public DonorPutCommandHandler(IDonorRepository donorRepo)
        {
            _donorRepo = donorRepo;
        }

        public async Task<DonorDTO> Handle(DonorPutCommand request, CancellationToken cancellationToken)
        {
            var newInfo = new DonorUpdateDTO(
                request.Id,
                request.FullName,
                request.Email,
                request.DoB,
                request.Gender,
                request.Weight,
                request.BloodType,
                request.RhFactor);

            return await _donorRepo.DonorUpdate(newInfo, cancellationToken);
        }
    }
}
