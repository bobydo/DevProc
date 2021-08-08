using System;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using Blazor.Shared.Common;
using Blazor.Shared.Model;

namespace Blazor.Shared.Service
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void SendMail(Email _email)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_email.FromAddress);
                    foreach (MailAddress mailAddress in _email.ToAddress)
                        mail.To.Add(mailAddress);
                    foreach (MailAddress mailAddress in _email.CC)
                        mail.CC.Add(mailAddress);
                    foreach (MailAddress mailAddress in _email.BCC)
                        mail.Bcc.Add(mailAddress);
                    foreach (MailAddress mailAddress in _email.BCC)
                        mail.Bcc.Add(mailAddress);
                    if (_email.Attachment != null)
                        mail.Attachments.Add(_email.Attachment);
                    mail.Subject = _email.Subject;
                    mail.Body = _email.Body;
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient(_emailConfiguration.SmtpServer,
                        _emailConfiguration.SmtpPort))
                    {
                        smtp.Host = _emailConfiguration.SmtpServer;
                        smtp.Port = _emailConfiguration.SmtpPort;
                        smtp.UseDefaultCredentials = true;
                        //smtpClient.Timeout = 6000;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        if (_emailConfiguration.SmtpUsername?.Trim().Length > 0 &&
                           _emailConfiguration.SmtpPassword?.Trim().Length > 0)
                            smtp.Credentials = new System.Net.NetworkCredential(_emailConfiguration.SmtpUsername
                                , _emailConfiguration.SmtpPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("Some error occured while sending the email. {0}", ex.Message));
            }
        }
    }
}
