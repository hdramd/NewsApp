namespace NewsApp.Core.Contracts.Categories.Queries.Models
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public string Name { get; set; }
    }
}
