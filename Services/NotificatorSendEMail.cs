using System;
using System.Collections.Generic;
using System.Linq;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using HealthMonitorService.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HealthMonitorServiceModels;


namespace HealthMonitorService.Services
{
    public class NotificatorSendEMail
    {
        ApplicationContext db;
        public NotificatorSendEMail(ApplicationContext context)
        {
            db = context;
        }

        //SendMessageByEMail eMailSender = new SendMessageByEMail();

        public async void SendEmail(int UnitID, int IncidentTypeID, string notificationText)
        {

            List<TableIncidentModeratorModel> moderatorList = new List<TableIncidentModeratorModel>();
            
            var incidentUnitName = db.Unit.FirstOrDefault(x => x.UnitID == UnitID).Name.ToString();
            var incidentTypeName = db.IncidentType.FirstOrDefault(x => x.IncidentTypeID == IncidentTypeID).IncidentTypeName.ToString();
            var incidentTypeNotificationText = db.IncidentType.FirstOrDefault(x => x.IncidentTypeID == IncidentTypeID).IncidentTypeNotificationText.ToString();
            
            var relationUnitModeratorList = db.RelationUnitModerator.Where(x => x.UnitID == UnitID).ToList();

            if (relationUnitModeratorList.Count > 0)
            {
                foreach (var row in relationUnitModeratorList)
                {
                    var moderator = db.IncidentModerator.FirstOrDefault(x => x.ModeratorID == row.ModeratorID);
                    moderatorList.Add(moderator);
                }
            }

            if (moderatorList.Count > 0)
            {
                foreach (var row in moderatorList)
                {
                    string moderatorEmailAddress = row.Email;
                    await SendEmailAsync(moderatorEmailAddress, incidentTypeNotificationText, incidentUnitName, notificationText);
                }
            }

            Console.WriteLine("SendEmail method was called");
        }



        private async Task SendEmailAsync(string email, string subject, string unitname, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Admin of Service", "a.mensh@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject + " == " + unitname;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("relay.mail.ru", 25, false);
                await client.AuthenticateAsync("a.mensh", "xxxxxxx");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }



    }
}
