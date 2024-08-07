using BloodDonationSystem.Application.Query.DonationGetRecent;
using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using Moq;

namespace BloodDonationSystem.UnitTest.Application.Queries
{
    public class DonationGetRecentQueryHandlerTests
    {
        private readonly Mock<IDonationRepository> _mockDonationRepo;
        private readonly DonationGetRecentQueryHandler _handler;

        public DonationGetRecentQueryHandlerTests()
        {
            _mockDonationRepo = new Mock<IDonationRepository>();
            _handler = new DonationGetRecentQueryHandler(_mockDonationRepo.Object);
        }

        [Fact]
        public async Task GivenRecentDonations_ShouldReturnCorrectData()
        {
            // arrange
            var recentDonations = new List<DonationDetailDTO>
            {
                new DonationDetailDTO(1, DateTime.Now.AddDays(-1), 250, "John Doe", "john.doe@example.com", "A", "POSITIVE"),
                new DonationDetailDTO(2, DateTime.Now.AddDays(-5), 300, "Jane Smith", "jane.smith@example.com", "B", "NEGATIVE")
            };

            _mockDonationRepo
                .Setup(repo => repo.DonationGetRecent())
                .ReturnsAsync(recentDonations);

            var query = new DonationGetRecentQuery();

            // act
            var result = await _handler.Handle(query, CancellationToken.None);

            // assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, d => d.Id == 1 && d.Quantity == 250 && d.DonorName == "John Doe");
            Assert.Contains(result, d => d.Id == 2 && d.Quantity == 300 && d.DonorName == "Jane Smith");
        }

        [Fact]
        public async Task GivenRecentAndOldDonations_ShouldReturnOnlyRecentDonations()
        {
            //arrange
            var now = DateTime.Now;

            var allDonations = new List<DonationDetailDTO>
            {
                new DonationDetailDTO(1, now.AddDays(-1), 250, "John Doe", "john.doe@example.com", "A", "POSITIVE"),  // Recent
                new DonationDetailDTO(2, now.AddDays(-5), 300, "Jane Smith", "jane.smith@example.com", "B", "NEGATIVE"), // Recent
                new DonationDetailDTO(3, now.AddDays(-61), 150, "Old Donor", "old.donor@example.com", "O", "POSITIVE")   // Old
            };

           _mockDonationRepo
                .Setup(repo => repo.DonationGetRecent())
               .ReturnsAsync(allDonations.Where(d => d.DonationDate >= DateTime.Now.AddDays(-30)).ToList());

            var query = new DonationGetRecentQuery();

            //act
            var result = await _handler.Handle(query, CancellationToken.None);

            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count); // Expecting only recent donations
            Assert.Contains(result, d => d.Id == 1 && d.Quantity == 250 && d.DonorName == "John Doe");
            Assert.Contains(result, d => d.Id == 2 && d.Quantity == 300 && d.DonorName == "Jane Smith");
            Assert.DoesNotContain(result, d => d.Id == 3 && d.DonorName == "Old Donor"); // Ensure old donations are not present
        }


        [Fact]
        public async Task GivenEmptyList_ShouldReturnEmptyList()
        {
            // arrange
            var recentDonations = new List<DonationDetailDTO>(); // Empty list

            _mockDonationRepo
                .Setup(repo => repo.DonationGetRecent())
                .ReturnsAsync(recentDonations);

            var query = new DonationGetRecentQuery();

            // act
            var result = await _handler.Handle(query, CancellationToken.None);

            // assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GivenRepositoryThrowsException_ShouldPropagateException()
        {
            // arrange
            _mockDonationRepo
                .Setup(repo => repo.DonationGetRecent())
                .ThrowsAsync(new Exception("Repository error"));

            var query = new DonationGetRecentQuery();

            // act & assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(query, CancellationToken.None));
        }


    }
}
