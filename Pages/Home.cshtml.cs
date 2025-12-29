
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
                    Title = "Self-Service Module Implementation",
                    SystemName = "RCMS (Ration Card Management System)",
                    Description = "Designed and implemented Aadhaar-based self-service functionality allowing citizens to independently update and manage ration card details with secure authentication and validation.",
                    Technologies = "ASP.NET, C#, SQL Server, Aadhaar Authentication",
                    Role = "Module design, development, validation logic, and production support",
                    LiveLink = "https://food.wb.gov.in/Dynamic.aspx?page_id=81"
                },
                new Project
                {
                    Title = "New RCMS Module Development",
                    SystemName = "RCMS (Ration Card Management System)",
                    Description = "Contributed to end-to-end development of a modernized RCMS module using .NET Core, focusing on streamlined application workflows, improved validations, and scalable architecture.",
                    Technologies = ".NET Core, ASP.NET Core, SQL Server",
                    Role = "Backend development, workflow implementation, and database handling",
                    LiveLink = "https://wbpds.wb.gov.in/rcmsnew/AadhaarAuthenticationLogin/Index"
                },
                new Project
                {
                    Title = "SKOIL Module Development",
                    SystemName = "Dealer Profile Management Workflow",
                    Description = "Developed a multi-stage, workflow-driven dealer profile management system ensuring structured data submission, verification, and escalation logic under the Public Distribution System.",
                    Technologies = "ASP.NET Core Razor Pages, SQL Server",
                    Role = "Workflow design, backend development, and stored procedures",
                    LiveLink = "https://food.wb.gov.in/food/UserLogin/Login.aspx"
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

            await smtp.SendMailAsync(mail);
            TempData["SuccessMessage"] = "Your message has been sent successfully. I will contact you soon.";

            return RedirectToPage();
        }



    }
}
