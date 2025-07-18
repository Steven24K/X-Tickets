using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ShopSettingValuesOwnerLnk
{
    public int Id { get; set; }

    public int? ShopSettingValueId { get; set; }

    public int? UserId { get; set; }

    public virtual ShopSettingValue? ShopSettingValue { get; set; }

    public virtual UpUser? User { get; set; }
}
