using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorServiceModels
{
    public class TableIncidentTypeModel
    {

        [Key]
        public int IncidentTypeID { get; set; }
        public int IncidentTypeCategoryID { get; set; }
        public string IncidentTypeName { get; set; }
        public string IncidentTypeNotificationText { get; set; }
        public string Description { get; set; }

    }
}
