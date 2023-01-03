namespace NewsApp.Core.Contracts.Images.Queries.Models
{
	public class ImageDto
	{
		public long Id { get; set; }
		public Guid BusinessId { get; set; }
		public string Path { get; set; }
	}
}
