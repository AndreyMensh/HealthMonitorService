using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitorService.Services
{
    public class NotificatorSendSMS
    {
        public void SendSMS(int UnitID, int IncidentTypeID, string notificationText)
        {
            Console.WriteLine("SendSMS method was called");
        }
    }
}
