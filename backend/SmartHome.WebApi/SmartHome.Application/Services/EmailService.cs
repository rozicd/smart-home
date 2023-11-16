using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;

namespace SmartHome.Application.Services
{
    public class EmailService : IEmailService
    {

        public async Task SendActivationEmail(User user)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("smarthometeam7@gmail.com", "Smart home team");
            var subject = "Account activation";
            var to = new EmailAddress(user.Email, user.Name);
            var plainTextContent = "Grettings " + user.Name;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendApprovePropertyEmail(User user,Property property)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("smarthometeam7@gmail.com", "Smart home team");
            var subject = "Account activation";
            var to = new EmailAddress(user.Email, user.Name);
            var plainTextContent = "Grettings " + user.Name;
            var htmlContent = "Congratulations\n<strong>Your property in city " + property.City.Name + " on address " + property.Address + " has been approved</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }


        public async Task SendRejectPropertyEmail(User user,Property property)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("smarthometeam7@gmail.com", "Smart home team");
            var subject = "Account activation";
            var to = new EmailAddress(user.Email, user.Name);
            var plainTextContent = "Grettings " + user.Name;
            var htmlContent = "We are sorry\n<strong>Your property in city "+property.City.Name+" on address " + property.Address + " has been rejected</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
