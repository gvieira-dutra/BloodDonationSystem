namespace BloodDonationSystem.Application.ViewModels
{
    public class DonationViewModel(int donorId, int quantity)
    {
        public int DonorId { get; private set; } = donorId;
        public DateTime DonationDate { get; private set; } = DateTime.Now;
        public int Quantity { get; private set; } = quantity;
    }
}
