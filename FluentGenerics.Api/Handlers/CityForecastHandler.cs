namespace FluentGenerics.Api.Handlers;

public class CityForecastHandler : Handler
	.WithRequest<string>
	.WithResponse<WeatherForecast[]>
{
	public override Task<WeatherForecast[]> ExecuteAsync(
		string city,
		CancellationToken ct = default)
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

		if (!cities.Contains(city))
		{
			throw new ArgumentException("City not found", nameof(city));
		}

		var forecast = Enumerable.Range(1, 5).Select(index =>
			new WeatherForecast(
				DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				Random.Shared.Next(-20, 55),
				summaries[Random.Shared.Next(summaries.Length)],
				city))
			.ToArray();

		return Task.FromResult(forecast);
	}
}
