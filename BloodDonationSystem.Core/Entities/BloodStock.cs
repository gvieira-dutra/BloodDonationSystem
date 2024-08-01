namespace BloodDonationSystem.Core.Entities
{
    public class BloodStock(string bloodType, string rhFactor, int quantity, int id) : BaseEntity(id)
    {
        public string BloodType { get; private set; } = bloodType;
        public int Quantity { get; private set; } = quantity;
        public string RhFactor { get; private set; } = rhFactor;

        public void UpdateStock(int qty)
        {
            Quantity += qty;
        }
    }
}
