using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorService.Models.DataModels;

namespace HealthMonitorService.Services
{
    public class Notificator
    {
        ApplicationContext db;
        public Notificator(ApplicationContext context)
        {
            db = context;
        }

        public void SendEmail(int UnitID, int IncidentTypeID, string notificationText)
        {
            NotificatorSendEMail notificator = new NotificatorSendEMail(db);
            notificator.SendEmail(UnitID, IncidentTypeID, notificationText);
        }

        public void SendSMS(int UnitID, int IncidentTypeID, string notificationText)
        {
            NotificatorSendSMS notificator = new NotificatorSendSMS();
            notificator.SendSMS(UnitID, IncidentTypeID, notificationText);
        }

        public void SendPush(int UnitID, int IncidentTypeID, string notificationText)
        {
            NotificatorSendPush notificator = new NotificatorSendPush();
            notificator.SendPush(UnitID, IncidentTypeID, notificationText);
        }

    }
}
