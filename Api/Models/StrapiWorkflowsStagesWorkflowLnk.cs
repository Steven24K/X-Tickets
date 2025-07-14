using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiWorkflowsStagesWorkflowLnk
{
    public int Id { get; set; }

    public int? WorkflowStageId { get; set; }

    public int? WorkflowId { get; set; }

    public double? WorkflowStageOrd { get; set; }

    public virtual StrapiWorkflow? Workflow { get; set; }

    public virtual StrapiWorkflowsStage? WorkflowStage { get; set; }
}
