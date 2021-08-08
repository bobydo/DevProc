using Blazor.Shared.Common;
using Blazor.Shared.Model;
using Blazor.Shared.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly EmailConfiguration _emailConfiguration;

        //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0
        //https://www.youtube.com/watch?v=M8tEubdQGP4
        public EmailController(ILogger<EmailController> logger
            , IOptions<EmailConfiguration> emailConfiguration
            )
        {
            this._logger = logger;
            this._emailConfiguration = emailConfiguration.Value;
        }

        //create your own catory
        //private readonly ILogger _Shenyilogger;
        //public EmailController(ILoggerFactory factory
        //, IOptions<EmailConfiguration> emailConfiguration
        //)
        //{
        //    this._Shenyilogger = factory.CreateLogger("ShenyiCatory");
        //    this._emailConfiguration = emailConfiguration.Value;
        //}


        [HttpGet]
        public Email Get()
        {
            try
            {
                Email email = new Email("","","","","","","");
                new EmailService(_emailConfiguration).SendMail(email);
                return email;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "there is exception on {Time}", DateTime.UtcNow);
                throw;
            }
        }
    }
}
