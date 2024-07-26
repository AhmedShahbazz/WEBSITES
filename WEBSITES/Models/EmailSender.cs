using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace WEBSITES.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Here you would implement your email sending logic.
            // For now, just returning a completed task.
            return Task.CompletedTask;
        }
    }
}
