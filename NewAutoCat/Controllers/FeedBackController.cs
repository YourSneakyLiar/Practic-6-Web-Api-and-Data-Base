using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.FeedBack;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
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

        /// <summary>
        /// Получение всех отзывов
        /// </summary>
        /// <returns>Список всех оценок</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<FeedBack> feedback = Context.FeedBacks.ToList();
            return Ok(feedback);
        }
        /// <summary>
        /// Получение отзыва по ID
        /// </summary>
        /// <param name="id">ID отзыва</param>
        /// <returns>Оценка с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            FeedBack? feedBack = Context.FeedBacks.Where(x => x.FeedBackId == id).FirstOrDefault();
            if (feedBack == null)
            {
                return BadRequest("Not Found");
            }

            var feedBackDto = feedBack.Adapt<FeedBack>();
            return Ok(feedBackDto);
        }

        /// <summary>
        /// Добавление нового отзыва
        /// </summary>
        /// <param name="feedBack">Новый отзыв</param>
        /// <returns>Результат добавления оценки</returns>
        [HttpPost]
        public async Task <IActionResult> Add(CreateFeedBack request)
        {
            var feedBack = request.Adapt<FeedBack>();
            Context.FeedBacks.Add(feedBack);
            await Context.SaveChangesAsync();
            return Ok();
        }



        /// <summary>
        /// Обновление существующего отзыва
        /// </summary>
        /// <param name="feedBack">Отзыв для обновления</param>
        /// <returns>Результат обновления оценки</returns>
        [HttpPut]
        public IActionResult Update(FeedBack feedBack)
        {

            Context.FeedBacks.Update(feedBack);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление отзыва по ID
        /// </summary>
        /// <param name="id">ID отзыва</param>
        /// <returns>Результат удаления оценки</returns>
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
