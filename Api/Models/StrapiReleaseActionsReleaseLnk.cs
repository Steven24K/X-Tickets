using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiReleaseActionsReleaseLnk
{
    public int Id { get; set; }

    public int? ReleaseActionId { get; set; }

    public int? ReleaseId { get; set; }

    public double? ReleaseActionOrd { get; set; }

    public virtual StrapiRelease? Release { get; set; }

    public virtual StrapiReleaseAction? ReleaseAction { get; set; }
}
