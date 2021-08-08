//using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerUI.Domain.Email
{
    public class EmailMessage : IEmailMessage
    {
        [Key]
        public int EmailMessageId { get; set; }
        [Required]
        public string FromAddresses { get; set; }
        [Required]
        public string ToAddresses { get; set; }
        public string CopyAddresses { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        //Split file name by semicolon
        public string AttachmentFilename { get; set; }
    }
}
