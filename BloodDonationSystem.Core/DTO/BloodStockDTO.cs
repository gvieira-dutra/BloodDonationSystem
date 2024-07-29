using BloodDonationSystem.Core.Enum;
namespace BloodDonationSystem.Core.DTO
{
    public class BloodStockDTO
    {
        public BloodStockDTO(BloodTypeEnum bloodType, RhFactorEnum rhFactor, int quantity)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Quantity = quantity;
        }

        public BloodTypeEnum BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public int Quantity { get; private set; }
    }
}
