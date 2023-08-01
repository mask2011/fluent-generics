namespace FluentGenerics.Api.Handlers;

public class WeatherForecastHandler : Handler
	.WithoutRequest
	.WithResponse<WeatherForecast[]>
{
	public override Task<WeatherForecast[]> ExecuteAsync(CancellationToken ct = default)
	{
		var forecasts = Enumerable.Range(1, 5).Select(index =>
			new WeatherForecast(
				DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				Random.Shared.Next(-20, 55),
				Lookups.Summaries[Random.Shared.Next(Lookups.Summaries.Count)],
				Lookups.Cities[Random.Shared.Next(Lookups.Cities.Count)]))
			.ToArray();

		return Task.FromResult(forecasts);
	}
}
