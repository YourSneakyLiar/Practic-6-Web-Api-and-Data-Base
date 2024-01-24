using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.News;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

       



            public AuotoCatologContext Context { get; }
            public NewsController(AuotoCatologContext context)
            {

                Context = context;
            }
        /// <summary>
        /// Получение всех новостей
        /// </summary>
        /// <returns>Список всех новостей</returns>

        [HttpGet]
            public IActionResult GetAll()
            {
                List<News> news = Context.News.ToList();
            return Ok(news);
            }
        /// <summary>
        /// Получение новости по ID
        /// </summary>
        /// <param name="id">ID новости</param>
        /// <returns>Новость с указанным ID</returns>
        [HttpGet("{id}")]

            public IActionResult GetById(int id)
            {

                News? newss = Context.News.Where(x => x.IdNews == id).FirstOrDefault();
                if (newss == null)
                {
                    return BadRequest("Not Found");
                }

            var newssDto = newss.Adapt<News>();
            return Ok(newssDto);
            }

        /// <summary>
        /// Добавление новой новости
        /// </summary>
        /// <param name="newss">Новая новость</param>
        /// <returns>Результат добавления новости</returns>

        [HttpPost]
            public async Task<IActionResult> Add(CreateNews request)
            {
            var newss = request.Adapt<News>();
            Context.News.Add(newss);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующей новости
        /// </summary>
        /// <param name="newss">Новость для обновления</param>
        /// <returns>Результат обновления новости</returns>

        [HttpPut]
            public IActionResult Update(News newss)
            {

                Context.News.Update(newss);
                Context.SaveChanges();
                return Ok();
            }


        /// <summary>
        /// Удаление новости по ID
        /// </summary>
        /// <param name="id">ID новости</param>
        /// <returns>Результат удаления новости</returns>
        /// 

        [HttpDelete]
            public IActionResult Delete(int id)
            {

                News? newss = Context.News.Where(x => x.IdNews == id).FirstOrDefault();
                if (newss == null)
                {
                    return BadRequest("Not Found");
                }

                Context.News.Remove(newss);
                Context.SaveChanges();
                return Ok();
            }



    }
}

