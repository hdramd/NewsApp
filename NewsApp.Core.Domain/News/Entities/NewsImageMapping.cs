using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.News.Entities
{
	public class NewsImageMapping : Entity
	{
		#region Props
		public long NewsId { get; private set; }
		public long ImageId { get; private set; }

		public virtual News News { get; private set; }
		#endregion

		#region Ctor
		private NewsImageMapping(long imageId)
		{
			ImageId = imageId;
		}
		#endregion

		#region Commands
		public static NewsImageMapping Create(long imageId) => new(imageId);
		#endregion
	}
}
