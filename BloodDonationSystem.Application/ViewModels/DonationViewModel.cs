using BloodDonationSystem.Core.Enum;

namespace BloodDonationSystem.Application.ViewModels
{
    public class DonationViewModel(DateTime date, int quantity, string name, string email, BloodTypeEnum bloodTypeEnum, RhFactorEnum rhFactorEnum)
    {
        public DateTime DonationDate { get; private set; } = date;
        public int Quantity { get; private set; } = quantity;
        public string DonorName { get; private set; } = name;
        public string DonorEmail { get; private set; } = email;
        public BloodTypeEnum BloodTypeEnum { get; private set; } = bloodTypeEnum;
        public RhFactorEnum RhFactor { get; private set; } = rhFactorEnum;
    }

}
