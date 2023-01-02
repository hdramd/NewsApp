using Zamin.Core.Domain.Events;

namespace NewsApp.Core.Domain.News.Events
{
    public class NewsCreated : IDomainEvent
    {
        public string BusinessId { get; private set; }
        public string Titr { get; private set; }
        public long[] CategoryId { get; private set; }
        public NewsCreated(string businessId, string titr, long[] categoryId)
        {
            BusinessId = businessId;
            Titr = titr;
            CategoryId = categoryId;
        }
    }
}
