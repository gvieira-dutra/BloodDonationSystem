using MediatR;

namespace BloodDonationSystem.Application.Command.DonationDelete
{
    public class DonationDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DonationDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
