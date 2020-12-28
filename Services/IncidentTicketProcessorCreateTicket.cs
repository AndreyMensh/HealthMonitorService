using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorService.Models.DataModels;
using HealthMonitorServiceModels;

namespace HealthMonitorService.Services
{
    public class IncidentTicketProcessorCreateTicket
    {

        ApplicationContext db;

        public IncidentTicketProcessorCreateTicket(ApplicationContext context)
        {
            db = context;
        }

        public void CreateTicket(Guid IncidentID, int UnitID, int IncidentTypeID, string SecretCode)
        {
            var requestIncidentID = IncidentID;
            var requestUnitID = UnitID;
            // in future need to do checking UnitID in Unit table

            var requestIncidentTypeID = IncidentTypeID;
            // in future need to do checking IncidentTypeID in IncidentType table

            var requestSecretCode = SecretCode;

            if (requestSecretCode == "qwerty")
            {
                db.IncidentTicket.Add(new TableIncidentTicketModel
                {
                    IncidentID = requestIncidentID,
                    UnitID = requestUnitID,
                    IncidentTypeID = requestIncidentTypeID,
                    CreateDateTime = DateTime.Now,
                    TicketStatus = 0
                });
                db.SaveChanges();

            }
        }

    }
}
