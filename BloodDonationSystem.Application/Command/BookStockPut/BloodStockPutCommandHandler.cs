using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using BloodDonationSystem.Infrastructure.Configurations.Service;
using BloodDonationSystem.Infrastructure.MailService.Configurations;
using MediatR;

namespace BloodDonationSystem.Application.Command.BookStockPut
{
    public class BloodStockPutCommandHandler : IRequestHandler<BloodStockPutCommand, BloodStockDTO>
    {
        private readonly IBloodStockRepository _bloodRepository;
        private readonly IMailService _mailService;

        public BloodStockPutCommandHandler(IBloodStockRepository bloodRepository, IMailService mailService)
        {
            _bloodRepository = bloodRepository;
            _mailService = mailService;
        }

        public async Task<BloodStockDTO> Handle(BloodStockPutCommand request, CancellationToken cancellationToken)
        {
            var stockToBeUpdated = await _bloodRepository.GetOneBloodType(request.Id);

            if (stockToBeUpdated != null)
            {
                stockToBeUpdated.UpdateStock(request.QuantityToAddOrRemove);

                await _bloodRepository.SaveChangesOnDb();

                if(request.QuantityToAddOrRemove < 0 && stockToBeUpdated.Quantity < 10000)
                {
                    var mailBody = "Attention! Blood type " + stockToBeUpdated.BloodType + 
                        " " + stockToBeUpdated.RhFactor + " levels are low. There is only " + stockToBeUpdated.Quantity + "ml in stock.";

                    var email = new MailData(
                        "mailtrap@demomailtrap.com", 
                        "gleisonvieiraa@gmail.com", 
                        "Warning, stock levels critically low.", 
                        mailBody);
                    
                    _mailService.SendWarningMail(email);
                }

                var updatedStockVM = new BloodStockDTO(
                    stockToBeUpdated.BloodType,
                    stockToBeUpdated.RhFactor,
                    stockToBeUpdated.Quantity);

                return updatedStockVM;
            }

            return null;
        }
    }
}
