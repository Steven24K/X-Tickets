using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class UpUsersSettingLnk
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ShopSettingId { get; set; }

    public double? ShopSettingOrd { get; set; }

    public double? UserOrd { get; set; }

    public virtual ShopSetting? ShopSetting { get; set; }

    public virtual UpUser? User { get; set; }
}
