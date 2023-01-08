using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewsApp.Endpoints.UI;
using NewsApp.Endpoints.UI.Categories.Config;
using NewsApp.Endpoints.UI.News.Config;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddCategoryConfig();
builder.Services.AddNewsConfig();

await builder.Build().RunAsync();
