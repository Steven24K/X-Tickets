using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class UploadFoldersParentLnk
{
    public int Id { get; set; }

    public int? FolderId { get; set; }

    public int? InvFolderId { get; set; }

    public double? FolderOrd { get; set; }

    public virtual UploadFolder? Folder { get; set; }

    public virtual UploadFolder? InvFolder { get; set; }
}
