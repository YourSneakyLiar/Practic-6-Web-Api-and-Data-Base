using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.User;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllercs : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public UsersControllercs(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }


        /// <summary>
        /// Получение пользователя по ID
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns>Пользователь с указанным ID</returns>
        /// 
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            User? user = Context.Users.Where(x => x.IdUser == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            var userDto = user.Adapt<User>();
            return Ok(userDto);


        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        
        ///        "password" : "!Pa$$word123@",
        ///        "nickname" : "Иван",
        ///        "email" : "Иванович@gmail.com",
        ///        "DateOfRegistration":"22.01.2024"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequestcs request)
        {

            var userDto = request.Adapt<User>();
            Context.Users.Add(userDto);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующего пользователя
        /// </summary>
        /// <param name="user">Пользователь для обновления</param>
        /// <returns>Результат обновления пользователя</returns>

        [HttpPut]
        public IActionResult Update(User user)
        {

            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление пользователя по ID
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns>Результат удаления пользователя</returns>
        /// 
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.IdUser == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }

    }
}
