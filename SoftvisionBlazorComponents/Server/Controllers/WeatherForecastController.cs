using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using SoftvisionBlazorComponents.Shared;

namespace SoftvisionBlazorComponents.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
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

		[HttpGet]
		public DataSourceResult<WeatherForecast> Get()
		{
			var query = Enumerable.Range(1, 20).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			});

			return new DataSourceResult<WeatherForecast>
			{
				Count = query.Count(),
				Items = query.ToArray()
			};
		}

        [HttpPost]
        public DataSourceResult<WeatherForecast> Read(DataSourceParameter parameter)
        {
            var query = Enumerable.Range(1, 20).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

            var count = query.Count();
            query = query
                .Skip((parameter.Page - 1) * parameter.PageSize)
                .Take(parameter.PageSize);

            return new DataSourceResult<WeatherForecast>
            {
                Count = count,
                Items = query.ToArray()
            };
        }
    }
}