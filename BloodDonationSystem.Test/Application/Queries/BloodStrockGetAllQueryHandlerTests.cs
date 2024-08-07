using BloodDonationSystem.Application.Query.BloodStockGetAll;
using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using Moq;

namespace BloodDonationSystem.UnitTest.Application.Queries
{
    public class BloodStockGetAllQueryHandlerTests
    {
        private readonly Mock<IBloodStockRepository> _mockBloodStockRepo;
        private readonly BloodStockGetAllQueryHandler _handler;

        public BloodStockGetAllQueryHandlerTests()
        {
            _mockBloodStockRepo = new Mock<IBloodStockRepository>();
            _handler = new BloodStockGetAllQueryHandler(_mockBloodStockRepo.Object);
        }

        [Fact]
        public async Task GivenExistingBloodStocks_ReturnsCorrectData()
        {
            // Arrange
            var bloodStocks = new List<BloodStockDTO>
            {
                new BloodStockDTO("A", "POSITIVE", 100),
                new BloodStockDTO("B", "NEGATIVE", 200)
            };

            _mockBloodStockRepo
                .Setup(repo => repo.GetAllBloodStock())
                .ReturnsAsync(bloodStocks);

            var query = new BloodStockGetAllQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, bs => 
            bs.BloodType == "A" && 
            bs.RhFactor == "POSITIVE" && 
            bs.Quantity == 100);
            Assert.Contains(result, bs => 
            bs.BloodType == "B" && 
            bs.RhFactor == "NEGATIVE" && 
            bs.Quantity == 200);
        }

        [Fact]
        public async Task GivenNoBloodStocks_ShouldReturnEmptyList()
        {
            // arrange
            var bloodStocks = new List<BloodStockDTO>(); // Empty list

            _mockBloodStockRepo
                .Setup(repo => repo.GetAllBloodStock())
                .ReturnsAsync(bloodStocks);

            var query = new BloodStockGetAllQuery();

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
            _mockBloodStockRepo
                .Setup(repo => repo.GetAllBloodStock())
                .ThrowsAsync(new System.Exception("Repository error"));

            var query = new BloodStockGetAllQuery();

            // act & assert
            await Assert.ThrowsAsync<System.Exception>(() => _handler.Handle(query, CancellationToken.None));
        }


    }
}
