﻿using FluentGenerics.Api.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<WeatherForecastHandler>();
builder.Services.AddScoped<CityForecastHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast",
	async (WeatherForecastHandler handler, CancellationToken ct) =>
		await handler.ExecuteAsync(ct))
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/city-weatherforecast/{city}",
	async (string city, CityForecastHandler handler, CancellationToken ct) =>
		await handler.ExecuteAsync(city, ct))
.WithName("GetCityForecast")
.WithOpenApi();

app.Run();
