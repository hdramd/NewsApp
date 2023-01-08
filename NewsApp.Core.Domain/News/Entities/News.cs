using NewsApp.Core.Domain.News.Events;
using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.News.Entities
{
    public class News : AggregateRoot
    {
        #region Props
        public string Titr { get; private set; }
        public virtual IReadOnlyCollection<NewsCategoryMapping> NewsCategoryMappings { get; private set; }
        public virtual IReadOnlyCollection<NewsImageMapping> NewsImageMappings { get; private set; }
        #endregion

        #region Ctor
        private News()
        {

        }

        public News(string titr, long[] categoryIds, long[] imageIds)
        {
            Titr = titr;

            CreateNewsCategoryMapping(categoryIds);

            CreateNewsImageMapping(imageIds);

            AddEvent(new NewsCreated(BusinessId.Value.ToString(), titr, categoryIds.ToArray()));
        }
        #endregion

        #region Commands
        public static News Create(string titr, long[] categoryIds, long[] imageIds)
            => new(titr, categoryIds, imageIds);

        public void Update(string titr, long[] categoryIds, long[] imageIds)
        {
            Titr = titr;

            CreateNewsCategoryMapping(categoryIds);

            CreateNewsImageMapping(imageIds);
        }

        private void CreateNewsImageMapping(long[] imageIds)
            => NewsImageMappings = imageIds?.Select(NewsImageMapping.Create).ToList();

        private void CreateNewsCategoryMapping(long[] categoryIds)
            => NewsCategoryMappings = categoryIds.Select(NewsCategoryMapping.Create).ToList();

        #endregion
    }
}
