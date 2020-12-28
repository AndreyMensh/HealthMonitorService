using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorServiceModels
{
    public class TableExecutionModel
    {

        [Key]
        public int ExecutionID { get; set; }
        public string ExecutionName { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }

    }
}
