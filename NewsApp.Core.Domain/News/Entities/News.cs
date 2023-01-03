using NewsApp.Core.Domain.News.Events;
using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.News.Entities
{
	public class News : AggregateRoot
	{
		#region Props
		public string Titr { get; private set; }
		public virtual ICollection<NewsCategoryMapping> NewsCategoryMappings { get; private set; }
		public virtual ICollection<NewsImageMapping> NewsImageMappings { get; private set; }
		#endregion

		#region Ctor
		private News()
		{

		}

		public News(string titr, long[] categoryIds)
		{
			Titr = titr;
			NewsCategoryMappings = categoryIds.Select(catId => new NewsCategoryMapping
			{
				CategoryId = catId
			}).ToList();

			AddEvent(new NewsCreated(BusinessId.Value.ToString(), titr, categoryIds.ToArray()));
		}
		#endregion

		#region Commands
		public static News Create(string titr, long[] categoryIds) => new(titr, categoryIds);

		public void Update(string titr, List<long> categoryIds)
		{
			Titr = titr;

			NewsCategoryMappings = categoryIds.Select(catId => new NewsCategoryMapping
			{
				CategoryId = catId
			}).ToList();
		}
		#endregion
	}
}
