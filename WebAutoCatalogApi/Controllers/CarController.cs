using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutoCatalogApi.Models;

namespace WebAutoCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public CarController(AuotoCatologContext context)
        {

            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Car> cars = new List<Car>();
            return Ok(cars);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Car? car = Context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            if (car == null)
            {
                return BadRequest("Not Found");
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult Add(Car car)
        {
            Context.Cars.Add(car);
            Context.SaveChanges();
            return Ok();
        }




        [HttpPut]
        public IActionResult Update(Car car)
        {

            Context.Cars.Update(car);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Car? car = Context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            if (car == null)
            {
                return BadRequest("Not Found");
            }

            Context.Cars.Remove(car);
            Context.SaveChanges();
            return Ok();
        }

















    }
}
