using BloodDonationSystem.Application.Query.DonorGetOne;
using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using Moq;

namespace BloodDonationSystem.UnitTest.Application.Queries
{
    public class DonorGetOneQueryHandlerTests
    {
        private readonly Mock<IDonorRepository> _mockDonorRepo;
        private readonly DonorGetOneQueryHandler _handler;

        public DonorGetOneQueryHandlerTests()
        {
            _mockDonorRepo = new Mock<IDonorRepository>();
            _handler = new DonorGetOneQueryHandler(_mockDonorRepo.Object);
        }

        [Fact]
        public async Task GivenValidDonorId_ShouldReturnDonorDetails()
        {
            // arrange
            var donorId = 1;
            var donations = new List<DonationDTO>
            {
                new DonationDTO(1, DateTime.Now, 250),
                new DonationDTO(2, DateTime.Now.AddDays(-15), 300)
            };

            var address = new Address("123 Main St", "Somewhere", "ST", "m4r 5t6", 1);

            var donor = new Donor("John Doe", "jd@mail.com", new DateTime(1990, 12, 5), "male", 190, "A", "NEGATIVE", 1, donorId);

            var expectedDonorDetailDTO = new DonorDetailDTO(
                donor.FullName,
                donor.Email,
                donor.DoB,
                donor.Gender,
                donor.Weight,
                donor.BloodType,
                donor.RhFactor,
                donor.Address
            );

            expectedDonorDetailDTO.SetDonations(donations);

            _mockDonorRepo.Setup(repo => repo.DonorGetOne(donorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedDonorDetailDTO);

            var query = new DonorGetOneQuery(donorId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDonorDetailDTO.FullName, result.FullName);
            Assert.Equal(expectedDonorDetailDTO.Email, result.Email);
            Assert.Equal(expectedDonorDetailDTO.DoB, result.DoB);
            Assert.Equal(expectedDonorDetailDTO.Gender, result.Gender);
            Assert.Equal(expectedDonorDetailDTO.Weight, result.Weight);
            Assert.Equal(expectedDonorDetailDTO.BloodType, result.BloodType);
            Assert.Equal(expectedDonorDetailDTO.RhFactor, result.RhFactor);
            Assert.Equal(expectedDonorDetailDTO.Address, result.Address);
        }

        [Fact]
        public async Task GivenInvalidDonorId_ShouldReturnNull()
        {
            // Arrange
            var donorId = 999; // Assuming this ID does not exist

            _mockDonorRepo.Setup(repo => repo.DonorGetOne(donorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((DonorDetailDTO)null);

            var query = new DonorGetOneQuery(donorId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}
