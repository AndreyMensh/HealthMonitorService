using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorService.Models;
using HealthMonitorService.Models.DataModels;
using HealthMonitorService.Services;
using HealthMonitorServiceModels;

//using HealthMonitorModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthMonitorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateIncidentController : ControllerBase
    {

        ApplicationContext db;
        

        public CreateIncidentController(ApplicationContext context)
        {
            db = context;

            if (!db.Unit.Any())
            {
                //db.TaskRecord.Add(new ApiTaskRecordModel { TaskId = Guid.NewGuid(), RequestBody = "RequestBody1", CallBackStatusCounter = 1 });
                //db.TaskRecord.Add(new ApiTaskRecordModel { TaskId = Guid.NewGuid(), RequestBody = "RequestBody2", CallBackStatusCounter = 0 });
                //db.SaveChanges();
            }
            
        }


        // GET: api/<CreateIncidentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CreateIncidentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }




        // POST api/<CreateIncidentController>
        [HttpPost]
        public async void Post([FromBody] RequestCreateIncidentModel requestModel)
        {

            var requestUnitID = requestModel.UnitID;
            // in future need to do checking UnitID in Unit table

            var requestIncidentTypeID = requestModel.IncidentTypeID;
            // in future need to do checking IncidentTypeID in IncidentType table

            var requestSecretCode = requestModel.SecretCode;

            IncidentTicketProcessor incidentTicketProcessor = new IncidentTicketProcessor(db);
            await incidentTicketProcessor.StartProcessor(requestUnitID, requestIncidentTypeID, requestSecretCode);

        }





        // PUT api/<CreateIncidentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreateIncidentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
