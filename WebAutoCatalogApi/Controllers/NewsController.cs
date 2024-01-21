using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public NewsController (AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<News> news = new List<News>();
            return Ok(news);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            News? newss = Context.News.Where(x => x.IdNews == id).FirstOrDefault();
            if (newss == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(News newss)
        {
            Context.News.Add(newss);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(News newss)
        {

            Context.News.Update(newss);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            News? newss = Context.News.Where(x => x.IdNews == id).FirstOrDefault();
            if (newss == null)
            {
                return BadRequest("Not Found");
            }

            Context.News.Remove(newss);
            Context.SaveChanges();
            return Ok();
        }







    }
}
