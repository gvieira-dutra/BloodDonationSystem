using BloodDonationSystem.Infrastructure.MailService.Configurations;

namespace BloodDonationSystem.Infrastructure.Configurations.Service
{
    public interface IMailService
    {
        bool SendWarningMail(MailData body);
    }
}
