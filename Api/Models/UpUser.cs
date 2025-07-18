using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class UpUser
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Provider { get; set; }

    public string? Password { get; set; }

    public string? ResetPasswordToken { get; set; }

    public string? ConfirmationToken { get; set; }

    public bool? Confirmed { get; set; }

    public bool? Blocked { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public string? Slug { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<EventsOwnerLnk> EventsOwnerLnks { get; set; } = new List<EventsOwnerLnk>();

    public virtual ICollection<ShopSettingValuesOwnerLnk> ShopSettingValuesOwnerLnks { get; set; } = new List<ShopSettingValuesOwnerLnk>();

    public virtual ICollection<UpUsersRoleLnk> UpUsersRoleLnks { get; set; } = new List<UpUsersRoleLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
