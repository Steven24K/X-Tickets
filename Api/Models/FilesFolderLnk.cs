using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class FilesFolderLnk
{
    public int Id { get; set; }

    public int? FileId { get; set; }

    public int? FolderId { get; set; }

    public double? FileOrd { get; set; }

    public virtual StrapiFile? File { get; set; }

    public virtual UploadFolder? Folder { get; set; }
}
