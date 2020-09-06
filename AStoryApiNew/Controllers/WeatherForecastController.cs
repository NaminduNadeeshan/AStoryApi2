using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Common;

namespace AStoryApiNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ICommonController<string>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public string DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Signup Users
        /// </summary>
        /// <param name="/signup"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("getAll")]
        public string GetAll()
        {
            return "Hellow";
        }

        public string GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public string UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
