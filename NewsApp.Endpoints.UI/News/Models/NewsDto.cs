namespace NewsApp.Endpoints.UI.News.Models
{
    public class NewsDto
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public string Titr { get; set; }
    }
}
