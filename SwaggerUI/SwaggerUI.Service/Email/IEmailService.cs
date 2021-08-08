using SwaggerUI.Domain.Email;

namespace SwaggerUI.Service.Email
{
    public interface IEmailService
    {
        (bool, string) Send(EmailMessage emailMessage);
    }
}