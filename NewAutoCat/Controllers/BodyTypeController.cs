using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.BodyType;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypeController : ControllerBase
    {





        public AuotoCatologContext Context { get; }
        public BodyTypeController(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех типов кузова
        /// </summary>
        /// <returns>Список всех типов кузова</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<BodyType> bodyTypes = Context.BodyTypes.ToList();
            return Ok(bodyTypes);
        }
        /// <summary>
        /// Получение типа кузова по ID
        /// </summary>
        /// <param name="id">ID типа кузова</param>
        /// <returns>Тип кузова с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            BodyType? bodytype = Context.BodyTypes.Where(x => x.BodyTypeId == id).FirstOrDefault();
            if (bodytype == null)
            {
                return BadRequest("Not Found");
            }

            var bodytypeDto = bodytype.Adapt<BodyType>();
            return Ok(bodytypeDto);
        }

        /// <summary>
        /// Добавление нового типа кузова
        /// </summary>
        /// <param name="bodytype">Новый тип кузова</param>
        /// <returns>Результат добавления типа кузова</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateBodyTypeRec request)
        {
            var bodytype = request.Adapt<BodyType>();
            Context.BodyTypes.Add(bodytype);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующего типа кузова
        /// </summary>
        /// <param name="bodytype">Тип кузова для обновления</param>
        /// <returns>Результат обновления типа кузова</returns>

        [HttpPut]
        public IActionResult Update(BodyType bodytype)
        {

            Context.BodyTypes.Update(bodytype);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление типа кузова по ID
        /// </summary>
        /// <param name="id">ID типа кузова</param>
        /// <returns>Результат удаления типа кузова</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BodyType? bodytype = Context.BodyTypes.Where(x => x.BodyTypeId == id).FirstOrDefault();
            if (bodytype == null)
            {
                return BadRequest("Not Found");
            }

            Context.BodyTypes.Remove(bodytype);
            Context.SaveChanges();
            return Ok();
        }

    }
}
