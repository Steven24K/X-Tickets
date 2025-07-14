using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class UpPermissionsRoleLnk
{
    public int Id { get; set; }

    public int? PermissionId { get; set; }

    public int? RoleId { get; set; }

    public double? PermissionOrd { get; set; }

    public virtual UpPermission? Permission { get; set; }

    public virtual UpRole? Role { get; set; }
}
