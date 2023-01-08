using NewsApp.Endpoints.UI.News.Services;
using Refit;

namespace NewsApp.Endpoints.UI.News.Config
{
    public static class NewsConfig
    {
        private const string BaseUrl = "http://localhost:5000/api";

        public static IServiceCollection AddNewsConfig(this IServiceCollection services)
        {
            services.AddScoped<INewsService, NewsService>();

            services.AddRefitClient<INewsApi>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseUrl))
                    .SetHandlerLifetime(TimeSpan.FromMinutes(1));

            return services;
        }
    }
}
