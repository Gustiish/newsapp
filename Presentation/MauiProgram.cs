
using ApplicationLayer.Mapping;
using ApplicationLayer.Services;
using Domain.ApiHandling;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.ViewModels;
using Presentation.ViewModels.Details;
using Presentation.ViewModels.Filter;
using Presentation.ViewModels.MainDisplay;
using Presentation.Views.MainDisplay;
using webservice.Api;
using webservice.Service;

namespace Presentation;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>();

		builder.Configuration.AddJsonFile("appsettings.json");

		builder.Services.AddHttpClient<NewsHttpClient>();
		builder.Services.AddSingleton<ApplicationState>();
		builder.Services.AddScoped<IApiService, ApiService>();
		builder.Services.AddScoped<IArticlesService, ArticlesService>();
		builder.Services.AddScoped<ArticleToArticleDTOMapper>();
		builder.Services.AddSingleton<MainDisplay>();
		builder.Services.AddSingleton<MainDisplayViewModel>();
		builder.Services.AddScoped<ApplyFilterViewModel>();
		builder.Services.AddTransient<DetailsViewViewModel>();
				
		return builder.Build();
	}
}
