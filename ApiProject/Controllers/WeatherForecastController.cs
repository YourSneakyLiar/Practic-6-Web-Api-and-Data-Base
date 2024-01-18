using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers

{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }



    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        public static List<WeatherData> weatherDatas = new() {
        
            new WeatherData() {Id = 1, Date ="18.01.2024", Degree = -17, Location ="������"},
            new WeatherData() {Id = 12, Date ="19.01.2024", Degree = -15, Location ="�����"},
            new WeatherData() {Id = 31, Date ="12.01.2024", Degree = -10, Location ="����"},
            new WeatherData() {Id = 11, Date ="13.01.2024", Degree = 10, Location ="���������"},
            new WeatherData() {Id = 2, Date ="11.01.2024", Degree = -12, Location ="�����-���������"},
            new WeatherData() {Id = 3, Date ="18.01.2024", Degree = -13, Location ="�������"},

        };
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }




        [HttpGet("{id}")]
        public IActionResult  GetById(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++){

                if (weatherDatas[i].Id == id)
                {

                    return Ok(weatherDatas[i]);
                }

            }
            return BadRequest();
        }


        [HttpGet]
        public List<WeatherData> GetAll()
        {
            return weatherDatas;
        }

        [HttpGet("{find-by-city}")]
        public IActionResult GetByCityName(string location) {

            var cityExists = weatherDatas.Any(data => data.Location == location);
            if (cityExists)
            {
                return Ok("������ � ��������� ������� ������� � ����� ������");
            }
            else
            {
                return BadRequest("������ � ��������� ������� �� ����������");
            }


        }



        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            if (data.Id < 0)
            {
                return BadRequest("Id �� ����� ���� ������ 0");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    return BadRequest("������ � ����� Id ��� ����");
                }
            }

            weatherDatas.Add(data);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(WeatherData data)
        {
            if (data.Id < 0)
            {
                return BadRequest("Id �� ����� ���� ������ 0");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    weatherDatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("����� ������ �� ����������");
        }


        [HttpDelete]

        public IActionResult Delete(int id)
        {

            if (id < 0)
            {
                return BadRequest("Id �� ����� ���� ������ 0");
            }


            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    weatherDatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("����� ������ �� ����������");


        }
    }
}