namespace BloodDonationSystem.Core.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(int donorId, int quantity, int id) : base(id)
        {
            DonorId = donorId;
            DonationDate = DateTime.Now;
            Quantity = quantity;
        }

        public Donation(int donorId, DateTime donationDate, int quantity, int id) : base(id)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Quantity = quantity;
        }

        public Donation(int donorId, DateTime donationDate, int quantity, Donor donor, int id) : base(id)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Quantity = quantity;
            Donor = donor;
        }

        public DateTime DonationDate { get; private set; }
        public Donor? Donor { get; private set; }
        public int DonorId { get; private set; }
        public int Quantity { get; private set; }
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
