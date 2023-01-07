using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.News.Entities
{
	public class NewsCategoryMapping : Entity
	{
		#region Props
		public long NewsId { get; private set; }
		public long CategoryId { get; private set; }

		public virtual News News { get; private set; }
		#endregion

		#region Ctor
		private NewsCategoryMapping(long categoryId)
		{
			CategoryId = categoryId;
		}
		#endregion

		#region Command
		public static NewsCategoryMapping Create(long categoryId) => new(categoryId); 
		#endregion
	}
}
