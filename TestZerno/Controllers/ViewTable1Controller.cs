using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestZerno.Controllers
{
    [Route("viewtable1")]
    [ApiController]
    public class ViewTable1Controller : ControllerBase
    {

        [HttpPost]
        public IActionResult ViewTable()
        {
            using (var db = new DataBaseContext())
            {
               var result =  db.table.ToList();

            return Ok(result);
            }

        }

    }
}
