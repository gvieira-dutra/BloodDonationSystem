using BloodDonationSystem.Infrastructure.Configurations.Service;
using BloodDonationSystem.Infrastructure.MailService.Configurations;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
namespace BloodDonationSystem.Infrastructure.MailService.Service
{
    public class MailService(IOptions<MailSettings> options) : IMailService
    {
        private readonly MailSettings _mailSettings = options.Value;

        public bool SendWarningMail(MailData email)
        {
            try{
                
                var client = new SmtpClient(_mailSettings.Host, _mailSettings.Port
                    )
                {
                    Credentials = new NetworkCredential(_mailSettings.EmailId, _mailSettings.Password),
                    EnableSsl = _mailSettings.UseSSL
                };                

                client.Send(email.EmailFrom, email.EmailTo, email.Subject, email.Body);
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
