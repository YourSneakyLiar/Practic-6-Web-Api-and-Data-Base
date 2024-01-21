using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public RecommendationController (AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Recommendation> rec = new List<Recommendation>();
            return Ok(rec);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Recommendation? recs = Context.Recommendations.Where(x => x.IdRec == id).FirstOrDefault();
            if (recs == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(Recommendation recs)
        {
            Context.Recommendations.Add(recs);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(Recommendation recs)
        {

            Context.Recommendations.Update(recs);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            Recommendation? recs = Context.Recommendations.Where(x => x.IdRec == id).FirstOrDefault();
            if (recs == null)
            {
                return BadRequest("Not Found");
            }

            Context.Recommendations.Remove(recs);
            Context.SaveChanges();
            return Ok();
        }




    }
}
