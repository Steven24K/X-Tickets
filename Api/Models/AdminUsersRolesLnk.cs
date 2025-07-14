using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AdminUsersRolesLnk
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public double? RoleOrd { get; set; }

    public double? UserOrd { get; set; }

    public virtual AdminRole? Role { get; set; }

    public virtual AdminUser? User { get; set; }
}
