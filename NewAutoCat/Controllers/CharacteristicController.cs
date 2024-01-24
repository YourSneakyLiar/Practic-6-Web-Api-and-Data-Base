using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Characteristic;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicController : ControllerBase
    {





        public AuotoCatologContext Context { get; }
        public CharacteristicController(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех характеристик
        /// </summary>
        /// <returns>Список всех характеристик</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Characteristic> chara = Context.Characteristics.ToList();
            return Ok(chara);
        }
        /// <summary>
        /// Получение характеристики по ID
        /// </summary>
        /// <param name="id">ID характеристики</param>
        /// <returns>Характеристика с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Characteristic? charac = Context.Characteristics.Where(x => x.IdChar == id).FirstOrDefault();
            if (charac == null)
            {
                return BadRequest("Not Found");
            }

            var characDto = charac.Adapt<Characteristic>();
            return Ok(characDto);
        }

        /// <summary>
        /// Добавление новой характеристики
        /// </summary>
        /// <param name="charac">Новая характеристика</param>
        /// <returns>Результат добавления характеристики</returns>
        [HttpPost]
        public async Task <IActionResult> Add(CreateCharRec request)
        {
            var charac = request.Adapt<Characteristic>();
            Context.Characteristics.Add(charac);
            await Context.SaveChangesAsync();
            return Ok();
        }



        /// <summary>
        /// Обновление существующей характеристики
        /// </summary>
        /// <param name="charac">Характеристика для обновления</param>
        /// <returns>Результат обновления характеристики</returns>
        [HttpPut]
        public IActionResult Update(Characteristic charac)
        {

            Context.Characteristics.Update(charac);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление характеристики по ID
        /// </summary>
        /// <param name="id">ID характеристики</param>
        /// <returns>Результат удаления характеристики</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Characteristic? charac = Context.Characteristics.Where(x => x.IdChar == id).FirstOrDefault();
            if (charac == null)
            {
                return BadRequest("Not Found");
            }

            Context.Characteristics.Remove(charac);
            Context.SaveChanges();
            return Ok();
        }


    }
}
