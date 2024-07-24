namespace BloodDonationSystem.Core.Entities
{
    public class DonationInputModel(int donorId, int quantity, int id) 
    {
        public int DonorId { get; private set; } = donorId;
        public DateTime DonationDate { get; private set; } = DateTime.Now;
        public int Quantity { get; private set; } = quantity;
    }
}
