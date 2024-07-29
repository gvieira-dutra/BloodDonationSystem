using BloodDonationSystem.Core.DTO;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonationPut
{
    public class DonationPutCommand : IRequest<DonationDetailDTO>
    {
        public int Id { get; set; }
        public int NewQuantity { get; set; }
    }
}
