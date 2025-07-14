using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class UploadFolder
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Name { get; set; }

    public int? PathId { get; set; }

    public string? Path { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<FilesFolderLnk> FilesFolderLnks { get; set; } = new List<FilesFolderLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }

    public virtual ICollection<UploadFoldersParentLnk> UploadFoldersParentLnkFolders { get; set; } = new List<UploadFoldersParentLnk>();

    public virtual ICollection<UploadFoldersParentLnk> UploadFoldersParentLnkInvFolders { get; set; } = new List<UploadFoldersParentLnk>();
}
