using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicController : ControllerBase
    {



        public AuotoCatologContext Context { get; }
        public CharacteristicController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Characteristic> chara = new List<Characteristic>();
            return Ok(chara);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Characteristic? charac = Context.Characteristics.Where(x => x.IdChar == id).FirstOrDefault();
            if (charac == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(Characteristic charac)
        {
            Context.Characteristics.Add(charac);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(Characteristic charac)
        {

            Context.Characteristics.Update(charac);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Characteristic? charac = Context.Characteristics.Where(x => x.IdChar == id).FirstOrDefault();
            if (charac == null)
            {
                return BadRequest("Not Found");
            }

            Context.Characteristics.Remove(charac);
            Context.SaveChanges();
            return Ok();
        }














    }
}
