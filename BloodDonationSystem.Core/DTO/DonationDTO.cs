
namespace BloodDonationSystem.Core.DTO
{
    public class DonationDTO(int id, DateTime date, int quantity)
    {
        public int id { get; set; } = id;
        public DateTime DonationDate { get; private set; } = date;
        public int Quantity { get; private set; } = quantity;
    }
}
