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

        public async Task SendActivationEmail(User user, ActivationToken activationToken)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("smarthometeam7@gmail.com", "Smart home team");
            var subject = "Account activation";
            var to = new EmailAddress(user.Email, user.Name);
            var plainTextContent = "Grettings " + user.Name;
            var htmlTemplate = File.ReadAllText("../SmartHome.Data/EmailTemplates/AccountActivationTemplate.html");
            htmlTemplate = htmlTemplate.Replace("{{id}}", user.Id.ToString());
            htmlTemplate = htmlTemplate.Replace("{{token}}", activationToken.Token);
            var htmlContent = htmlTemplate;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendApprovePropertyEmail(User user, Property property)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("smarthometeam7@gmail.com", "Smart home team");
            var subject = "Property Approved";
            var to = new EmailAddress(user.Email, user.Name);

            var htmlTemplate = File.ReadAllText("../SmartHome.Data/EmailTemplates/propertyApprovalEmailTemplate.html");

            htmlTemplate = htmlTemplate.Replace("{{City}}", property.City.Name);
            htmlTemplate = htmlTemplate.Replace("{{Country}}", property.City.Country.Name);
            htmlTemplate = htmlTemplate.Replace("{{Address}}", property.Address);

            var plainTextContent = "Greetings " + user.Name;
            var htmlContent = htmlTemplate;

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendRejectPropertyEmail(User user, Property property, string description)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("smarthometeam7@gmail.com", "Smart home team");
            var subject = "Property Rejected";
            var to = new EmailAddress(user.Email, user.Name);

            var htmlTemplate = File.ReadAllText("../SmartHome.Data/EmailTemplates/propertyRejectionEmailTemplate.html");

            htmlTemplate = htmlTemplate.Replace("{{City}}", property.City.Name);
            htmlTemplate = htmlTemplate.Replace("{{Country}}", property.City.Country.Name);
            htmlTemplate = htmlTemplate.Replace("{{Address}}", property.Address);
            htmlTemplate = htmlTemplate.Replace("{{Description}}", description);

            var plainTextContent = "Greetings " + user.Name;
            var htmlContent = htmlTemplate;

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendSuperAdminCredentials(User superAdmin)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("smarthometeam7@gmail.com", "Smart home team");
            var subject = "Account activation";
            var to = new EmailAddress(superAdmin.Email, superAdmin.Name);
            var plainTextContent = "Grettings " + superAdmin.Name;
            var htmlTemplate = File.ReadAllText("../SmartHome.Data/EmailTemplates/SuperAdminActivationTemplate.html");
            htmlTemplate = htmlTemplate.Replace("{{email}}", superAdmin.Email);
            htmlTemplate = htmlTemplate.Replace("{{password}}", superAdmin.Password);
            htmlTemplate = htmlTemplate.Replace("{{id}}", superAdmin.Id.ToString());

            var htmlContent = htmlTemplate;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
