using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitorServiceModels
{
    [Keyless]
    public class TableRelationUnitModeratorModel
    {
        public int UnitID { get; set; }
        public int ModeratorID { get; set; }
    }
}
