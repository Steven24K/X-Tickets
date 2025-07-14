using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class UpUsersRoleLnk
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public double? UserOrd { get; set; }

    public virtual UpRole? Role { get; set; }

    public virtual UpUser? User { get; set; }
}
