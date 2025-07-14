using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiApiTokenPermissionsTokenLnk
{
    public int Id { get; set; }

    public int? ApiTokenPermissionId { get; set; }

    public int? ApiTokenId { get; set; }

    public double? ApiTokenPermissionOrd { get; set; }

    public virtual StrapiApiToken? ApiToken { get; set; }

    public virtual StrapiApiTokenPermission? ApiTokenPermission { get; set; }
}
