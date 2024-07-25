namespace BloodDonationSystem.Core.Entities
{
    public class Donation: BaseEntity
    {
        public Donation(int donorId, int quantity)
        {
            DonorId = donorId;
            DonationDate = DateTime.Now;
            Quantity = quantity;
        }
        public Donation(int donorId, DateTime donationDate, int quantity)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Quantity = quantity;
        }   
        
        public Donation(int donorId, DateTime donationDate, int quantity, Donor donor)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Quantity = quantity;
            Donor = donor;
        }

        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Quantity { get; private set; }
        public Donor? Donor { get; private set; }
    }
}
