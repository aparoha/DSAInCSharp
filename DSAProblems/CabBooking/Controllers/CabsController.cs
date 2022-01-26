//using CabBooking.Database;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CabBooking.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class CabsController : ControllerBase
//    {
//        private readonly ILogger<CabsController> _logger;
//        private readonly CabsManager _cabsManager;

//        public CabsController(ILogger<CabsController> logger, CabsManager cabsManager)
//        {
//            _logger = logger;
//            _cabsManager = cabsManager;
//        }

//        [HttpGet]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            var rng = new Random();
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateTime.Now.AddDays(index),
//                TemperatureC = rng.Next(-20, 55),
//                Summary = Summaries[rng.Next(Summaries.Length)]
//            })
//            .ToArray();
//        }
//    }
//}
