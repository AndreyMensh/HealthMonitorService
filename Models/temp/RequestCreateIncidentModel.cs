using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitorServiceModels
{
    public class RequestCreateIncidentModel
    {

        public RequestCreateIncidentModel()
        {
        }
        public int UnitID { get; set; }
        public int IncidentTypeID { get; set; }
        public string SecretCode { get; set; }
    }
}
