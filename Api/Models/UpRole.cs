using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class UpRole
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<UpPermissionsRoleLnk> UpPermissionsRoleLnks { get; set; } = new List<UpPermissionsRoleLnk>();

    public virtual ICollection<UpUsersRoleLnk> UpUsersRoleLnks { get; set; } = new List<UpUsersRoleLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
