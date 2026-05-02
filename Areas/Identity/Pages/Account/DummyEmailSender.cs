using Microsoft.AspNetCore.Identity.UI.Services;

namespace ArtDecoMebel.Areas.Identity.Pages.Account
{    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }

}
