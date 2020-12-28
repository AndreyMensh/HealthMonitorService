using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorService.Models.DataModels;
using HealthMonitorServiceModels;

namespace HealthMonitorService.Services
{
    public class IncidentTicketProcessorCreateActionLog
    {

        ApplicationContext db;

        public IncidentTicketProcessorCreateActionLog(ApplicationContext context)
        {
            db = context;
        }

        public void CreateActionLog(Guid IncidentID, int ActionID, string MethodName)
        {
            var loggerIncidentID = IncidentID;
            var loggerActionID = ActionID;
            var loggerMethodName = MethodName;

                db.ActionLog.Add(new TableActionLogModel
                {
                    IncidentID = loggerIncidentID,
                    ActionID = loggerActionID,
                    ActionStatus = 0,
                    CreateDateTime = DateTime.Now,
                    LogMessage = loggerMethodName
                });
                db.SaveChanges();
        }

        public void UpdateActionLogSuccess(Guid IncidentID, int ActionID)
        {
            var currentLog = db.ActionLog.FirstOrDefault(x => x.IncidentID == IncidentID && x.ActionID == ActionID);
            currentLog.ActionStatus = 1;
            //db.SaveChangesAsync();
            db.SaveChanges();
        }

        public void UpdateActionLogFailure(Guid IncidentID, int ActionID)
        {
            var currentLog = db.ActionLog.FirstOrDefault(x => x.IncidentID == IncidentID && x.ActionID == ActionID);
            currentLog.ActionStatus = 2;
            //db.SaveChangesAsync();
            db.SaveChanges();
        }

    }
}
