namespace BlazorWithMvvm.Data
{
    public class WeatherForecastService
    {
        public WeatherForecastService()
        {
            
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<WeatherForecast>> GetForecastAsync(DateOnly startDate)
        {
            return await Task.Run(() =>
            {
                return Enumerable.Range(1, 100000).Select(index => new WeatherForecast
                {
                    Date = startDate.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            });
        }
    }
}
