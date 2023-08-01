namespace FluentGenerics.Api.Handlers;

public class WeatherForecastHandler : Handler
	.WithoutRequest
	.WithResponse<WeatherForecast[]>
{
	public override Task<WeatherForecast[]> ExecuteAsync(CancellationToken ct = default)
	{
		var summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
			"Scorching"
		};

		var cities = new[]
		{
			"London", "Paris", "Berlin", "New York", "Tokyo", "Moscow", "Madrid", "Rome", "Athens",
			"Amsterdam"
		};

		var forecast = Enumerable.Range(1, 5).Select(index =>
			new WeatherForecast(
				DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				Random.Shared.Next(-20, 55),
				summaries[Random.Shared.Next(summaries.Length)],
				cities[Random.Shared.Next(cities.Length)]))
			.ToArray();

		return Task.FromResult(forecast);
	}
}
