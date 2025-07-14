using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ShopSetting
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? OptionName { get; set; }

    public bool? IsNumber { get; set; }

    public string? OptionValue { get; set; }

    public int? NumericOption { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<UpUsersSettingLnk> UpUsersSettingLnks { get; set; } = new List<UpUsersSettingLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
