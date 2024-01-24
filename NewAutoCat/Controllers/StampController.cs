using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Stamp;
using NewAutoCat.Contracts.User;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StampController : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public StampController(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех марок
        /// </summary>
        /// <returns>Список всех марок</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Stamp> stamps = Context.Stamps.ToList();
            return Ok(stamps);
        }
        /// <summary>
        /// Получение марки по ID
        /// </summary>
        /// <param name="id">ID марки</param>
        /// <returns>Марка с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Stamp? stamps = Context.Stamps.Where(x => x.StampId == id).FirstOrDefault();
            if (stamps == null)
            {
                return BadRequest("Not Found");
            }
            var stampDto = stamps.Adapt<Stamp>();
            return Ok(stampDto);
            
        }
        /// <summary>
        /// Добавление новой марки
        /// </summary>
        /// <param name="stamp">Новая марка</param>
        /// <returns>Результат добавления марки</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateStampRec request)
        {
            var stamp = request.Adapt<Stamp>();
            Context.Stamps.Add(stamp);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующей марки
        /// </summary>
        /// <param name="stamp">Марка для обновления</param>
        /// <returns>Результат обновления марки</returns>

        [HttpPut]
        public IActionResult Update(Stamp stamp)
        {

            Context.Stamps.Update(stamp);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаление марки по ID
        /// </summary>
        /// <param name="id">ID марки</param>
        /// <returns>Результат удаления марки</returns>
        /// 
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Stamp? stamps = Context.Stamps.Where(x => x.StampId == id).FirstOrDefault();
            if (stamps == null)
            {
                return BadRequest("Not Found");
            }
            Context.Stamps.Remove(stamps);
            Context.SaveChanges();
            return Ok();
        }
    }
}
