using NewsApp.Core.Contracts.Categories.Queries.Models;
using NewsApp.Core.Contracts.Images.Queries.Models;

namespace NewsApp.Core.Contracts.News.Queries.Models
{
	public class NewsDto
	{
		public long Id { get; set; }
		public Guid BusinessId { get; set; }
		public string Titr { get; set; }

		public string[] Categories { get; set; }
		public string[] Images { get; set; }
	}
}
