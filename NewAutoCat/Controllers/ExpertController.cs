using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Expert;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public ExpertController(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех экспертов
        /// </summary>
        /// <returns>Список всех экспертов</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Expert> exp = Context.Experts.ToList();
            return Ok(exp);
        }
        /// <summary>
        /// Получение эксперта по ID
        /// </summary>
        /// <param name="id">ID эксперта</param>
        /// <returns>Эксперт с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Expert? exper = Context.Experts.Where(x => x.ExpertId == id).FirstOrDefault();
            if (exper == null)
            {
                return BadRequest("Not Found");
            }

            var experDto = exper.Adapt<Expert>();
            return Ok(experDto);
        }

        /// <summary>
        /// Добавление нового эксперта
        /// </summary>
        /// <param name="exper">Новый эксперт</param>
        /// <returns>Результат добавления эксперта</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateExpert request)
        {
            var exper = request.Adapt<Expert>();
            Context.Experts.Add(exper);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующего эксперта
        /// </summary>
        /// <param name="exper">Эксперт для обновления</param>
        /// <returns>Результат обновления эксперта</returns>

        [HttpPut]
        public IActionResult Update(Expert exper)
        {

            Context.Experts.Update(exper);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление эксперта по ID
        /// </summary>
        /// <param name="id">ID эксперта</param>
        /// <returns>Результат удаления эксперта</returns>

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Expert? exper = Context.Experts.Where(x => x.ExpertId == id).FirstOrDefault();
            if (exper == null)
            {
                return BadRequest("Not Found");
            }

            Context.Experts.Remove(exper);
            Context.SaveChanges();
            return Ok();
        }


    }
}
