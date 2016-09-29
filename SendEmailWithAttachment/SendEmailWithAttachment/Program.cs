using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailWithAttachment
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient mailer = new SmtpClient("192.168.10.121");
            mailer.Send("job@sample.com",
                "ypchin@yahoo.com", "Subject", "Body message");
            
            Attachment theFile = new Attachment(@"C:\Lab\demo.xlsx");
            MailMessage message = new MailMessage();
            message.Attachments.Add(theFile);
            message.From= new MailAddress("job@sample.com");
            message.To.Add(new MailAddress("junk@yahoo.com"));
            message.Subject="Your report is ready";
            message.Body = "Report is attached.";
            mailer.Send(message);



        }
    }
}
