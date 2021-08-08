using System.Net.Mail;

namespace Blazor.Shared.Model
{
    public interface IEmail
    {
        Attachment Attachment { get; }
        MailAddressCollection BCC { get; }
        string Body { get; }
        MailAddressCollection CC { get; }
        string FromAddress { get; }
        string Subject { get; }
        MailAddressCollection ToAddress { get; }
    }
}