using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiTransferTokenPermissionsTokenLnk
{
    public int Id { get; set; }

    public int? TransferTokenPermissionId { get; set; }

    public int? TransferTokenId { get; set; }

    public double? TransferTokenPermissionOrd { get; set; }

    public virtual StrapiTransferToken? TransferToken { get; set; }

    public virtual StrapiTransferTokenPermission? TransferTokenPermission { get; set; }
}
