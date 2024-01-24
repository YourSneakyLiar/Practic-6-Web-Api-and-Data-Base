using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Comment;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {



        public AuotoCatologContext Context { get; }
        public CommentController(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех комментариев
        /// </summary>
        /// <returns>Список всех комментариев</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Comment> comm = Context.Comments.ToList();
            return Ok(comm);
        }
        /// <summary>
        /// Получение комментария по ID
        /// </summary>
        /// <param name="id">ID комментария</param>
        /// <returns>Комментарий с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Comment? com = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (com == null)
            {
                return BadRequest("Not Found");
            }

            var comDto = com.Adapt<Comment>();
            return Ok(comDto);
        }

        /// <summary>
        /// Добавление нового комментария
        /// </summary>
        /// <param name="com">Новый комментарий</param>
        /// <returns>Результат добавления комментария</returns>
        [HttpPost]
        public async Task  <IActionResult> Add(CreateCommentRec request)
        {
            var com = request.Adapt<Comment>();
            Context.Comments.Add(com);
            await Context.SaveChangesAsync();
            return Ok();
        }



        /// <summary>
        /// Обновление существующего комментария
        /// </summary>
        /// <param name="com">Комментарий для обновления</param>
        /// <returns>Результат обновления комментария</returns>
        [HttpPut]
        public IActionResult Update(Comment com)
        {

            Context.Comments.Update(com);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление комментария по ID
        /// </summary>
        /// <param name="id">ID комментария</param>
        /// <returns>Результат удаления комментария</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Comment? com = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (com == null)
            {
                return BadRequest("Not Found");
            }

            Context.Comments.Remove(com);
            Context.SaveChanges();
            return Ok();
        }

    }
}
