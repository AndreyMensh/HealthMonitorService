using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorServiceModels
{
    public class TableIncidentTicketModel
    {

        [Key]
        public Guid IncidentID { get; set; }
        public int UnitID { get; set; }
        public int IncidentTypeID { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int TicketStatus { get; set; }


    }
}
