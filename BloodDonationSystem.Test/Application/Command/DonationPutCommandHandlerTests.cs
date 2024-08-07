using BloodDonationSystem.Application.Command.DonationPut;
using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using Moq;

namespace BloodDonationSystem.UnitTest.Application.Command
{
    public class DonationPutCommandHandlerTests
    {
        private readonly Mock<IDonationRepository> _mockDonationRepo;
        

        public DonationPutCommandHandlerTests()
        {
             _mockDonationRepo = new Mock<IDonationRepository>();
        }

        [Fact]
        public async Task GivenValidData_Execute_DataIsUpdated()
        {
            //Arrange
            var donationPutCommand = new DonationPutCommand
            {
                Id = 1,
                NewQuantity = 500
            };

            var donationDetailDTO = new DonationDetailDTO(1, DateTime.Now, 500, "AnyName", "Any@mail", "A", "NEGATIVE");

            _mockDonationRepo.Setup(repo => repo.DonationUpdate(donationPutCommand.Id, donationPutCommand.NewQuantity, It.IsAny<CancellationToken>()))
                .ReturnsAsync(donationDetailDTO);

            var handler = new DonationPutCommandHandler(_mockDonationRepo.Object);

            //Act
            var result = await handler.Handle(donationPutCommand, new CancellationToken());

            //Assert
            Assert.True(result.Quantity == 500);
        }

        [Fact]
        public async Task GivenInvalidData_ShouldThrowException()
        {
            // Arrange
            var donationPutCommand = new DonationPutCommand
            {
                Id = 0, 
                NewQuantity = -10 
            };

           _mockDonationRepo.Setup(repo => repo.DonationUpdate(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ArgumentException("Invalid data"));

            var handler = new DonationPutCommandHandler(_mockDonationRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(donationPutCommand, new CancellationToken()));
        }

        [Fact]
        public async Task GivenValidDataButRepositoryReturnsNull_ShouldReturnNulll()
        {
            //Arrange
            var donationPutCommand = new DonationPutCommand
            {
                Id = 1,
                NewQuantity = 500
            };

            _mockDonationRepo.Setup(repo => repo.DonationUpdate(donationPutCommand.Id, donationPutCommand.NewQuantity, It.IsAny<CancellationToken>()))
                .ReturnsAsync((DonationDetailDTO)null);
                
            var handler = new DonationPutCommandHandler(_mockDonationRepo.Object);

            //Act
            var result = await handler.Handle(donationPutCommand, new CancellationToken()); 

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GivenValidData_WhenRepositoryThrowsException_ShouldThrowException()
        {
            //arrange
            var donationPutCommand = new DonationPutCommand 
            { 
                Id = 1,
                NewQuantity = 500
            };

            _mockDonationRepo.Setup(repo => repo.DonationUpdate(donationPutCommand.Id, donationPutCommand.NewQuantity, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Repository error"));

            var handler = new DonationPutCommandHandler(_mockDonationRepo.Object);

            //act & assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(donationPutCommand, new CancellationToken()));

        }
    }
}
