using BloodDonationSystem.Core.Repository;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonorDelete
{
    public class DonorDeleteCommandHandler : IRequestHandler<DonorDeleteCommand, Unit>
    {
        private readonly IDonorRepository _donorRepo;

        public DonorDeleteCommandHandler(IDonorRepository donorRepo)
        {
            _donorRepo = donorRepo;
        }
        public async Task<Unit> Handle(DonorDeleteCommand request, CancellationToken cancellationToken)
        {
            await _donorRepo.DonorDelete(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
