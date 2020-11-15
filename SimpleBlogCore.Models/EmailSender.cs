using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using SimpleBlogCore.Data.Models;
using SimpleBlogCore.Service.Interfaces;

namespace SimpleBlogCore.Service
{
    public class EmailSender
    {
        private readonly IManageSettings _settings;
        private SettingsModel settingsModel;

        public EmailSender(IManageSettings settings)
        {
            _settings = settings;
        }

        public async Task<Task> SendContactFormEmailAsync(string senderName, string senderEmail, string senderPhone, string senderMessage, string subject = "Website Inquiry")
        {
            var message = FormattedBody(senderName, senderEmail, senderPhone, senderMessage);
            settingsModel = await _settings.GetSettingsAsync();

            return Execute(settingsModel.SendGridKey, subject, message, senderEmail, settingsModel.EmailAddress);
        }

        public Task Execute(string apiKey, string subject, string message, string senderEmail, string ownerEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(senderEmail),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(ownerEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }

        private string FormattedBody(string name, string email, string phone, string message)
        {
            var senderInfo = $"<b>From</b>: {name}<br/><b>Email</b>: {email}<br/><b>Phone</b>: {phone}<br/><br/>";
            return senderInfo + message;
        }
    }
}