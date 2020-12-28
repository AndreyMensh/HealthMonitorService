using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorService.Models.DataModels;

namespace HealthMonitorService.Services
{
    public class IncidentTicketProcessor
    {
        ApplicationContext db;

        public IncidentTicketProcessor(ApplicationContext context)
        {
            db = context;
        }


        public async Task StartProcessor(int UnitID, int IncidentTypeID, string SecretCode)
        {

            Guid IncidentID = Guid.NewGuid();
            this.CreateTicket(IncidentID, UnitID, IncidentTypeID, SecretCode);
            this.LaunchAction(UnitID, IncidentTypeID, IncidentID);
            //this.CreateActionLog(IncidentID);
            //this.CloseTicket(IncidentID);


            //var ServiceTasks = new List<Task>();
            //ServiceTasks.Add(Task.Run(async () =>
            //{
            //    await this.CreateTicket(IncidentID,UnitID, IncidentTypeID, SecretCode);
            //}));
            //ServiceTasks.Add(Task.Run(async () =>
            //{
            //    await this.LaunchAction(UnitID, IncidentTypeID);
            //}));
            //ServiceTasks.Add(Task.Run(async () =>
            //{
            //    await this.CreateActionLog(IncidentID);
            //}));
            //ServiceTasks.Add(Task.Run(async () =>
            //{
            //    await this.CloseTicket(IncidentID);
            //}));
            //Task.WhenAll(ServiceTasks).GetAwaiter().GetResult();
        }


        public void CreateTicket(Guid IncidentID, int UnitID, int IncidentTypeID, string SecretCode)
        {
            IncidentTicketProcessorCreateTicket incidentTicketProcessor = new IncidentTicketProcessorCreateTicket(db);
            incidentTicketProcessor.CreateTicket( IncidentID,  UnitID, IncidentTypeID, SecretCode);
        }

        public void LaunchAction(int UnitID, int IncidentTypeID, Guid IncidentID)
        {
            IncidentTicketProcessorLaunchAction incidentTicketProcessor = new IncidentTicketProcessorLaunchAction(db);
            incidentTicketProcessor.LaunchAction(UnitID, IncidentTypeID, IncidentID);
        }
        
        //public void CreateActionLog(Guid IncidentID)
        //{
        //    IncidentTicketProcessorCreateActionLog incidentTicketProcessor = new IncidentTicketProcessorCreateActionLog();
        //    incidentTicketProcessor.CreateActionLog(IncidentID,);
        //}
        
        public void CloseTicket(Guid IncidentID)
        {
            IncidentTicketProcessorCloseTicket incidentTicketProcessor = new IncidentTicketProcessorCloseTicket();
            incidentTicketProcessor.CloseTicket(IncidentID);
        }

    }
}
