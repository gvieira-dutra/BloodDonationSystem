using BloodDonationSystem.Core.Enum;

namespace BloodDonationSystem.Core.Entities
{
    public class BloodStock(BloodTypeEnum bloodType, RhFactorEnum rhFactor, int quantity) : BaseEntity
    {
        public BloodTypeEnum BloodType { get; private set; } = bloodType;
        public RhFactorEnum RhFactor { get; private set; } = rhFactor;
        public int Quantity { get; private set; } = quantity;

        public void updateQuantity(int qty)
        {
            Quantity += qty;
        }
    }
}
