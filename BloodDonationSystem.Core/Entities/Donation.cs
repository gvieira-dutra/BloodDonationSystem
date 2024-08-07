namespace BloodDonationSystem.Core.Entities
{
    public class Donation(int donorId, int quantity, int id) : BaseEntity(id)
    {
        public DateTime DonationDate { get; private set; } = DateTime.Now;
        public Donor? Donor { get; private set; }
        public int DonorId { get; private set; } = donorId;
        public int Quantity { get; private set; } = quantity;
        public bool IsActive { get; private set; } = true;

        public void DeleteDonation()
        {
            IsActive = false;
        }

        public void UpdateQty(int qty)
        {
            Quantity = qty;
        }
    }
}
