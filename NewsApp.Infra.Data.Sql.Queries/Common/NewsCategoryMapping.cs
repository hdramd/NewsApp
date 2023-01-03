using System;
using System.Collections.Generic;

namespace NewsApp.Infra.Data.Sql.Queries.Common;

public partial class NewsCategoryMapping
{
    public long Id { get; set; }

    public long NewsId { get; set; }

    public long CategoryId { get; set; }

    public string CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public string ModifiedByUserId { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public Guid BusinessId { get; set; }

    public virtual Category Category { get; set; }

    public virtual News News { get; set; }
}
