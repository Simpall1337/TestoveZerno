using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TestZerno.Controllers
{
    [Route("viewtable2")]
    [ApiController]
    public class ViewTable2Controller : ControllerBase
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
                    entity.CropYear,
                    entity.CounterpartyId,
                    entity.CounterpartyName,
                    entity.ContactId,
                    entity.Product,
                    entity.Price,
                    entity.Process,
                    entity.Wetness,
                    entity.Garbage,
                    entity.Infection

                })
                .Select(group => new
                {
                    Id = group.Select(entity => entity.Id).FirstOrDefault(),
                    Category = group.Key,
                    Amount = group.Sum(entity => entity.Amount),
                });

                var result = query.ToList();
                
               return Ok(result);
            }

        }





    }
}
