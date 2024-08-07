namespace BloodDonationSystem.UnitTest.Core.Entities
{
    public class DonorTests
    {
        [Fact]
        //Given-When-Then
        public void CreateDonor_WithValidData_ShouldCreateNewDonor()
        {
            var dob = DateTime.Now.AddYears(-35);
            var donor = new Donor(
                "John Doe",
                "jd@mail.com",
                dob,
                "male", 190,
                "A", "POSITIVE",
                1, 1 
            );

            Assert.NotNull(donor);
            Assert.Equal("John Doe", donor.FullName);
            Assert.Equal("jd@mail.com", donor.Email);
            Assert.Equal(dob, donor.DoB);
            Assert.Equal("male", donor.Gender);
            Assert.Equal(190, donor.Weight);
            Assert.Equal("A", donor.BloodType);
            Assert.Equal("POSITIVE", donor.RhFactor);
            Assert.Equal(1, donor.AddressId);
            Assert.Equal(1, donor.Id);

        }

        [Fact]
        public void SetDonorInactiveShouldChangeIsActiveValue()
        {
            var dob = DateTime.Now.AddYears(-35);
            var donor = new Donor(
                "John Doe",
                "jd@mail.com",
                dob,
                "male", 0,
                "A", "POSITIVE",
                1, 1
            );

            Assert.Equal(donor.IsActive, true);

            donor.SetDonorInactive();

            Assert.Equal(donor.IsActive, false);
        }

        [Fact]
        public void EditDonorInfoShouldUpdateDonorObject()
        {
            var dob = DateTime.Now.AddYears(-35);
            var donor = new Donor(
                "John Doe",
                "jd@mail.com",
                dob,
                "male", 0,
                "A", "POSITIVE",
                1, 1
            );

            var newDob = DateTime.Now.AddYears(-45);
            donor.UpdateDonorInfo(
                "Jane Doe", "jane@mail.com", 
                newDob, "female", 160, 
                "B", "NEGATIVE"
            );

            Assert.Equal("Jane Doe", donor.FullName);
            Assert.Equal("jane@mail.com", donor.Email);
            Assert.Equal(newDob, donor.DoB);
            Assert.Equal("female", donor.Gender);
            Assert.Equal(160, donor.Weight);
            Assert.Equal("B", donor.BloodType);
            Assert.Equal("NEGATIVE", donor.RhFactor);
        }
    }
}
