using MailKit.Net.Smtp;
using MimeKit;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.WEB.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmailAsync(EmailMessageAttachment message)
        {
            var mailMessage = GenerateEmailMessage(message);

            using (var client = new SmtpClient())
            {
                try
                {
                    var port = StaticConfigs.GetConfig("Port");

                    var SmtpServer = StaticConfigs.GetConfig("SmtpServer");

                    await client.ConnectAsync(SmtpServer, Convert.ToInt32(port), false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(StaticConfigs.GetConfig("MailUsername"), StaticConfigs.GetConfig("MailPassword"));
                    await client.SendAsync(mailMessage);
                }
                catch (Exception e)
                {
                    throw new Exception("Mail is not configuration");
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }


        private MimeMessage GenerateEmailMessage(EmailMessageAttachment message)
        {
            /*
                 "MailFrom": "erpMail@outlook.com",
    "SmtpServer": "smtp.office365.com",
    "Port": 587,
    "MailUsername": "codemazetest@gmail.com",
    "MailPassword": "our test password"
             */
            var senderEmail = new MimeMessage();
            var mailFrom = StaticConfigs.GetConfig("MailFrom");
            senderEmail.From.Add(new MailboxAddress(Encoding.UTF8, "Robintex ERP", mailFrom));
            senderEmail.To.AddRange(message.To);

            if (message.Cc != null && message.Cc.Count > 0)
            {
                senderEmail.Cc.AddRange(message.Cc);
            }

            if (message.BCc != null && message.BCc.Count > 0)
            {
                senderEmail.Bcc.AddRange(message.BCc);
            }

            senderEmail.Subject = message.Subject;
            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format(message.Content) };

            if (message.Attachment != null && message.Attachment.Any())
            {
                byte[] fileByte;
                foreach (var attach in message.Attachment)
                {
                    using (var ms = new MemoryStream())
                    {
                        attach.CopyTo(ms);
                        fileByte = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attach.FileName, fileByte, ContentType.Parse(attach.ContentType));
                }
            }
            senderEmail.Body = bodyBuilder.ToMessageBody();
            return senderEmail;
        }
    }
}
