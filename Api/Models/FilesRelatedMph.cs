using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class FilesRelatedMph
{
    public int Id { get; set; }

    public int? FileId { get; set; }

    public int? RelatedId { get; set; }

    public string? RelatedType { get; set; }

    public string? Field { get; set; }

    public double? Order { get; set; }

    public virtual StrapiFile? File { get; set; }
}
