using NewsApp.Endpoints.UI.Categories.Services;
using Refit;

namespace NewsApp.Endpoints.UI.Categories.Config
{
    public static class CategoryConfig
    {
        private const string BaseUrl = "http://localhost:5000/api";

        public static IServiceCollection AddCategoryConfig(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddRefitClient<ICategoryApi>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseUrl))
                    .SetHandlerLifetime(TimeSpan.FromMinutes(1));

            return services;
        }
    }
}
