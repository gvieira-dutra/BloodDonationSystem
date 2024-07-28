using BloodDonationSystem.Application.ViewModels;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonationPut
{
    public class DonationPutCommand : IRequest<DonationDetailViewModel>
    {
        public int Id { get; set; }
        public int NewQuantity { get; set; }
    }
}
