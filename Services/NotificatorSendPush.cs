using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitorService.Services
{
    public class NotificatorSendPush
    {
        public void SendPush(int UnitID, int IncidentTypeID, string notificationText)
        {
            Console.WriteLine("SendPush method was called");
        }
    }
}
