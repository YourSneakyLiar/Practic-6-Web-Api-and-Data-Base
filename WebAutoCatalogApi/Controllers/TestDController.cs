using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDController : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public TestDController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<TestDrife> test = new List<TestDrife>();
            return Ok(test);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            TestDrife? testd = Context.TestDrives.Where(x => x.IdTest == id).FirstOrDefault();
            if (testd == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(TestDrife testd)
        {
            Context.TestDrives.Add(testd);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(TestDrife testd)
        {

            Context.TestDrives.Update(testd);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            TestDrife? testd = Context.TestDrives.Where(x => x.IdTest == id).FirstOrDefault();
            if (testd == null)
            {
                return BadRequest("Not Found");
            }


            Context.TestDrives.Remove(testd);
            Context.SaveChanges();
            return Ok();
        }




    }
}
