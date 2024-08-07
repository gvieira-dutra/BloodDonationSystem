using BloodDonationSystem.Core.Entities;
public class Donor(string fullName, string email, DateTime doB, string gender, double weight, string bloodType, string rhFactor, int addressId, int id) : BaseEntity(id)
{
    public string FullName { get; private set; } = fullName;
    public string Email { get; private set; } = email;
    public DateTime DoB { get; private set; } = doB;
    public string Gender { get; private set; } = gender;
    public double Weight { get; private set; } = weight;
    public string BloodType { get; private set; } = bloodType;
    public string RhFactor { get; private set; } = rhFactor;
    public List<Donation> Donations { get; private set; } = new List<Donation>();
    public int AddressId { get; private set; } = addressId;
    public Address Address { get; private set; }
    public bool IsActive { get; private set; } = true;
    public void SetDonorInactive()
    {
        IsActive = !IsActive;
    }

    public void UpdateDonorInfo(string name, string email, DateTime doB, string gender, double weight, string bloodType, string rhFactor)
    {
        FullName = name;
        Email = email;
        DoB = doB;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
    } 
}
