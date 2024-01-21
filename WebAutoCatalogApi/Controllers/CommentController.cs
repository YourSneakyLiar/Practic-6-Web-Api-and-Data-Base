using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {




        public AuotoCatologContext Context { get; }
        public CommentController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Comment> comm = new List<Comment>();
            return Ok(comm);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Comment? com = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (com == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(Comment com)
        {
            Context.Comments.Add(com);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(Comment com)
        {

            Context.Comments.Update(com);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Comment? com = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (com == null)
            {
                return BadRequest("Not Found");
            }

            Context.Comments.Remove(com);
            Context.SaveChanges();
            return Ok();
        }

















    }
}
