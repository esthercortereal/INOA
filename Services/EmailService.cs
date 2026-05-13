using System.Net;
using System.Net.Mail;
using System.Text.Json;
using INOA.Models;

namespace INOA.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService()
        {
            string json =
                File.ReadAllText("AppSettings.json");

            AppSettings appSettings =
                 JsonSerializer.Deserialize<AppSettings>(json);

            _settings =
                appSettings.Email;
        }

        public async Task SendEmail(
            string subject,
            string boddy
        )
        {
            MailMessage mail =
                new MailMessage();

            mail.From =
                new MailAddress(_settings.Sender);

            mail.To.Add(_settings.Receiver);

            mail.Subject = subject;

            mail.Body = boddy;

            SmtpClient smtp = 
                new SmtpClient(
                    _settings.SmtpServer,
                    _settings.Port
                );
            smtp.Credentials =
                new NetworkCredential(
                    _settings.Sender,
                    _settings.Password
                );

            smtp.EnableSsl = true;

            await smtp.SendMailAsync(mail);
        }
    }
}