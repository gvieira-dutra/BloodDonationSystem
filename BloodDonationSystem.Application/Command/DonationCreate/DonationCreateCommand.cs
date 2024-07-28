using MediatR;

namespace BloodDonationSystem.Application.Command.DonationCreate
{
    public class DonationCreateCommand : IRequest<int>
    {
        public int DonorId { get; set; }
        public int Quantity { get; set; }
    }
}
