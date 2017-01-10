using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProjectIntercept.Lobby
{
    class Email
    {
        public static bool SendEmail(string pcid, string hwid, string email)
        {
            var theLink = string.Format("http://project-intercept.com/stable/verify.php?pcid={0}&hwid={1}&email={2}", pcid, hwid, email);
            var smtpClient = new SmtpClient();
            var message = new MailMessage();

            try
            {
                var fromAddress = new MailAddress("activation@project-intercept.com", "Project Intercept");
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 20000;
                smtpClient.Credentials = new System.Net.NetworkCredential("activation@project-intercept.com", "s4aWr32uru");

                message.From = fromAddress;

                message.To.Add(email);
                message.Subject = "Project Intercept | Activation";
                //message.CC.Add(cc);
                //message.Bcc.Add(bcc);
                //maybe change this later if we decide to send fancy emails
                message.IsBodyHtml = true;
                message.Body = "To activate your account please click the following link: <a href='" + theLink+"'>Activate Now!</a>";
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
