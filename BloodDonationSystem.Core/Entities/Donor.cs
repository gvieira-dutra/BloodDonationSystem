using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enum;

public class Donor(string fullName, string email, DateTime doB, string gender, double weight, BloodTypeEnum bloodType, RhFactorEnum rhFactor, int addressId) : BaseEntity
{
    public string FullName { get; private set; } = fullName;
    public string Email { get; private set; } = email;
    public DateTime DoB { get; private set; } = doB;
    public string Gender { get; private set; } = gender;
    public double Weight { get; private set; } = weight;
    public BloodTypeEnum BloodType { get; private set; } = bloodType;
    public RhFactorEnum RhFactor { get; private set; } = rhFactor;
    public List<Donation> Donations { get; private set; } = new List<Donation>();
    public int AddressId { get; private set; } = addressId;
    public Address Address { get; private set; }

    public void SetDonations(List<Donation> donations)
    {
        Donations = donations;
    }

    
}


