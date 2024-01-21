using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        public AuotoCatologContext Context { get; }
        public ReviewController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> rev = new List<Review>();
            return Ok(rev);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Review? revi = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (revi == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(Review revi)
        {
            Context.Reviews.Add(revi);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(Review revi)
        {

            Context.Reviews.Update(revi);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            Review? revi = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (revi == null)
            {
                return BadRequest("Not Found");
            }

            Context.Reviews.Remove(revi);
            Context.SaveChanges();
            return Ok();
        }




    }
}
