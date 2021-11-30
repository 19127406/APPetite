using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace APPetite
{
    public class Email
    {
        public void send_email(string emailAddress, string subject)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("chn14789@gmail.com", "APPetite");
            mail.To.Add(emailAddress);
            mail.Subject = subject;

            mail.IsBodyHtml = true;
            string htmlString = @"<html>
                      <body>
                      <p>Dear Mr. Triet,</p>
                      <p>Con cac</p>
                      <p>Sincerely,<br> - APPetite</br></p>
                      </body>
                      </html>
                     ";

            mail.Body = htmlString;

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("chn14789@gmail.com", "rtoogigo2003");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
