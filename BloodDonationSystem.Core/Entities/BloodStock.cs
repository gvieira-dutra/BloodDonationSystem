using BloodDonationSystem.Core.Enum;

namespace BloodDonationSystem.Core.Entities
{
    public class BloodStock(BloodTypeEnum bloodType, RhFactorEnum rhFactor, int quantity, int id) : BaseEntity(id)
    {
        public BloodTypeEnum BloodType { get; private set; } = bloodType;
        public int Quantity { get; private set; } = quantity;
        public RhFactorEnum RhFactor { get; private set; } = rhFactor;

        public void UpdateStock(int qty)
        {
            Quantity += qty;
        }
    }
}
