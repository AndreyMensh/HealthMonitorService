using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorService.Models.DataModels;

namespace HealthMonitorService.Services
{
    public class Executor
    {
        ApplicationContext db;
        public Executor(ApplicationContext context)
        {
            db = context;
        }

        public void StartServerProcess()
        {
            ExecutorStartServerProcess executor = new ExecutorStartServerProcess();
            executor.StartServerProcess();
        }

        public void StopServerProcess()
        {
            ExecutorStopServerProcess executor = new ExecutorStopServerProcess();
            executor.StopServerProcess();
        }

        public void UpdateIncidentTicket()
        {
            ExecutorUpdateIncidentTicket executor = new ExecutorUpdateIncidentTicket();
            executor.UpdateIncidentTicket();
        }

        public void CloseIncidentTicket(Guid IncidentID)
        {
            ExecutorCloseIncidentTicket executor = new ExecutorCloseIncidentTicket(db);
            executor.CloseIncidentTicket(IncidentID);
        }
    }
}
