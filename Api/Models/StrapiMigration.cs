using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiMigration
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Time { get; set; }
}
