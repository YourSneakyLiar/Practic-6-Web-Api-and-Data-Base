using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAutoCat.Contracts.TestDrive;
using NewAutoCat.Models;

namespace NewAutoCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDController : ControllerBase
    {



        public AuotoCatologContext Context { get; }
        public TestDController(AuotoCatologContext context)
        {

            Context = context;
        }

        /// <summary>
        /// Получение всех тест-драйвов
        /// </summary>
        /// <returns>Список всех тест-драйвов</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TestDrife> test = Context.TestDrives.ToList();
            return Ok(test);
        }
        /// <summary>
        /// Получение тест-драйва по ID
        /// </summary>
        /// <param name="id">ID тест-драйва</param>
        /// <returns>Тест-драйв с указанным ID</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            TestDrife? testd = Context.TestDrives.Where(x => x.IdTest == id).FirstOrDefault();
            if (testd == null)
            {
                return BadRequest("Not Found");
            }

            var testdDto = testd.Adapt<TestDrife>();
            return Ok(testdDto);
        }


        /// <summary>
        /// Добавление нового тест-драйва
        /// </summary>
        /// <param name="testd">Новый тест-драйв</param>
        /// <returns>Результат добавления тест-драйва</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateTestRec request)
        {
            var testd = request.Adapt<TestDrife>();
            Context.TestDrives.Add(testd);
            await Context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Обновление существующего тест-драйва
        /// </summary>
        /// <param name="testd">Тест-драйв для обновления</param>
        /// <returns>Результат обновления тест-драйва</returns>

        [HttpPut]
        public IActionResult Update(TestDrife testd)
        {

            Context.TestDrives.Update(testd);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаление тест-драйва по ID
        /// </summary>
        /// <param name="id">ID тест-драйва</param>
        /// <returns>Результат удаления тест-драйва</returns>
        /// 
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            TestDrife? testd = Context.TestDrives.Where(x => x.IdTest == id).FirstOrDefault();
            if (testd == null)
            {
                return BadRequest("Not Found");
            }


            Context.TestDrives.Remove(testd);
            Context.SaveChanges();
            return Ok();
        }

    }
}
