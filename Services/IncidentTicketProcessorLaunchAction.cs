using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using HealthMonitorService.Models.DataModels;

namespace HealthMonitorService.Services
{
    public class IncidentTicketProcessorLaunchAction
    {

        ApplicationContext db;

        public IncidentTicketProcessorLaunchAction(ApplicationContext context)
        {
            db = context;
        }

        public void LaunchAction(int UnitID, int IncidentTypeID, Guid IncidentID)
        {
            var actionList = db.Action.Where(x => x.UnitID == UnitID && x.IncidentTypeID == IncidentTypeID).OrderBy(x => x.ActionRange).ToList();

            if (actionList.Count > 0)
            {
                

                foreach (var row in actionList)
                {
                    var actionID = row.ActionID;
                    var notificationID = row.NotificationID;
                    var executionID = row.ExecutionID;
                    var repeatTimes = row.RepeatTimesCount;
                    var timeOut = row.RepeatTimeOut;
                    string logMethodName = "Unknow";

                    IncidentTicketProcessorCreateActionLog ActionLogger = new IncidentTicketProcessorCreateActionLog(db);

                        if (notificationID != 0 & executionID == 0) // launch Notificator
                        {
                            string notificationMethodName = db.Notification.FirstOrDefault(x => x.NotificationID == notificationID).MethodName.ToString();
                            logMethodName = notificationMethodName;
                            ActionLogger.CreateActionLog(IncidentID, actionID, logMethodName);
                            string notificationText = db.Notification.FirstOrDefault(x => x.NotificationID == notificationID).NotificationText.ToString();

                            Notificator notificator = new Notificator(db);

                            try {

                                switch (notificationMethodName)
                                {
                                    case "SendEmail":
                                        notificator.SendEmail(UnitID, IncidentTypeID, notificationText);
                                        break;
                                    case "SendSMS":
                                        notificator.SendSMS(UnitID, IncidentTypeID, notificationText);
                                        break;
                                    case "SendPush":
                                        notificator.SendPush(UnitID, IncidentTypeID, notificationText);
                                        break;
                                    default:
                                        break;
                                }

                                ActionLogger.UpdateActionLogSuccess(IncidentID, actionID);
                            }
                            catch {
                                ActionLogger.UpdateActionLogFailure(IncidentID, actionID);
                            }


                        }
                        else if (notificationID == 0 & executionID != 0) // launch Executor
                        {
                            string executionMethodName = db.Execution.FirstOrDefault(x => x.ExecutionID == executionID).MethodName.ToString();
                            logMethodName = executionMethodName;
                            ActionLogger.CreateActionLog(IncidentID, actionID, logMethodName);
                            
                            Executor executor = new Executor(db);

                            try {
                                switch (executionMethodName)
                                {
                                    case "StartServerProcess":
                                        executor.StartServerProcess();
                                        break;
                                    case "StopServerProcess":
                                        executor.StopServerProcess();
                                        break;
                                    case "StartService":
                                        //executor.StartService();
                                        break;
                                    case "StopService":
                                        //executor.StopService();
                                        break;
                                    case "UpdateIncidentTicket":
                                        executor.UpdateIncidentTicket();
                                        break;
                                    case "CloseIncidentTicket":
                                        executor.CloseIncidentTicket(IncidentID);
                                        break;
                                    default:
                                        break;
                                }

                                ActionLogger.UpdateActionLogSuccess(IncidentID, actionID);
                            }
                            catch {
                                ActionLogger.UpdateActionLogFailure(IncidentID, actionID);
                            }
                           
                        }
                        else  // launch Nothing
                        { }


                }

            }

        }
    }
}
