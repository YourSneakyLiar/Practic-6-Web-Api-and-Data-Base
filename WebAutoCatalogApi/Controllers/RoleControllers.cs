using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleControllers : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public RoleControllers(AuotoCatologContext context)
        {

            Context = context;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserRole> roles = new List<UserRole>();
            return Ok(roles);
        }



        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            UserRole? roles = Context.UserRoles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }



        [HttpPost]
        public IActionResult Add(UserRole roles)
        {
            Context.UserRoles.Add(roles);
            Context.SaveChanges();
            return Ok();
        }
        



        [HttpPut]
        public IActionResult Update(UserRole roles)
        {

            Context.UserRoles.Update(roles);
            Context.SaveChanges();
            return Ok();
        }




        [HttpDelete]
        public IActionResult Delete(int id)
        {
            UserRole? roles = Context.UserRoles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Not Found");
            }

            Context.UserRoles.Remove(roles);
            Context.SaveChanges();
            return Ok();
        }






    }
}
