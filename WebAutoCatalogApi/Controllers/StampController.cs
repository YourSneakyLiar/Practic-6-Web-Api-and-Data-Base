using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StampController : ControllerBase
    {
        public AuotoCatologContext Context { get; }
        public StampController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Stamp> stamps = new List<Stamp>();
            return Ok(stamps);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Stamp?stamps = Context.Stamps.Where(x => x.StampId == id).FirstOrDefault();
            if (stamps == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(Stamp stamp)
        {
            Context.Stamps.Add(stamp);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(Stamp stamp)
        {

            Context.Stamps.Update(stamp);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Stamp? stamps = Context.Stamps.Where(x => x.StampId == id).FirstOrDefault();
            if (stamps == null)
            {
                return BadRequest("Not Found");
            }
            Context.Stamps.Remove(stamps);
            Context.SaveChanges();
            return Ok();
        }



    }
}
