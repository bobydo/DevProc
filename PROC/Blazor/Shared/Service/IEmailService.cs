using Blazor.Shared.Model;

namespace Blazor.Shared.Service
{
    public interface IEmailService
    {
        void SendMail(Email _email);
    }
}