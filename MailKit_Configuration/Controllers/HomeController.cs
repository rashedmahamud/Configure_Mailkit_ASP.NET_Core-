using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MailKit_Configuration.Models;
using MailKit_Configuration.Interface;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit_Configuration.Service;

namespace MailKit_Configuration.Controllers
{
    public class HomeController : Controller
    {


       
        private EmailConfiguration emailConfiguration;
        private readonly IEmailService _Mailer;
       

        public HomeController( IEmailService Mailer)
        {
            _Mailer = Mailer;
           
        }
       

        public IActionResult Index()
        {
            // Instansiate minemessage 
            var message = new MimeMessage();
            //From Address
            message.From.Add(new MailboxAddress("Rashed ", "rashedmahamud93@gmail.com"));
            // To Address
            message.To.Add(new MailboxAddress("Dev Rashed ", "rashedmahamud93@gmail.com"));

            //Subject
            message.Subject = "Mail Kit test";
            //Body 

            message.Body = new TextPart("Plain")
            {
                Text = "This is from mailKit, hello there!"
            };

            // configure and send email
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("rashedmahamud93@gmail.com", "helloworld@02");
                client.Send(message);
                client.Disconnect(true);

            }



            // sending mail using mailservice


            //var emailMessage = new EmailMessage();
            //emailMessage.FromAddresses.Add(new EmailAddress { Name="Rashed", Address= "rashedmahamud93@gmail.com" });
            //emailMessage.ToAddresses.Add(new EmailAddress { Name = "Rashed Personal", Address = "rashedmahamud93@gmail.com" });
            //emailMessage.Subject = "Forget Password";
            //emailMessage.Content = "This mail is sent to reset your password.";

            //_Mailer.Send(emailMessage);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
