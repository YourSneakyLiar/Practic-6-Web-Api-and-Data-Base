using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Car;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
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

        /// <summary>
        /// Получение всех автомобилей
        /// </summary>
        /// <returns>Список всех автомобилей</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Car> cars = Context.Cars.ToList();
            return Ok(cars);
        }
        /// <summary>
        /// Получение автомобиля по ID
        /// </summary>
        /// <param name="id">ID автомобиля</param>
        /// <returns>Автомобиль с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Car? car = Context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            if (car == null)
            {
                return BadRequest("Not Found");
            }

            var carDto = car.Adapt<Car>();
            return Ok(carDto);
        }
        /// <summary>
        /// Добавление нового автомобиля
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Car
        ///     {
        ///        "CarId" : "456",
        ///        "CreatedBy" : "123",
        ///        "CreatedAt" : "22.01.2024",
        ///        "DeletedBy" : "789",
        ///        "DeletedAt" : "23.01.2024",
        ///        "IdChar" : "1",
        ///        "StampId" : "2",
        ///        "Model" : "Tesla Model S",
        ///        "DateOfRelease" : "24.01.2024",
        ///        "BodyTypeId" : "3"
        ///     }
        ///
        /// </remarks>
        /// <param name="car">Новый автомобиль</param>
        /// <returns>Результат добавления автомобиля</returns>

        [HttpPost]
        public async Task <IActionResult> Add(CreateCarRec request)
        {
            var car = request.Adapt<Car>();
            Context.Cars.Add(car);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующего автомобиля
        /// </summary>
        /// <param name="car">Автомобиль для обновления</param>
        /// <returns>Результат обновления автомобиля</returns>

        [HttpPut]
        public IActionResult Update(Car car)
        {

            Context.Cars.Update(car);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление автомобиля по ID
        /// </summary>
        /// <param name="id">ID автомобиля</param>
        /// <returns>Результат удаления автомобиля</returns>
        /// 
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
