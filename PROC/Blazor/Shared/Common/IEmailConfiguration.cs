namespace Blazor.Shared.Common
{
    public interface IEmailConfiguration
    {
        string PopPassword { get; set; }
        int PopPort { get; set; }
        string PopServer { get; set; }
        string PopUsername { get; set; }
        string SmtpPassword { get; set; }
        int SmtpPort { get; set; }
        string SmtpServer { get; set; }
        string SmtpUsername { get; set; }
    }
}