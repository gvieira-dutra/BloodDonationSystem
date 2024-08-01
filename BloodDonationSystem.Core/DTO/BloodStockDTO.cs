namespace BloodDonationSystem.Core.DTO
{
    public class BloodStockDTO
    {
        public BloodStockDTO(string bloodType, string rhFactor, int quantity)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Quantity = quantity;
        }

        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int Quantity { get; private set; }
    }
}
