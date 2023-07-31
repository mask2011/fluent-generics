using FluentGenerics.Api.HandlerGenerics;

namespace FluentGenerics.Api;

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

		var forecast = Enumerable.Range(1, 5).Select(index =>
			new WeatherForecast(
				DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				Random.Shared.Next(-20, 55),
				summaries[Random.Shared.Next(summaries.Length)]))
			.ToArray();

		return Task.FromResult(forecast);
	}
}
