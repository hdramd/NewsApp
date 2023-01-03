using System;
using System.Collections.Generic;

namespace NewsApp.Infra.Data.Sql.Queries.Common;

public partial class ParrotTranslation
{
    public long Id { get; set; }

    public Guid BusinessId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    public string Culture { get; set; }
}
