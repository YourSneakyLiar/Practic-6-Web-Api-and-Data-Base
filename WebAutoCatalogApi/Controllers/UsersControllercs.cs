using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllercs : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public UsersControllercs(AuotoCatologContext context)
        {

            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = new List<User>();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public IActionResult GetById  (int id) {

            User? user = Context.Users.Where(x =>x.IdUser == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(); 
        }


        [HttpPost]
        public IActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(User user)
        {

            Context.Users.Update(user); 
            Context.SaveChanges();  
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x=>x.IdUser==id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }














    }
}
