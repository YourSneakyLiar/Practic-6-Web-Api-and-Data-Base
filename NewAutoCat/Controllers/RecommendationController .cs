using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Recommendation;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {



        public AuotoCatologContext Context { get; }
        public RecommendationController(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех рекомендаций
        /// </summary>
        /// <returns>Список всех рекомендаций</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Recommendation> rec = Context.Recommendations.ToList();
            return Ok(rec);
        }
        /// <summary>
        /// Получение рекомендации по ID
        /// </summary>
        /// <param name="id">ID рекомендации</param>
        /// <returns>Рекомендация с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Recommendation? recs = Context.Recommendations.Where(x => x.IdRec == id).FirstOrDefault();
            if (recs == null)
            {
                return BadRequest("Not Found");
            }

            var recsDto = recs.Adapt<Recommendation>();
            return Ok(recsDto);
        }

        /// <summary>
        /// Добавление новой рекомендации
        /// </summary>
        /// <param name="recs">Новая рекомендация</param>
        /// <returns>Результат добавления рекомендации</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRecomm request)
        {
            var recs = request.Adapt<Recommendation>();
            Context.Recommendations.Add(recs);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующей рекомендации
        /// </summary>
        /// <param name="recs">Рекомендация для обновления</param>
        /// <returns>Результат обновления рекомендации</returns>

        [HttpPut]
        public IActionResult Update(Recommendation recs)
        {

            Context.Recommendations.Update(recs);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление рекомендации по ID
        /// </summary>
        /// <param name="id">ID рекомендации</param>
        /// <returns>Результат удаления рекомендации</returns>

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            Recommendation? recs = Context.Recommendations.Where(x => x.IdRec == id).FirstOrDefault();
            if (recs == null)
            {
                return BadRequest("Not Found");
            }

            Context.Recommendations.Remove(recs);
            Context.SaveChanges();
            return Ok();
        }
    }
}
