using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiWorkflowsStagesPermissionsLnk
{
    public int Id { get; set; }

    public int? WorkflowStageId { get; set; }

    public int? PermissionId { get; set; }

    public double? PermissionOrd { get; set; }

    public virtual AdminPermission? Permission { get; set; }

    public virtual StrapiWorkflowsStage? WorkflowStage { get; set; }
}
