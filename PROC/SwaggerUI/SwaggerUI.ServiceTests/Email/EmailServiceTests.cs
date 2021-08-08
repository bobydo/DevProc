using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwaggerUI.Domain.Common;
using SwaggerUI.Domain.Email;
using SwaggerUI.Service.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerUI.Service.Email.Tests
{
    [TestClass()]
    public class EmailServiceTests
    {
        private IEmailConfiguration emailConfig;
        private EmailService emailService;
        [TestInitialize]
        public void Setup()
        {
            emailConfig = new EmailConfiguration();
            emailConfig.SmtpServer = "mail.mctwf.org";
            emailConfig.SmtpPort = 25;
            emailService = new EmailService(emailConfig);
        }
        [TestMethod()]
        public void SendTest()
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

            var returnValue = emailService.Send(emailMessages);
            Assert.IsTrue(returnValue.Item1);
            Assert.AreEqual(returnValue.Item2,ReturnCode.Success);
        }
    }
}