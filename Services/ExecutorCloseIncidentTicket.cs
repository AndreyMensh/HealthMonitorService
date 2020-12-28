using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorService.Models.DataModels;

namespace HealthMonitorService.Services
{
    public class ExecutorCloseIncidentTicket
    {
        ApplicationContext db;

        public ExecutorCloseIncidentTicket(ApplicationContext context)
        {
            db = context;
        }
        public void CloseIncidentTicket(Guid IncidentID)
        {

            var currentTicket = db.IncidentTicket.FirstOrDefault(x => x.IncidentID == IncidentID);
            currentTicket.TicketStatus = 1;
            //db.SaveChangesAsync();
            db.SaveChanges();
            

            Console.WriteLine("CloseIncidentTicket method was called");
        }
    }
}
