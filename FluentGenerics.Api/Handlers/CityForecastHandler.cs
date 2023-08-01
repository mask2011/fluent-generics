namespace FluentGenerics.Api.Handlers;

public class CityForecastHandler : Handler
	.WithRequest<string>
	.WithResponse<WeatherForecast[]>
{
	public override Task<WeatherForecast[]> ExecuteAsync(
		string city,
		CancellationToken ct = default)
	{
		if (!Lookups.Cities.Contains(city))
		{
			throw new ArgumentException("City not found", nameof(city));
		}

		var forecasts = Enumerable.Range(1, 5).Select(index =>
			new WeatherForecast(
				DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				Random.Shared.Next(-20, 55),
				Lookups.Summaries[Random.Shared.Next(Lookups.Summaries.Count)],
				city))
			.ToArray();

		return Task.FromResult(forecasts);
	}
}
