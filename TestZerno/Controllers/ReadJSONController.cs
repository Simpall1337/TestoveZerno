using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;

namespace TestZerno.Controllers
{
    [Route("readJSON")]// в swagger запускаємо ендпоінт /read
    [ApiController]
    public class ReadJSONController : ControllerBase
    {

        [HttpPost]
        public IActionResult read()
        {

            string json = System.IO.File.ReadAllText("C:\\Users\\sandu\\Desktop\\TaskIT\\grain.json");// вказуєм посилання на JSON файл
            List<Models.Table> people = JsonConvert.DeserializeObject<List<Models.Table>>(json);

            using (var context = new DataBaseContext())
            {
                foreach (var person in people)
                {
                    
                    var entity = new Models.Table
                    {
                        RecordDate = person.RecordDate,
                        BranchId = person.BranchId,
                        CropYear = person.CropYear,
                        CounterpartyId = person.CounterpartyId,
                        CounterpartyName = person.CounterpartyName,
                        ContactId = person.ContactId,
                        Product = person.Product,
                        Price = person.Price,
                        Amount = person.Amount,
                        Process = person.Process,
                        Wetness = person.Wetness,
                        Garbage = person.Garbage,
                        Infection = person.Infection,
                    };

                    context.table.Add(entity);
                }

                context.SaveChanges();
            }

            return Ok();
        }
    }
}
