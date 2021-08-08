using SwaggerUI.Domain.Common;
using SwaggerUI.Domain.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerUI.Service.Email
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public (bool, string) Send(EmailMessage emailMessage)
        {
            try
            {
                var smtpClient = new SmtpClient(_emailConfiguration.SmtpServer)
                {
                    Port = _emailConfiguration.SmtpPort,
                    UseDefaultCredentials = true,
                    Timeout = 6000
                    //EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailMessage.FromAddresses),
                    Subject = emailMessage.Subject,
                    Body = emailMessage.Body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(emailMessage.ToAddresses);
                if (emailMessage.CopyAddresses != null)
                    mailMessage.CC.Add(emailMessage.CopyAddresses);
                if (emailMessage.AttachmentFilename != null)
                {
                    string[] attachments = emailMessage.AttachmentFilename.Split(";");

                    foreach (var file in attachments)
                    {
                        var attachment = new Attachment(file);
                        mailMessage.Attachments.Add(attachment);
                    }
                }
                smtpClient.Send(mailMessage);
                return (true, ReturnCode.Success);
            }
            catch (Exception ex)
            {
                //log
                return (false, ReturnCode.Failure + ":" + ex.Message);
            }

        }

        //private (bool, string) AttachmentType(string attachment)
        //{
        //    switch (attachment)
        //    {
        //        case string a when a.Contains("jpb"): return (true,MediaTypeNames.Image.Jpeg);
        //        case string b when b.Contains("gif"): return (true, MediaTypeNames.Image.Gif);
        //        case string c when c.Contains("tiff"): return (true, MediaTypeNames.Image.Tiff);
        //        default: return (false, null);
        //    }
        //}
    }
}
