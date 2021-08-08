using Blazor.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Blazor.Shared.Model
{
    public class Email : IEmail
    {

        private readonly string _fromAddress;

        private readonly string _subject;

        private readonly string _body;

        private readonly string _toAddress;
        private readonly string _cc;
        private readonly string _bcc;
        private readonly string _attachment;
        public Email(string fromAddress, string toAddress
            , string cc, string bcc
            , string subject
            , string attachment
            , string body)
        {
            _fromAddress = fromAddress;
            _toAddress = toAddress;
            _cc = cc;
            _bcc = bcc;
            _subject = subject;
            _attachment = attachment;
            _body = body;
        }

        public MailAddressCollection ToAddress
        {
            get
            {
                return getAddressCollection(_toAddress);
            }
        }
        public MailAddressCollection CC
        {
            get
            {
                return getAddressCollection(_cc);
            }
        }

        public MailAddressCollection BCC
        {
            get
            {
                return getAddressCollection(_bcc);
            }
        }
        public Attachment Attachment
        {
            get
            {
                return _attachment?.Trim().Length > 0 ? new Attachment(_attachment, MediaTypeNames.Application.Octet) : null;
            }
        }

        public string FromAddress => this._fromAddress;

        public string Subject => this._subject;

        public string Body => this._body;

        private MailAddressCollection getAddressCollection(string addresses, char splitter = ';')
        {
            string[] addressArray = addresses?.Split(splitter);
            MailAddressCollection addressCollection = new MailAddressCollection();
            foreach (string address in addressArray ?? Enumerable.Empty<string>())
            {
                if (RegexUtilities.IsValidEmail(address))
                    addressCollection.Add(new MailAddress(address));
                //else
                //    Log here?
            }
            return addressCollection;
        }

    }
}
