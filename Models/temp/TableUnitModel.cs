using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorServiceModels
{
    public class TableUnitModel
    {

        [Key]
        public int UnitID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int CategoryID { get; set; }
        public int StatusScoped { get; set; }
        public string Description { get; set; }

    }
}
