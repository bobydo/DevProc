using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SwaggerUI.Data;
using SwaggerUI.Domain.Email;
using SwaggerUI.Service.Email;

namespace SwaggerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailConfiguration _emailConfig;
        private IEmailService _emailService;
        public EmailController(IEmailConfiguration emailConfig, IEmailService emailService)
        {
            _emailConfig = emailConfig; _emailService = emailService;
        }

        /// <summary>
        /// Gets the list of all EmailMessages.
        /// https://localhost:44352/swagger/index.html
        /// enable-migrations -ContextProjectName SwaggerUI.Data -contexttypename SwaggerUI.Data.SwaggerUIContext -Verbose
        /// </summary>
        /// <returns>The list of EmailMessages.</returns>
        // GET: api/Email

        [HttpGet]
        public IEnumerable<EmailMessage> Get()
        {
            return GetEmails();
        }

        // GET: api/Email/1
        [HttpGet("{id}", Name = "Get")]
        public EmailMessage Get(int id)
        {
            return GetEmails().Find(e => e.EmailMessageId == id);
        }
 
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public (bool, string) Post([FromBody] EmailMessage email)
        {
            var emailMessages =
                new EmailMessage()
                {
                    EmailMessageId = 1,
                    ToAddresses = "sbao@mctwf.org",
                    FromAddresses = "sbao@mctwf.org",
                    CopyAddresses = "sbao@mctwf.org",
                    Subject = "Test Email 1",
                    Body = "Hello word1",
                    AttachmentFilename = "C:\\AppLogs\\PlanDesigner3Seasonal.json;C:\\Source\\database-objects\\Adhoc\\IGSR-12697-Diff_BasysDataIntegrationCheck_Claim.sql"
                };
            var returnValue = _emailService.Send(emailMessages);
            return returnValue;
        }

        // PUT: api/Email/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmailMessage email)
        {
            // Logic to update an Email record
        }

        // DELETE: api/Email/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #region Private

        private List<EmailMessage> GetEmails()
        {
            try
            {
                return new List<EmailMessage>()
                {
                    new EmailMessage()
                    {
                        EmailMessageId = 1,
                        ToAddresses = "test1@gmail.com;test2@gmail.com",
                        FromAddresses= "test3@hotmail.com;test4@hotmail.com",
                        CopyAddresses = "test5@hotmail.com;test6@hotmail.com",
                        Subject  = "Test Email 1",
                        Body  = "Hello word1",
                        AttachmentFilename = "file1;file2"
                    },
                    new EmailMessage()
                    {
                        EmailMessageId = 2,
                        ToAddresses = "mock1@gmail.com;mock2@gmail.com",
                        FromAddresses= "mock3@hotmail.com;mock4@hotmail.com",
                        CopyAddresses = "mock5@hotmail.com;mock6@hotmail.com",
                        Subject  = "Mock Email 1",
                        Body  = "Hello word2",
                        AttachmentFilename = "file3;file4"
                    }
                };
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
