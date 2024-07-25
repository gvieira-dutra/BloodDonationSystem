namespace BloodDonationSystem.Core.Entities
{
    public class DonationInputModel(int donorId, int quantity) 
    {
        public int DonorId { get; private set; } = donorId;
        public int Quantity { get; private set; } = quantity;
    }
}
