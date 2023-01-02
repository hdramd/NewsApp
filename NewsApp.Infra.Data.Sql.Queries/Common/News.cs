namespace NewsApp.Infra.Data.Sql.Queries.Common
{
    public partial class News
    {
        public long Id { get; set; }
        public string Titr { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid BusinessId { get; set; }
    }
}
