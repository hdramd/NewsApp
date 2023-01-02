using NewsApp.Endpoints.Api;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.AddZaminSerilog(c =>
    {
        c.ApplicationName = "NewsApp";
        c.ServiceName = "NewsAppService";
        c.ServiceVersion = "1.0";
    }).ConfigureServices().ConfigurePipeline();
    app.Run();
});