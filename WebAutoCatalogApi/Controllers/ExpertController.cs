using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {

        public AuotoCatologContext Context { get; }
        public ExpertController (AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Expert> exp = new List<Expert>();
            return Ok(exp);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Expert? exper = Context.Experts.Where(x => x.ExpertId == id).FirstOrDefault();
            if (exper == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(Expert exper)
        {
            Context.Experts.Add(exper);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(Expert exper)
        {

            Context.Experts.Update(exper);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Expert? exper = Context.Experts.Where(x => x.ExpertId == id).FirstOrDefault();
            if (exper == null)
            {
                return BadRequest("Not Found");
            }

            Context.Experts.Remove(exper);
            Context.SaveChanges();
            return Ok();
        }







    }
}
