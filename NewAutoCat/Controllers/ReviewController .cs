using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Review;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
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

        /// <summary>
        /// Получение всех обзоров
        /// </summary>
        /// <returns>Список всех обзоров</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> rev = Context.Reviews.ToList();
            return Ok(rev);
        }


        /// <summary>
        /// Получение обзора по ID
        /// </summary>
        /// <param name="id">ID обзора</param>
        /// <returns>Обзор с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Review? revi = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (revi == null)
            {
                return BadRequest("Not Found");
            }

            var reviDto = revi.Adapt<Review>();
            return Ok(reviDto);
        }

        /// <summary>
        /// Добавление нового обзора
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Review
        ///     {
        ///        "ReviewId" : "1",
        ///        "ReviewText" : "Отличный автомобиль!",
        ///        "UserId" : "123",
        ///        "CarId" : "456",
        ///        "DateOfReview":"22.01.2024"
        ///     }
        ///
        /// </remarks>
        /// <param name="revi">Новый обзор</param>
        /// <returns>Результат добавления обзора</returns>
        /// 
        [HttpPost]
        public async Task <IActionResult> Add(CreateRev request)
        {
            var revi = request.Adapt<Review>();
            Context.Reviews.Add(revi);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующего обзора
        /// </summary>
        /// <param name="revi">Обзор для обновления</param>
        /// <returns>Результат обновления обзора</returns>

        [HttpPut]
        public IActionResult Update(Review revi)
        {

            Context.Reviews.Update(revi);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаление обзора по ID
        /// </summary>
        /// <param name="id">ID обзора</param>
        /// <returns>Результат удаления обзора</returns>


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
