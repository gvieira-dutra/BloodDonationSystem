using MediatR;

namespace BloodDonationSystem.Application.Command.DonorDelete
{
    public class DonorDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DonorDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
