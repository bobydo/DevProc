namespace SwaggerUI.Domain.Email
{
    public interface IEmailConfiguration
    {
        string AttachmentFolder { get; set; }
        int SmtpPort { get; set; }
        string SmtpServer { get; set; }
    }
}