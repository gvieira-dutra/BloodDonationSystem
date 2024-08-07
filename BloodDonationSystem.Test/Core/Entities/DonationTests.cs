using BloodDonationSystem.Core.Entities;

namespace BloodDonationSystem.UnitTest.Core.Entities
{
    public class DonationTests
    {
        [Fact]
        public void CreateDonationWithValidData()
        {

            var donation = new Donation(1, 420, 2);

            Assert.Equal(1, donation.DonorId);
            Assert.Equal(420, donation.Quantity);
            Assert.Equal(2, donation.Id);
            Assert.True(donation.IsActive);
        }

        [Fact]
        public void DeleteDonation()
        {
            var donation = new Donation(1, 420, 2);

            donation.DeleteDonation();

            Assert.False(donation.IsActive);
        }

        [Fact]
        public void UpdateQty()
        {
            var donation = new Donation(1, 420, 2);

            donation.UpdateQty(500);

            Assert.Equal(500, donation.Quantity);
        }
    }
    
}
