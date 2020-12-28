using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorServiceModels
{
    public class TableIncidentModeratorModel
    {
        [Key]
        public int ModeratorID { get; set; }

        public string ModeratorLogin { get; set; }
        public string ModeratorPassword { get; set; }

        public string ModeratorName { get; set; }
        public string Email { get; set; }
        public string CellPhoneNumber { get; set; }
        public string PushID { get; set; }

        public int NotificationAccessTimeStartHour { get; set; }
        public int NotificationAccessTimeStopHour { get; set; }
        public string Description { get; set; }

    }
}
