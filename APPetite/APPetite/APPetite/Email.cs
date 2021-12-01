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
            string htmlString = @"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Document</title>
                        <style>
                            @import url('https://fonts.googleapis.com/css2?family=Montserrat:400,800');
                            *{
                                box-sizing: border-box;
                            }
                            body{
                                font-family: 'Montserrat', sans-serif;
                                display: flex;
                                flex-direction: column;
                                justify-content: center;
                                align-items: center;
                                background-color: #f6f5f7;
                            }
                            #passcode{
                                color: #5777f2;
                            }
                            .container{
                                background-color: #fff;
                                position: relative;
                                overflow: hidden;
                                box-shadow: 5px 5px 5px rgba(116, 115, 115, 0.1);
                                width: 50%;
                            }
                            .inner-container{
                                background: #fff;
                                display: flex;
                                flex-direction: column;
                                justify-content: center;
                                align-items: center;
                                margin: 3rem 0;
                            }
                            .inner-container p{
                                font-size: .9rem;
                                color: gray;
                                width: 70%;
                                height: 100%;
                                text-align: center;
                            }
                            .top-container{
                                color: rgb(95, 95, 95);
                                width: 70%;
                                height: 100%;
                                position: relative;
                                display: flex;
                                flex-direction: column;
                                justify-content: center;
                                align-items: center;
                                text-align: center;
                            }
                        </style>
                    </head>
                    <body>
                        <img src=""./logo.png"" alt=""appetite-logo"">
                        <div class=""container"">
                            <div class=""inner-container"">
                                <div class=""top-container"">
                                    <h1>Password Reset</h1>
                                    <h3>If you've lost your password or wish to reset it, here is the code to identify it's you</h3>
                                </div>
                                <h1 id=""passcode"">code</h1>
                                <p>If you did not request a password reset, you can safely ignore this email. Only a person with access to your email can reset your account password</p>
                            </div>
                        </div>
                        <script>
                            function GenerateRandom(length){
                                return Math.floor(Math.pow(10, length-1) + Math.random() * 9 * Math.pow(10, length-1));
                            }
                            let code = document.getElementById(""passcode"");
                            code.innerHTML = GenerateRandom(8).toString();
                        </script>
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
