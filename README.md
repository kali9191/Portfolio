# ASP.NET Core Portfolio Website

This is my personal portfolio website developed using ASP.NET Core Razor Pages.  
It highlights my professional experience, technical skills, and real-world projects developed for large-scale government systems.

The application follows clean architecture principles, uses partial views for modular UI design, and includes a secure contact form with email notification support.

---

## 📌 About the Project

This portfolio website is designed to present my professional profile in a clean, modern, and scalable way.  
It highlights my experience as a **.NET Developer**, showcases enterprise-level projects, and demonstrates real-world development practices used in production systems.

The application uses **Razor Pages with partial views** to maintain modularity, readability, and ease of maintenance.  
A secure contact form is included to allow visitors to reach out directly via email.

---

## 🚀 Features

- Modern, responsive UI design
- Modular architecture using Razor partial views
- Dedicated sections for:
  - About Me
  - Professional Experience
  - Skills
  - Project Portfolio
  - Education
  - Contact
- Secure contact form with email notification
- Clean separation of concerns
- Production-ready configuration management
- HTTPS-enabled deployment

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core (Razor Pages)
- **Language:** C#
- **Frontend:** HTML5, CSS3, JavaScript
- **Styling:** Custom CSS (modern UI & glassmorphism effects)
- **Database:** SQL Server (project-based usage)
- **Email:** SMTP (Gmail App Password)
- **Version Control:** Git & GitHub

---

## 🏗️ Project Structure

```text
Portfolio/
│
├── Models/
│   ├── Project.cs
│   └── ProjectCardVM.cs
│
├── Pages/
│   ├── Home.cshtml
│   ├── Home.cshtml.cs
│   └── Shared/
│       ├── _About.cshtml
│       ├── _Experience.cshtml
│       ├── _Skills.cshtml
│       ├── _Portfolio.cshtml
│       ├── _ProjectCard.cshtml
│       ├── _Education.cshtml
│       └── _Contact.cshtml
│
├── wwwroot/
│   ├── css/
│   └── js/
│
├── appsettings.json
└── Program.cs


## Configuration

This project uses ASP.NET Core User Secrets for sensitive data.

To run locally:

```bash
dotnet user-secrets init
dotnet user-secrets set "EmailSettings:AppPassword" "<your-app-password>"
