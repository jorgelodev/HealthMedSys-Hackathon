
using System.Net.Mail;
using System.Net;
using HMS.Domain.Interfaces.Gateways;

namespace HMS.Infra.Services.Services
{
    public abstract class EmailSenderService
    {
        private readonly IEmailConfigGateway _emailConfigGateway;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _username;
        private readonly string _password;

        protected EmailSenderService(IEmailConfigGateway emailConfigGateway)
        {
            _emailConfigGateway = emailConfigGateway;

            var emailConfig = _emailConfigGateway.Buscar();

            _smtpServer = emailConfig.SmtpServer;
            _smtpPort = emailConfig.SmtpPort;
            _username = emailConfig.Username;
            _password = emailConfig.Password;
        }       

        protected async Task EnviaEmailAsync(string para, string titulo, string corpo)
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_username, _password);
                client.EnableSsl = false;

                var message = new MailMessage(_username, para, titulo, corpo);

                await client.SendMailAsync(message);
            }
        }
    }
}
