using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiFile
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Name { get; set; }

    public string? AlternativeText { get; set; }

    public string? Caption { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public string? Formats { get; set; }

    public string? Hash { get; set; }

    public string? Ext { get; set; }

    public string? Mime { get; set; }

    public decimal? Size { get; set; }

    public string? Url { get; set; }

    public string? PreviewUrl { get; set; }

    public string? Provider { get; set; }

    public string? ProviderMetadata { get; set; }

    public string? FolderPath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<FilesFolderLnk> FilesFolderLnks { get; set; } = new List<FilesFolderLnk>();

    public virtual ICollection<FilesRelatedMph> FilesRelatedMphs { get; set; } = new List<FilesRelatedMph>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
