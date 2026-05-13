namespace INOA.Models
{
    public class AppSettings
    {
        public EmailSettings Email { get; set; }
    }

    public class EmailSettings
    {
        public string Sender { get; set; }

        public string Password { get; set; }

        public string SmtpServer { get; set; }

        public int Port { get; set; }

        public string Receiver { get; set; }
    }
}