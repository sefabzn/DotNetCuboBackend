using Core.Entities.Concrete;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Mailing
{
    public class MailManager : IMailService
    {
        public void SendMail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("admin", "sefatestingtest@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress(mailRequest.ReceiverName, mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject = mailRequest.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("sefatestingtest@gmail.com", "dtjrdmjqpvpzdonc");
            client.Send(mimeMessage);
            client.Disconnect(true);

        }
    }
}
