using System.Net.Mail;
using System.Net;

namespace BlazorApp1.Services
{
    public class EmailService
    {
        public void SendEmail(string recipientEmail, string subject, string htmlContent)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("testdemo3105@gmail.com", "nkdmsxugktlwkquu");

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("testdemo3105@gmail.com");
                    mailMessage.To.Add(recipientEmail);
                    mailMessage.Subject = subject;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = htmlContent;

                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log the error
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
