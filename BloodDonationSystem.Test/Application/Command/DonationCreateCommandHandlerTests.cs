using BloodDonationSystem.Application.Command.DonationCreate;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Repository;
using Moq;

namespace BloodDonationSystem.UnitTest.Application.Command
{
    public class DonationCreateCommandHandlerTests
    {
        private readonly Mock<IDonationRepository> _mockDonationRepo;
        private readonly DonationCreateCommandHandler _handler;

        public DonationCreateCommandHandlerTests()
        {
            _mockDonationRepo = new Mock<IDonationRepository>();
            _handler = new DonationCreateCommandHandler(_mockDonationRepo.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateDonation_ReturnsCreatedId()
        {
            // Arrange
            var command = new DonationCreateCommand
            {
                DonorId = 1,
                Quantity = 500
            };
            var expectedId = 2;

            _mockDonationRepo
                .Setup(repo => repo.CreateDonation(It.IsAny<Donation>()))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockDonationRepo.Verify(repo => repo.CreateDonation(It.Is<Donation>(
                d => d.DonorId == command.DonorId &&
                     d.Quantity == command.Quantity)), 
                Times.Once);

            Assert.Equal(expectedId, result);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenRepositoryFails()
        {
            // Arrange
            var command = new DonationCreateCommand
            {
                DonorId = 1,
                Quantity = 500
            };

            _mockDonationRepo
                .Setup(repo => repo.CreateDonation(It.IsAny<Donation>()))
                .ThrowsAsync(new Exception("Repository error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
