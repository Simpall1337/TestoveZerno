using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace TestZerno.Controllers
{
    [Route("viewtable3")]
    [ApiController]
    public class ViewTable3Controller : ControllerBase
    {
        [HttpPost]
        public IActionResult ViewTable()
        {
            using (var db = new DataBaseContext())
            {
                var query = db.table
                .GroupBy(entity => new
                {
                    entity.RecordDate,
                    entity.BranchId,
                    entity.CounterpartyId,
                    entity.CounterpartyName,
                    entity.ContactId,
                    entity.Product,
                    entity.Price,
                    entity.Process

                })
                .Select(group => new
                {
                    Id = group.Select(entity => entity.Id).FirstOrDefault(),
                    Category = group.Key,
                    Amount = group.Sum(entity => entity.Amount),
                    AvgWetness = group.Average(entity => entity.Wetness),
                    AvgGarbage = group.Average(entity => entity.Garbage),
                    Infection = group.Select(entity => entity.Infection).FirstOrDefault(),
                   
                });

                var result = query.ToList();
                return Ok(result);
               
            }


        }


    }
}
