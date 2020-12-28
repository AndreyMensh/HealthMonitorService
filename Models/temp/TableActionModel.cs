using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorServiceModels
{
    public class TableActionModel
    {

        [Key]
        public int ActionID { get; set; }
        public int UnitID { get; set; }
        public int IncidentTypeID { get; set; }
        public int  NotificationID { get; set; }
        public int ExecutionID { get; set; }
        public int RepeatTimesCount { get; set; }
        public int RepeatTimeOut { get; set; }
        public int ActionRange { get; set; }

    }
}
