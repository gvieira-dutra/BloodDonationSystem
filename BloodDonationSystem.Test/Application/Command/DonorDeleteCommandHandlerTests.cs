using BloodDonationSystem.Application.Command.DonorDelete;
using BloodDonationSystem.Core.Repository;
using MediatR;
using Moq;

namespace BloodDonationSystem.UnitTest.Application.Command
{
    public class DonorDeleteCommandHandlerTests
    {
        private readonly Mock<IDonorRepository> _mockDonorRepo;
        private readonly DonorDeleteCommandHandler _handler;
        private readonly int _donorId;

        public DonorDeleteCommandHandlerTests()
        {
            _mockDonorRepo = new Mock<IDonorRepository>();
            _handler = new DonorDeleteCommandHandler(_mockDonorRepo.Object);
            _donorId = 1;
        }

        [Fact]
        public async Task GivenValidId_DonorDeletedSuccessfully()
        {
            // Arrange 
            _mockDonorRepo.Setup(repo => repo
            .DonorDelete(_donorId, new CancellationToken()))
                .Returns(Task.CompletedTask);

            //act
            var result = await _handler.Handle(new DonorDeleteCommand(_donorId), new CancellationToken());

            //assert
            Assert.Equal(Unit.Value, result);
            _mockDonorRepo.Verify(repo => repo
            .DonorDelete(_donorId, It.IsAny<CancellationToken>()), 
            Times.Once());
        }

        [Fact]
        public async Task GivenUnexistingId_ShouldNotThrowException()
        {
            //Arrange
            var donorId = 999;

            _mockDonorRepo.Setup(repo => repo
            .DonorDelete(donorId, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            //act
            var result = await _handler.Handle(new DonorDeleteCommand(donorId), new CancellationToken());

            //assert
            Assert.Equal(Unit.Value, result);
            _mockDonorRepo.Verify(repo => repo
            .DonorDelete(donorId, new CancellationToken()), 
            Times.Once());
        }

        [Fact]
        public async Task GivenValidId_WhenExceptionHappensShouldThrow()
        {
            //Arrange 
            _mockDonorRepo.Setup(repo => repo
            .DonorDelete(_donorId, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Repository Exception"));

            //act & assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(new DonorDeleteCommand(_donorId), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GivenCancellationToken_HandleCancellation()
        {
            //arrange 
            _mockDonorRepo.Setup(repo => repo
            .DonorDelete(_donorId, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new TaskCanceledException());

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            //act & assert 
            await Assert.ThrowsAsync<TaskCanceledException>(() => _handler
            .Handle(new DonorDeleteCommand(_donorId), cancellationTokenSource.Token));
        }
    }
}
