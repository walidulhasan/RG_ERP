using Microsoft.AspNetCore.Http;
using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace RG.Application.Common.Models
{
    public class EmailMessage
    {
        public List<MailboxAddress> To { get; set; } = new List<MailboxAddress>();
        public List<MailboxAddress> Cc { get; set; } = new List<MailboxAddress>();
        public List<MailboxAddress> BCc { get; set; } = new List<MailboxAddress>();
        public string Subject { get; set; }
        public string Content { get; set; }
        public EmailMessage(string subject, string content, List<string> to, List<string> _cc, List<string> _bcc)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(s => new MailboxAddress(s.Trim())));

            if (_cc != null && _cc.Count > 0)
            {
                foreach (var c in _cc)
                {
                    if (!string.IsNullOrEmpty(c) && !string.IsNullOrWhiteSpace(c))
                    {
                        Cc.Add(new MailboxAddress(c.Trim()));
                    }

                }
            }

            if (_bcc != null && _bcc.Count > 0)
            {
                foreach (var bc in _bcc)
                {
                    if (!string.IsNullOrEmpty(bc) && !string.IsNullOrWhiteSpace(bc))
                    {
                        BCc.Add(new MailboxAddress(bc.Trim()));
                    }
                }
            }

            Subject = subject;
            Content = content;
        }

    }


    public class EmailMessageAttachment : EmailMessage
    {

        public IFormFileCollection Attachment { get; set; }

        public EmailMessageAttachment(string subject, string content, List<string> to)
    : base(subject, content, to, new List<string>(), new List<string>())
        {
            Attachment = null;
        }
        public EmailMessageAttachment(string subject, string content, List<string> to, List<string> cc)
        : base(subject, content, to, cc, new List<string>())
        {
            Attachment = null;
        }
        public EmailMessageAttachment(string subject, string content, List<string> to, List<string> cc, List<string> bcc)
          : base(subject, content, to, cc, bcc)
        {
            Attachment = null;
        }

        public EmailMessageAttachment(string subject, string content, List<string> to, List<string> cc, List<string> bcc, IFormFileCollection attachment = null)
            : base(subject, content, to, cc, bcc)
        {
            Attachment = attachment;
        }


    }


}
