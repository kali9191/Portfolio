
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Portfolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Pages
{
    public class HomeModel : PageModel
    {
        public List<Project> Projects { get; set; } = new();

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Message { get; set; }
        private readonly IConfiguration _configuration;

        public HomeModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            Projects = new List<Project>
            {
                new Project
                {
                    Title = "Movicare – Healthcare at Home",
                    SystemName = "Personal Healthcare Platform",
                    Description = "Designed and developed a healthcare platform that enables patients to book home healthcare services online. Built a responsive landing page, appointment booking, patient registration, secure authentication, administrative dashboard, and implemented Clean Architecture using Dapper, MediatR (CQRS), and Repository Pattern.",
                    Technologies = "ASP.NET Core Razor Pages, C#, SQL Server, Dapper, MediatR (CQRS), AutoMapper, HTML5, CSS3, Bootstrap, JavaScript",
                    Role = "Designed the complete application architecture, developed frontend and backend modules, implemented business logic, authentication, SQL Server database, stored procedures, and deployment.",
                    LiveLink = "https://movicare.in"
                },

                new Project
                {
                    Title = "RCMS (Ration Card Management System)",
                    SystemName = "Government Enterprise Application",
                    Description = "Contributed to the development, enhancement, and maintenance of multiple RCMS modules used across West Bengal. Developed new features, enhanced citizen service workflows, implemented Aadhaar authentication, optimized SQL Server stored procedures, and improved application performance.",
                    Technologies = "ASP.NET Core Razor Pages, ASP.NET Web Forms, C#, SQL Server, Dapper, MediatR (CQRS), AutoMapper, REST API",
                    Role = "Backend development, business logic implementation, SQL Server optimization, REST API integration, production support, debugging, and deployment.",
                    LiveLink = "https://wbpds.wb.gov.in/rcmsnew/AadhaarAuthenticationLogin/Index"
                }
            };  
        }

        public async Task<IActionResult> OnPostSendMessage()
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            var mail = new MailMessage();

            mail.From = new MailAddress(emailSettings["FromEmail"]);


            mail.To.Add(emailSettings["ToEmail"]);


            mail.ReplyToList.Add(new MailAddress(Email));

            mail.Subject = "New Contact Message from Portfolio";

            mail.Body = $@"
            Name: {Name}
            Visitor Email: {Email}

            Message:
            {Message}
            ";

            var smtp = new SmtpClient(
                emailSettings["SmtpServer"],
                int.Parse(emailSettings["Port"])
            )
            {
                Credentials = new NetworkCredential(
                    emailSettings["Username"],
                    emailSettings["AppPassword"]
                ),
                EnableSsl = true
            };
            Console.WriteLine($"Username: {emailSettings["Username"]}");
            Console.WriteLine($"Password Exists: {!string.IsNullOrWhiteSpace(emailSettings["AppPassword"])}");
            Console.WriteLine($"SMTP: {emailSettings["SmtpServer"]}");
            Console.WriteLine($"Port: {emailSettings["Port"]}");
            await smtp.SendMailAsync(mail);
            TempData["SuccessMessage"] = "Your message has been sent successfully. I will contact you soon.";

            return RedirectToPage();
        }



    }
}
