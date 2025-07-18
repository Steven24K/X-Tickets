using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AdminUser
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? ResetPasswordToken { get; set; }

    public string? RegistrationToken { get; set; }

    public bool? IsActive { get; set; }

    public bool? Blocked { get; set; }

    public string? PreferedLanguage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual ICollection<AdminPermission> AdminPermissionCreatedBies { get; set; } = new List<AdminPermission>();

    public virtual ICollection<AdminPermission> AdminPermissionUpdatedBies { get; set; } = new List<AdminPermission>();

    public virtual ICollection<AdminRole> AdminRoleCreatedBies { get; set; } = new List<AdminRole>();

    public virtual ICollection<AdminRole> AdminRoleUpdatedBies { get; set; } = new List<AdminRole>();

    public virtual ICollection<AdminUsersRolesLnk> AdminUsersRolesLnks { get; set; } = new List<AdminUsersRolesLnk>();

    public virtual ICollection<ContactInfo> ContactInfoCreatedBies { get; set; } = new List<ContactInfo>();

    public virtual ICollection<ContactInfo> ContactInfoUpdatedBies { get; set; } = new List<ContactInfo>();

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<Customer> CustomerCreatedBies { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerUpdatedBies { get; set; } = new List<Customer>();

    public virtual ICollection<DiscountCode> DiscountCodeCreatedBies { get; set; } = new List<DiscountCode>();

    public virtual ICollection<DiscountCode> DiscountCodeUpdatedBies { get; set; } = new List<DiscountCode>();

    public virtual ICollection<Event> EventCreatedBies { get; set; } = new List<Event>();

    public virtual ICollection<EventDateTime> EventDateTimeCreatedBies { get; set; } = new List<EventDateTime>();

    public virtual ICollection<EventDateTime> EventDateTimeUpdatedBies { get; set; } = new List<EventDateTime>();

    public virtual ICollection<Event> EventUpdatedBies { get; set; } = new List<Event>();

    public virtual ICollection<StrapiFile> FileCreatedBies { get; set; } = new List<StrapiFile>();

    public virtual ICollection<StrapiFile> FileUpdatedBies { get; set; } = new List<StrapiFile>();

    public virtual ICollection<I18nLocale> I18nLocaleCreatedBies { get; set; } = new List<I18nLocale>();

    public virtual ICollection<I18nLocale> I18nLocaleUpdatedBies { get; set; } = new List<I18nLocale>();

    public virtual ICollection<AdminUser> InverseCreatedBy { get; set; } = new List<AdminUser>();

    public virtual ICollection<AdminUser> InverseUpdatedBy { get; set; } = new List<AdminUser>();

    public virtual ICollection<Order> OrderCreatedBies { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderUpdatedBies { get; set; } = new List<Order>();

    public virtual ICollection<Payment> PaymentCreatedBies { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentUpdatedBies { get; set; } = new List<Payment>();

    public virtual ICollection<ShopSetting> ShopSettingCreatedBies { get; set; } = new List<ShopSetting>();

    public virtual ICollection<ShopSetting> ShopSettingUpdatedBies { get; set; } = new List<ShopSetting>();

    public virtual ICollection<ShopSettingValue> ShopSettingValueCreatedBies { get; set; } = new List<ShopSettingValue>();

    public virtual ICollection<ShopSettingValue> ShopSettingValueUpdatedBies { get; set; } = new List<ShopSettingValue>();

    public virtual ICollection<StrapiApiToken> StrapiApiTokenCreatedBies { get; set; } = new List<StrapiApiToken>();

    public virtual ICollection<StrapiApiTokenPermission> StrapiApiTokenPermissionCreatedBies { get; set; } = new List<StrapiApiTokenPermission>();

    public virtual ICollection<StrapiApiTokenPermission> StrapiApiTokenPermissionUpdatedBies { get; set; } = new List<StrapiApiTokenPermission>();

    public virtual ICollection<StrapiApiToken> StrapiApiTokenUpdatedBies { get; set; } = new List<StrapiApiToken>();

    public virtual ICollection<StrapiHistoryVersion> StrapiHistoryVersions { get; set; } = new List<StrapiHistoryVersion>();

    public virtual ICollection<StrapiReleaseAction> StrapiReleaseActionCreatedBies { get; set; } = new List<StrapiReleaseAction>();

    public virtual ICollection<StrapiReleaseAction> StrapiReleaseActionUpdatedBies { get; set; } = new List<StrapiReleaseAction>();

    public virtual ICollection<StrapiRelease> StrapiReleaseCreatedBies { get; set; } = new List<StrapiRelease>();

    public virtual ICollection<StrapiRelease> StrapiReleaseUpdatedBies { get; set; } = new List<StrapiRelease>();

    public virtual ICollection<StrapiTransferToken> StrapiTransferTokenCreatedBies { get; set; } = new List<StrapiTransferToken>();

    public virtual ICollection<StrapiTransferTokenPermission> StrapiTransferTokenPermissionCreatedBies { get; set; } = new List<StrapiTransferTokenPermission>();

    public virtual ICollection<StrapiTransferTokenPermission> StrapiTransferTokenPermissionUpdatedBies { get; set; } = new List<StrapiTransferTokenPermission>();

    public virtual ICollection<StrapiTransferToken> StrapiTransferTokenUpdatedBies { get; set; } = new List<StrapiTransferToken>();

    public virtual ICollection<StrapiWorkflow> StrapiWorkflowCreatedBies { get; set; } = new List<StrapiWorkflow>();

    public virtual ICollection<StrapiWorkflow> StrapiWorkflowUpdatedBies { get; set; } = new List<StrapiWorkflow>();

    public virtual ICollection<StrapiWorkflowsStage> StrapiWorkflowsStageCreatedBies { get; set; } = new List<StrapiWorkflowsStage>();

    public virtual ICollection<StrapiWorkflowsStage> StrapiWorkflowsStageUpdatedBies { get; set; } = new List<StrapiWorkflowsStage>();

    public virtual ICollection<UpPermission> UpPermissionCreatedBies { get; set; } = new List<UpPermission>();

    public virtual ICollection<UpPermission> UpPermissionUpdatedBies { get; set; } = new List<UpPermission>();

    public virtual ICollection<UpRole> UpRoleCreatedBies { get; set; } = new List<UpRole>();

    public virtual ICollection<UpRole> UpRoleUpdatedBies { get; set; } = new List<UpRole>();

    public virtual ICollection<UpUser> UpUserCreatedBies { get; set; } = new List<UpUser>();

    public virtual ICollection<UpUser> UpUserUpdatedBies { get; set; } = new List<UpUser>();

    public virtual AdminUser? UpdatedBy { get; set; }

    public virtual ICollection<UploadFolder> UploadFolderCreatedBies { get; set; } = new List<UploadFolder>();

    public virtual ICollection<UploadFolder> UploadFolderUpdatedBies { get; set; } = new List<UploadFolder>();

    public virtual ICollection<Venue> VenueCreatedBies { get; set; } = new List<Venue>();

    public virtual ICollection<Venue> VenueUpdatedBies { get; set; } = new List<Venue>();
}
