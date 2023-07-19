using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestZerno.Models;

namespace TestZerno.Controllers
{
    [Route("delete")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpPost]
        public IActionResult delete(ID id)
        {
            using (var db = new DataBaseContext())
            {
                var entity = db.table.Find(id.Id);
                db.table.Remove(entity);
                db.SaveChanges();
                return Ok();
            }

        }

    }
}
