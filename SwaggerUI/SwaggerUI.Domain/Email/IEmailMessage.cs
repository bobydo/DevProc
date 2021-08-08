//using MimeKit;
namespace SwaggerUI.Domain.Email
{
    public interface IEmailMessage
    {
        string AttachmentFilename { get; set; }
        string Body { get; set; }
        string CopyAddresses { get; set; }
        int EmailMessageId { get; set; }
        string FromAddresses { get; set; }
        string Subject { get; set; }
        string ToAddresses { get; set; }
    }
}