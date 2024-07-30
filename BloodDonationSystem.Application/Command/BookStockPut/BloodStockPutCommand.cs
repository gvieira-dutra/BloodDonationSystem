using BloodDonationSystem.Core.DTO;
using MediatR;

namespace BloodDonationSystem.Application.Command.BookStockPut
{
    public class BloodStockPutCommand : IRequest<BloodStockDTO>
    {
        public int Id { get; set; }
        public int QuantityToAddOrRemove { get; set; }
    }
}
