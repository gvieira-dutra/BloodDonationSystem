using BloodDonationSystem.Application.ViewModels;
using MediatR;

namespace BloodDonationSystem.Application.Command.BookStockPut
{
    public class BloodStockPutCommand : IRequest<BloodStockViewModel>
    {
        public int Id { get; set; }
        public int QuantityToAddOrRemove { get; set; }
    }
}
