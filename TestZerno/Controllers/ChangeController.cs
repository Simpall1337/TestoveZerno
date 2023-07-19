using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TestZerno.Controllers
{
    [Route("change")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Change(Models.Change change)
        {
            using (var db = new DataBaseContext())
            {
                var entity = db.table.Find(change.Id);

                entity.Amount = change.Amount;
                entity.Wetness = change.Wetness;
                entity.Garbage = change.Garbage;
                entity.Infection = change.Infection;
                db.SaveChanges();
                return Ok();

            }



        }





    }
}
