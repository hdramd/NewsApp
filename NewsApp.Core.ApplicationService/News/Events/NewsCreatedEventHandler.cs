using Microsoft.Extensions.Logging;
using NewsApp.Core.Domain.News.Events;
using Zamin.Core.Contracts.ApplicationServices.Events;

namespace NewsApp.Core.ApplicationService.News.Events
{
    public class NewsCreatedEventHandler : IDomainEventHandler<NewsCreated>
    {
        private readonly ILogger<NewsCreatedEventHandler> _logger;
        public NewsCreatedEventHandler(ILogger<NewsCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(NewsCreated Event)
        {
            try
            {
                _logger.LogInformation("Handeled {Event} in NewsCreatedEventHandler", Event.GetType().Name);
                await Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }
    }
}
