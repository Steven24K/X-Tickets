﻿using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ShopSetting
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? SettingName { get; set; }

    public string? DisplayName { get; set; }

    public string? Description { get; set; }

    public string? DataType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<ShopSettingValuesShopSettingLnk> ShopSettingValuesShopSettingLnks { get; set; } = new List<ShopSettingValuesShopSettingLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
