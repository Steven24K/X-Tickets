using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ShopSettingValuesShopSettingLnk
{
    public int Id { get; set; }

    public int? ShopSettingValueId { get; set; }

    public int? ShopSettingId { get; set; }

    public double? ShopSettingValueOrd { get; set; }

    public virtual ShopSetting? ShopSetting { get; set; }

    public virtual ShopSettingValue? ShopSettingValue { get; set; }
}
