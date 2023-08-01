namespace FluentGenerics.Api;

public static class Lookups
{
	public static List<string> Summaries => new()
	{
		"Freezing",
		"Bracing",
		"Chilly",
		"Cool",
		"Mild",
		"Warm",
		"Balmy",
		"Hot",
		"Sweltering",
		"Scorching"
	};

	public static List<string> Cities => new()
	{
		"London",
		"Paris",
		"Berlin",
		"New York",
		"Tokyo",
		"Moscow",
		"Madrid",
		"Rome",
		"Athens",
		"Amsterdam"
	};
}
