namespace InspGraph.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public Task<ChartJson> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.Run(() => {
                var forecast = getForecast(startDate);
                return new ChartJson
                {
                    type = "bar",
                    data = new Data
                    {
                        labels = forecast.Select(x => x.Date.ToString("MMŒŽdd“ú")).ToArray(),
                        datasets = new Dataset[] {
                                Dataset.CreateBar("ÛŽ", forecast.Select(x => (double?)x.TemperatureC).ToArray() , "royalblue"),
                                Dataset.CreateBar("‰ØŽ", forecast.Select(x => (double?)x.TemperatureF).ToArray(), "darkblue"),
                            },
                    },
                    options = Options.Plain(),
                };
            });
        }

        private WeatherForecast[] getForecast(DateTime startDate)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
            }).ToArray();
        }
    }
}