namespace BloodDonationSystem.Infrastructure.MailService.Configurations
{
    public class MailData(string emailFrom, string emailTo, string subject, string body)
    {
        public string EmailFrom { get; private set; } = emailFrom;
        public string EmailTo { get; private set; } = emailTo;
        public string Subject { get; private set; } = subject;
        public string Body { get; private set; } = body;
    }
}
