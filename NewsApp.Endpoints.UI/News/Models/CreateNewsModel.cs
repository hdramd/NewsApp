namespace NewsApp.Endpoints.UI.News.Models
{
    public class CreateNewsModel
    {
        public string Titr { get; set; }
        public long[] CategoryIds { get; set; }
        public long[] ImageIds { get; set; }
    }
}
