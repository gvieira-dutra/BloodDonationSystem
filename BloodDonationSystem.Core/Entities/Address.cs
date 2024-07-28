using BloodDonationSystem.Core.Entities;

public class Address(string street, string city, string province, string postalCode, int id) : BaseEntity(id)
{
    public string Street { get; private set; } = street;
    public string City { get; private set; } = city;
    public string Province { get; private set; } = province;
    public string PostalCode { get; private set; } = postalCode;
}
