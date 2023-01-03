using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.News.Entities
{
	public class NewsCategoryMapping : Entity
	{
		public long NewsId { get; set; }
		public long CategoryId { get; set; }

		public virtual News News { get; set; }
	}
}
