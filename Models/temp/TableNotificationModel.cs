using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorServiceModels
{
    public class TableNotificationModel
    {

        [Key]
        public int NotificationID { get; set; }
        public string NotificationName { get; set; }
        public string NotificationText { get; set; }
        public int NotificationAccessTimeStartHour { get; set; }
        public int NotificationAccessTimeStopHour { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }

    }
}
