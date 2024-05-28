using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using NetflixCloneMAUI.Pages;
using NetflixCloneMAUI.Services;

namespace NetflixCloneMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddHttpClient(TmdbService.TmdbHttpClientName, HttpClient => HttpClient.BaseAddress = new Uri("https://api.themoviedb.org"));
            builder.Services.AddSingleton<TmdbService>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
