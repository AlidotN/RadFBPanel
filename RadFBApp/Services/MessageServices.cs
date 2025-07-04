﻿
using RadFBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RadFBApp.Services
{
    public class MessageServices : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            ApplicationDbContext database = new ApplicationDbContext();
            var qservice = database.Tbl_siteSetting.FirstOrDefault();

            MailMessage msg = new MailMessage();
            msg.Body = message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress(qservice.Email, "رادفبی", Encoding.UTF8);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.Sender = msg.From;
            msg.Subject = subject;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.To.Add(new MailAddress(email, "گیرنده", Encoding.UTF8));

            SmtpClient smtp = new SmtpClient();
           // smtp.Host = qservice.Smpt;
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
           // smtp.Credentials = new NetworkCredential(qservice.Email, qservice.EmailPwd);
           // smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);

            return Task.FromResult(0);
        }
    }
}
