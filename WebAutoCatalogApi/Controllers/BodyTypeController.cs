using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypeController : ControllerBase
    {




        public AuotoCatologContext Context { get; }
        public BodyTypeController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<BodyType> bodyTypes = new List<BodyType>();
            return Ok(bodyTypes);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            BodyType? bodytype = Context.BodyTypes.Where(x => x.BodyTypeId == id).FirstOrDefault();
            if (bodytype == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(BodyType bodytype)
        {
            Context.BodyTypes.Add(bodytype);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(BodyType bodytype)
        {

            Context.BodyTypes.Update(bodytype);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BodyType? bodytype = Context.BodyTypes.Where(x => x.BodyTypeId == id).FirstOrDefault();
            if (bodytype == null)
            {
                return BadRequest("Not Found");
            }

            Context.BodyTypes.Remove(bodytype);
            Context.SaveChanges();
            return Ok();
        }












    }
}
