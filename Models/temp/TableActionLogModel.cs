using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitorServiceModels
{
    //[Keyless]
    public class TableActionLogModel
    {

         [Key]
        public int  LogID { get; set; }
        public Guid IncidentID { get; set; }
        public int ActionID { get; set; }
        public int ActionStatus { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string LogMessage { get; set; }

    }
}
