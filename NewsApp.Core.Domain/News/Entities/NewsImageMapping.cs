using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.News.Entities
{
	public class NewsImageMapping : Entity
	{
		public long NewsId { get; set; }
		public long ImageId { get; set; }

		public virtual News News { get; set; }
	}
}
