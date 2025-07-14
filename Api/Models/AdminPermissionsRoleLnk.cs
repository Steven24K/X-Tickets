using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AdminPermissionsRoleLnk
{
    public int Id { get; set; }

    public int? PermissionId { get; set; }

    public int? RoleId { get; set; }

    public double? PermissionOrd { get; set; }

    public virtual AdminPermission? Permission { get; set; }

    public virtual AdminRole? Role { get; set; }
}
