namespace NewsApp.Core.Contracts.News.Queries.Models
{
	public class NewsDto
	{
		public long Id { get; set; }
		public Guid BusinessId { get; set; }
		public string Titr { get; set; }
	}
}
