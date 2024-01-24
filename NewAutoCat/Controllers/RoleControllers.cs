using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.Role;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleControllers : ControllerBase
    {


        public AuotoCatologContext Context { get; }
        public RoleControllers(AuotoCatologContext context)
        {

            Context = context;
        }


        /// <summary>
        /// Получение всех ролей
        /// </summary>
        /// <returns>Список всех ролей</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserRole> roles = Context.UserRoles.ToList();
            return Ok(roles);
        }

        /// <summary>
        /// Получение роли по ID
        /// </summary>
        /// <param name="id">ID роли</param>
        /// <returns>Роль с указанным ID</returns>

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            UserRole? roles = Context.UserRoles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Not Found");
            }

            var roleDto = roles.Adapt<UserRole>();

            return Ok(roleDto);

            
        }

        /// <summary>
        /// Добавление новой роли
        /// </summary>
        ///  Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       
        ///        "name" : "Администратор",
        ///        "roleId":"6"
        ///        
        ///     }
        /// <param name="roles">Новая роль</param>
        /// <returns>Результат добавления роли</returns>

        [HttpPost]
        public IActionResult Add(CreateRoleRequestcs request)
        {
            var role = request.Adapt<UserRole>();
            Context.UserRoles.Add(role);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Обновление существующей роли
        /// </summary>
        /// <param name="roles">Роль для обновления</param>
        /// <returns>Результат обновления роли</returns>

        [HttpPut]
        public IActionResult Update(UserRole roles)
        {

            Context.UserRoles.Update(roles);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление роли по ID
        /// </summary>
        /// <param name="id">ID роли</param>
        /// <returns>Результат удаления роли</returns>

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            UserRole? roles = Context.UserRoles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Not Found");
            }

            Context.UserRoles.Remove(roles);
            Context.SaveChanges();
            return Ok();
        }





    }
}
