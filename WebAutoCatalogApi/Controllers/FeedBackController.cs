using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        public AuotoCatologContext Context { get; }
        public FeedBackController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<FeedBack> feedback = new List<FeedBack>();
            return Ok(feedback);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            FeedBack? feedBack = Context.FeedBacks.Where(x => x.FeedBackId == id).FirstOrDefault();
            if (feedBack== null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(FeedBack feedBack)
        {
            Context.FeedBacks.Add(feedBack);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(FeedBack feedBack)
        {

            Context.FeedBacks.Update(feedBack);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            FeedBack? feedBack = Context.FeedBacks.Where(x => x.FeedBackId == id).FirstOrDefault();
            if (feedBack == null)
            {
                return BadRequest("Not Found");
            }

            Context.FeedBacks.Remove(feedBack);
            Context.SaveChanges();
            return Ok();
        }





    }
}
