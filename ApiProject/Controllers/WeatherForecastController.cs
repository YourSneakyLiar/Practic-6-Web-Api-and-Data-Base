using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpGet("find-by-name")]
        public ActionResult<int> GetCountByName([FromQuery] string name)
        {
            return Summaries.Count(summary => summary == name);
        }



        [HttpGet("{index}")]
        public ActionResult<string> GetOne(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Невозможно ввести неверный индекс");
            }
            return Summaries[index];
        }


        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
            {
                return Ok(Summaries);
            }
            else if (sortStrategy == 1)
            {
                var sortedSummaries = Summaries.OrderBy(summary => summary).ToList();
                return Ok(sortedSummaries);
            }
            else if (sortStrategy == -1)
            {
                var sortedSummaries = Summaries.OrderByDescending(summary => summary).ToList();
                return Ok(sortedSummaries);
            }
            else
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }
        }




        [HttpPost]

        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(int index, string name) {


            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Невозможно ввести неверный индекс");
            }
            Summaries[index] = name;
            return Ok();
        
        }

        [HttpDelete]

        public IActionResult Delete(int index)
        {


            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Невозможно ввести неверный индекс");
            }


            Summaries.RemoveAt(index);
            return Ok();    

        }
    }
}