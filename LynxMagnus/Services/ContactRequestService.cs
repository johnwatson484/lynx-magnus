using LynxMagnus.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;

namespace LynxMagnus.Services
{
    public class ContactRequestService
    {
        internal void Send(ContactRequest request)
        {
            var username = ConfigurationManager.AppSettings["smtpUserName"];
            var password = ConfigurationManager.AppSettings["smtpPassword"];
            var host = ConfigurationManager.AppSettings["smtpHost"];
            var port = ConfigurationManager.AppSettings["smtpPort"];

            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient();
                        
            smtpServer.EnableSsl = true;
            smtpServer.Credentials = new System.Net.NetworkCredential(username, password);
            smtpServer.Host = host;
            smtpServer.Port = int.Parse(port);

            mail.IsBodyHtml = true;
            mail.From = new MailAddress(username);
            mail.To.Add(username);

            mail.Subject = "Lynx Magnus Enquiry - " + request.Name;
            
            mail.Body = Enrich(request);

            smtpServer.Send(mail);
        }

        internal string Enrich(ContactRequest request)
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.AddStyleAttribute("font-family", "Arial,'Segoe UI', Verdana, Helvetica, Sans-Serif");
                writer.AddStyleAttribute("font-size", "12");

                writer.RenderBeginTag(HtmlTextWriterTag.H4);
                writer.Write("Sender Details");
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write("Sender: {0}", request.Name);
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write("Email: {0}", request.Email);
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write("Sent: {0}", DateTime.UtcNow.ToLocalTime().ToShortDateString());
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.H4);
                writer.Write("Message");
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.Write(request.Message.Trim());
                writer.RenderEndTag();
            }

            return stringWriter.ToString();
        }
    }
}