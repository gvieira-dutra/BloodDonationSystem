namespace BloodDonationSystem.Infrastructure.MailService.Configurations
{ 
    public class MailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
    }
}
