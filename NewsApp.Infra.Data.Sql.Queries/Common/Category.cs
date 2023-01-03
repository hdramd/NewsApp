using System;
using System.Collections.Generic;

namespace NewsApp.Infra.Data.Sql.Queries.Common;

public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public string ModifiedByUserId { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public Guid BusinessId { get; set; }

    public virtual ICollection<NewsCategoryMapping> NewsCategoryMappings { get; } = new List<NewsCategoryMapping>();
}
