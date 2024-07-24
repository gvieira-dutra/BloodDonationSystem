namespace BloodDonationSystem.Core.Entities
{
    public class Donation(int donorId, int quantity) : BaseEntity
    {
        public int DonorId { get; private set; } = donorId;
        public DateTime DonationDate { get; private set; } = DateTime.Now;
        public int Quantity { get; private set; } = quantity;
        public Donor Donor { get; private set; }
    }
}
