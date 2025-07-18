using System;
using System.Collections.Generic;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DatabaseContext;

public partial class CmsXTicketsContext : DbContext
{
    public CmsXTicketsContext()
    {
    }

    public CmsXTicketsContext(DbContextOptions<CmsXTicketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminPermission> AdminPermissions { get; set; }

    public virtual DbSet<AdminPermissionsRoleLnk> AdminPermissionsRoleLnks { get; set; }

    public virtual DbSet<AdminRole> AdminRoles { get; set; }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<AdminUsersRolesLnk> AdminUsersRolesLnks { get; set; }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    public virtual DbSet<ContactInfosCustomersLnk> ContactInfosCustomersLnks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomersPrimaryContactLnk> CustomersPrimaryContactLnks { get; set; }

    public virtual DbSet<DiscountCode> DiscountCodes { get; set; }

    public virtual DbSet<DiscountCodesEventLnk> DiscountCodesEventLnks { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventDateTime> EventDateTimes { get; set; }

    public virtual DbSet<EventDateTimesEventLnk> EventDateTimesEventLnks { get; set; }

    public virtual DbSet<EventDateTimesVenueLnk> EventDateTimesVenueLnks { get; set; }

    public virtual DbSet<EventsOwnerLnk> EventsOwnerLnks { get; set; }

    public virtual DbSet<EventsSubEventsLnk> EventsSubEventsLnks { get; set; }

    public virtual DbSet<EventsVenueLnk> EventsVenueLnks { get; set; }

    public virtual DbSet<StrapiFile> Files { get; set; }

    public virtual DbSet<FilesFolderLnk> FilesFolderLnks { get; set; }

    public virtual DbSet<FilesRelatedMph> FilesRelatedMphs { get; set; }

    public virtual DbSet<I18nLocale> I18nLocales { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersCustomerLnk> OrdersCustomerLnks { get; set; }

    public virtual DbSet<OrdersEventDateTimeLnk> OrdersEventDateTimeLnks { get; set; }

    public virtual DbSet<OrdersPaymentLnk> OrdersPaymentLnks { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<ShopSetting> ShopSettings { get; set; }

    public virtual DbSet<ShopSettingValue> ShopSettingValues { get; set; }

    public virtual DbSet<ShopSettingValuesOwnerLnk> ShopSettingValuesOwnerLnks { get; set; }

    public virtual DbSet<ShopSettingValuesShopSettingLnk> ShopSettingValuesShopSettingLnks { get; set; }

    public virtual DbSet<StrapiApiToken> StrapiApiTokens { get; set; }

    public virtual DbSet<StrapiApiTokenPermission> StrapiApiTokenPermissions { get; set; }

    public virtual DbSet<StrapiApiTokenPermissionsTokenLnk> StrapiApiTokenPermissionsTokenLnks { get; set; }

    public virtual DbSet<StrapiCoreStoreSetting> StrapiCoreStoreSettings { get; set; }

    public virtual DbSet<StrapiDatabaseSchema> StrapiDatabaseSchemas { get; set; }

    public virtual DbSet<StrapiHistoryVersion> StrapiHistoryVersions { get; set; }

    public virtual DbSet<StrapiMigration> StrapiMigrations { get; set; }

    public virtual DbSet<StrapiMigrationsInternal> StrapiMigrationsInternals { get; set; }

    public virtual DbSet<StrapiRelease> StrapiReleases { get; set; }

    public virtual DbSet<StrapiReleaseAction> StrapiReleaseActions { get; set; }

    public virtual DbSet<StrapiReleaseActionsReleaseLnk> StrapiReleaseActionsReleaseLnks { get; set; }

    public virtual DbSet<StrapiTransferToken> StrapiTransferTokens { get; set; }

    public virtual DbSet<StrapiTransferTokenPermission> StrapiTransferTokenPermissions { get; set; }

    public virtual DbSet<StrapiTransferTokenPermissionsTokenLnk> StrapiTransferTokenPermissionsTokenLnks { get; set; }

    public virtual DbSet<StrapiWebhook> StrapiWebhooks { get; set; }

    public virtual DbSet<StrapiWorkflow> StrapiWorkflows { get; set; }

    public virtual DbSet<StrapiWorkflowsStage> StrapiWorkflowsStages { get; set; }

    public virtual DbSet<StrapiWorkflowsStageRequiredToPublishLnk> StrapiWorkflowsStageRequiredToPublishLnks { get; set; }

    public virtual DbSet<StrapiWorkflowsStagesPermissionsLnk> StrapiWorkflowsStagesPermissionsLnks { get; set; }

    public virtual DbSet<StrapiWorkflowsStagesWorkflowLnk> StrapiWorkflowsStagesWorkflowLnks { get; set; }

    public virtual DbSet<UpPermission> UpPermissions { get; set; }

    public virtual DbSet<UpPermissionsRoleLnk> UpPermissionsRoleLnks { get; set; }

    public virtual DbSet<UpRole> UpRoles { get; set; }

    public virtual DbSet<UpUser> UpUsers { get; set; }

    public virtual DbSet<UpUsersRoleLnk> UpUsersRoleLnks { get; set; }

    public virtual DbSet<UploadFolder> UploadFolders { get; set; }

    public virtual DbSet<UploadFoldersParentLnk> UploadFoldersParentLnks { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_permissions_pkey");

            entity.ToTable("admin_permissions");

            entity.HasIndex(e => e.CreatedById, "admin_permissions_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "admin_permissions_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "admin_permissions_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.ActionParameters)
                .HasColumnType("jsonb")
                .HasColumnName("action_parameters");
            entity.Property(e => e.Conditions)
                .HasColumnType("jsonb")
                .HasColumnName("conditions");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Properties)
                .HasColumnType("jsonb")
                .HasColumnName("properties");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.AdminPermissionCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("admin_permissions_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.AdminPermissionUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("admin_permissions_updated_by_id_fk");
        });

        modelBuilder.Entity<AdminPermissionsRoleLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_permissions_role_lnk_pkey");

            entity.ToTable("admin_permissions_role_lnk");

            entity.HasIndex(e => e.PermissionId, "admin_permissions_role_lnk_fk");

            entity.HasIndex(e => e.RoleId, "admin_permissions_role_lnk_ifk");

            entity.HasIndex(e => e.PermissionOrd, "admin_permissions_role_lnk_oifk");

            entity.HasIndex(e => new { e.PermissionId, e.RoleId }, "admin_permissions_role_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.PermissionOrd).HasColumnName("permission_ord");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AdminPermissionsRoleLnks)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("admin_permissions_role_lnk_fk");

            entity.HasOne(d => d.Role).WithMany(p => p.AdminPermissionsRoleLnks)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("admin_permissions_role_lnk_ifk");
        });

        modelBuilder.Entity<AdminRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_roles_pkey");

            entity.ToTable("admin_roles");

            entity.HasIndex(e => e.CreatedById, "admin_roles_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "admin_roles_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "admin_roles_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.AdminRoleCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("admin_roles_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.AdminRoleUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("admin_roles_updated_by_id_fk");
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_users_pkey");

            entity.ToTable("admin_users");

            entity.HasIndex(e => e.CreatedById, "admin_users_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "admin_users_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "admin_users_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Blocked).HasColumnName("blocked");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PreferedLanguage)
                .HasMaxLength(255)
                .HasColumnName("prefered_language");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.RegistrationToken)
                .HasMaxLength(255)
                .HasColumnName("registration_token");
            entity.Property(e => e.ResetPasswordToken)
                .HasMaxLength(255)
                .HasColumnName("reset_password_token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.InverseCreatedBy)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("admin_users_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.InverseUpdatedBy)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("admin_users_updated_by_id_fk");
        });

        modelBuilder.Entity<AdminUsersRolesLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_users_roles_lnk_pkey");

            entity.ToTable("admin_users_roles_lnk");

            entity.HasIndex(e => e.UserId, "admin_users_roles_lnk_fk");

            entity.HasIndex(e => e.RoleId, "admin_users_roles_lnk_ifk");

            entity.HasIndex(e => e.RoleOrd, "admin_users_roles_lnk_ofk");

            entity.HasIndex(e => e.UserOrd, "admin_users_roles_lnk_oifk");

            entity.HasIndex(e => new { e.UserId, e.RoleId }, "admin_users_roles_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleOrd).HasColumnName("role_ord");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserOrd).HasColumnName("user_ord");

            entity.HasOne(d => d.Role).WithMany(p => p.AdminUsersRolesLnks)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("admin_users_roles_lnk_ifk");

            entity.HasOne(d => d.User).WithMany(p => p.AdminUsersRolesLnks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("admin_users_roles_lnk_fk");
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_infos_pkey");

            entity.ToTable("contact_infos");

            entity.HasIndex(e => e.CreatedById, "contact_infos_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "contact_infos_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "contact_infos_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.ContactInfoCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("contact_infos_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.ContactInfoUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("contact_infos_updated_by_id_fk");
        });

        modelBuilder.Entity<ContactInfosCustomersLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_infos_customers_lnk_pkey");

            entity.ToTable("contact_infos_customers_lnk");

            entity.HasIndex(e => e.ContactInfoId, "contact_infos_customers_lnk_fk");

            entity.HasIndex(e => e.CustomerId, "contact_infos_customers_lnk_ifk");

            entity.HasIndex(e => e.CustomerOrd, "contact_infos_customers_lnk_ofk");

            entity.HasIndex(e => e.ContactInfoOrd, "contact_infos_customers_lnk_oifk");

            entity.HasIndex(e => new { e.ContactInfoId, e.CustomerId }, "contact_infos_customers_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactInfoId).HasColumnName("contact_info_id");
            entity.Property(e => e.ContactInfoOrd).HasColumnName("contact_info_ord");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerOrd).HasColumnName("customer_ord");

            entity.HasOne(d => d.ContactInfo).WithMany(p => p.ContactInfosCustomersLnks)
                .HasForeignKey(d => d.ContactInfoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("contact_infos_customers_lnk_fk");

            entity.HasOne(d => d.Customer).WithMany(p => p.ContactInfosCustomersLnks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("contact_infos_customers_lnk_ifk");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.HasIndex(e => e.CreatedById, "customers_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "customers_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "customers_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Insertion)
                .HasMaxLength(255)
                .HasColumnName("insertion");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.CustomerCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("customers_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.CustomerUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("customers_updated_by_id_fk");
        });

        modelBuilder.Entity<CustomersPrimaryContactLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_primary_contact_lnk_pkey");

            entity.ToTable("customers_primary_contact_lnk");

            entity.HasIndex(e => e.CustomerId, "customers_primary_contact_lnk_fk");

            entity.HasIndex(e => e.ContactInfoId, "customers_primary_contact_lnk_ifk");

            entity.HasIndex(e => new { e.CustomerId, e.ContactInfoId }, "customers_primary_contact_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactInfoId).HasColumnName("contact_info_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");

            entity.HasOne(d => d.ContactInfo).WithMany(p => p.CustomersPrimaryContactLnks)
                .HasForeignKey(d => d.ContactInfoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("customers_primary_contact_lnk_ifk");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomersPrimaryContactLnks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("customers_primary_contact_lnk_fk");
        });

        modelBuilder.Entity<DiscountCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discount_codes_pkey");

            entity.ToTable("discount_codes");

            entity.HasIndex(e => e.CreatedById, "discount_codes_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "discount_codes_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "discount_codes_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.TimesValid).HasColumnName("times_valid");
            entity.Property(e => e.TotalDiscountPercentage)
                .HasPrecision(10, 2)
                .HasColumnName("total_discount_percentage");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.DiscountCodeCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("discount_codes_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.DiscountCodeUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("discount_codes_updated_by_id_fk");
        });

        modelBuilder.Entity<DiscountCodesEventLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discount_codes_event_lnk_pkey");

            entity.ToTable("discount_codes_event_lnk");

            entity.HasIndex(e => e.DiscountCodeId, "discount_codes_event_lnk_fk");

            entity.HasIndex(e => e.EventId, "discount_codes_event_lnk_ifk");

            entity.HasIndex(e => new { e.DiscountCodeId, e.EventId }, "discount_codes_event_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiscountCodeId).HasColumnName("discount_code_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");

            entity.HasOne(d => d.DiscountCode).WithMany(p => p.DiscountCodesEventLnks)
                .HasForeignKey(d => d.DiscountCodeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("discount_codes_event_lnk_fk");

            entity.HasOne(d => d.Event).WithMany(p => p.DiscountCodesEventLnks)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("discount_codes_event_lnk_ifk");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.HasIndex(e => e.CreatedById, "events_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "events_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "events_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasColumnType("jsonb")
                .HasColumnName("description");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .HasColumnName("slug");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EventCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("events_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.EventUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("events_updated_by_id_fk");
        });

        modelBuilder.Entity<EventDateTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_date_times_pkey");

            entity.ToTable("event_date_times");

            entity.HasIndex(e => e.CreatedById, "event_date_times_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "event_date_times_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "event_date_times_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DateTime)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("date_time");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EventDateTimeCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_date_times_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.EventDateTimeUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_date_times_updated_by_id_fk");
        });

        modelBuilder.Entity<EventDateTimesEventLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_date_times_event_lnk_pkey");

            entity.ToTable("event_date_times_event_lnk");

            entity.HasIndex(e => e.EventDateTimeId, "event_date_times_event_lnk_fk");

            entity.HasIndex(e => e.EventId, "event_date_times_event_lnk_ifk");

            entity.HasIndex(e => e.EventDateTimeOrd, "event_date_times_event_lnk_oifk");

            entity.HasIndex(e => new { e.EventDateTimeId, e.EventId }, "event_date_times_event_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventDateTimeId).HasColumnName("event_date_time_id");
            entity.Property(e => e.EventDateTimeOrd).HasColumnName("event_date_time_ord");
            entity.Property(e => e.EventId).HasColumnName("event_id");

            entity.HasOne(d => d.EventDateTime).WithMany(p => p.EventDateTimesEventLnks)
                .HasForeignKey(d => d.EventDateTimeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_date_times_event_lnk_fk");

            entity.HasOne(d => d.Event).WithMany(p => p.EventDateTimesEventLnks)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_date_times_event_lnk_ifk");
        });

        modelBuilder.Entity<EventDateTimesVenueLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_date_times_venue_lnk_pkey");

            entity.ToTable("event_date_times_venue_lnk");

            entity.HasIndex(e => e.EventDateTimeId, "event_date_times_venue_lnk_fk");

            entity.HasIndex(e => e.VenueId, "event_date_times_venue_lnk_ifk");

            entity.HasIndex(e => new { e.EventDateTimeId, e.VenueId }, "event_date_times_venue_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventDateTimeId).HasColumnName("event_date_time_id");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.EventDateTime).WithMany(p => p.EventDateTimesVenueLnks)
                .HasForeignKey(d => d.EventDateTimeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_date_times_venue_lnk_fk");

            entity.HasOne(d => d.Venue).WithMany(p => p.EventDateTimesVenueLnks)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_date_times_venue_lnk_ifk");
        });

        modelBuilder.Entity<EventsOwnerLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_owner_lnk_pkey");

            entity.ToTable("events_owner_lnk");

            entity.HasIndex(e => e.EventId, "events_owner_lnk_fk");

            entity.HasIndex(e => e.UserId, "events_owner_lnk_ifk");

            entity.HasIndex(e => new { e.EventId, e.UserId }, "events_owner_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsOwnerLnks)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("events_owner_lnk_fk");

            entity.HasOne(d => d.User).WithMany(p => p.EventsOwnerLnks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("events_owner_lnk_ifk");
        });

        modelBuilder.Entity<EventsSubEventsLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_sub_events_lnk_pkey");

            entity.ToTable("events_sub_events_lnk");

            entity.HasIndex(e => e.EventId, "events_sub_events_lnk_fk");

            entity.HasIndex(e => e.InvEventId, "events_sub_events_lnk_ifk");

            entity.HasIndex(e => e.EventOrd, "events_sub_events_lnk_ofk");

            entity.HasIndex(e => new { e.EventId, e.InvEventId }, "events_sub_events_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventOrd).HasColumnName("event_ord");
            entity.Property(e => e.InvEventId).HasColumnName("inv_event_id");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsSubEventsLnkEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("events_sub_events_lnk_fk");

            entity.HasOne(d => d.InvEvent).WithMany(p => p.EventsSubEventsLnkInvEvents)
                .HasForeignKey(d => d.InvEventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("events_sub_events_lnk_ifk");
        });

        modelBuilder.Entity<EventsVenueLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_venue_lnk_pkey");

            entity.ToTable("events_venue_lnk");

            entity.HasIndex(e => e.EventId, "events_venue_lnk_fk");

            entity.HasIndex(e => e.VenueId, "events_venue_lnk_ifk");

            entity.HasIndex(e => new { e.EventId, e.VenueId }, "events_venue_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsVenueLnks)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("events_venue_lnk_fk");

            entity.HasOne(d => d.Venue).WithMany(p => p.EventsVenueLnks)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("events_venue_lnk_ifk");
        });

        modelBuilder.Entity<StrapiFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("files_pkey");

            entity.ToTable("files");

            entity.HasIndex(e => e.CreatedById, "files_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "files_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "files_updated_by_id_fk");

            entity.HasIndex(e => e.CreatedAt, "upload_files_created_at_index");

            entity.HasIndex(e => e.Ext, "upload_files_ext_index");

            entity.HasIndex(e => e.FolderPath, "upload_files_folder_path_index");

            entity.HasIndex(e => e.Name, "upload_files_name_index");

            entity.HasIndex(e => e.Size, "upload_files_size_index");

            entity.HasIndex(e => e.UpdatedAt, "upload_files_updated_at_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlternativeText)
                .HasMaxLength(255)
                .HasColumnName("alternative_text");
            entity.Property(e => e.Caption)
                .HasMaxLength(255)
                .HasColumnName("caption");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Ext)
                .HasMaxLength(255)
                .HasColumnName("ext");
            entity.Property(e => e.FolderPath)
                .HasMaxLength(255)
                .HasColumnName("folder_path");
            entity.Property(e => e.Formats)
                .HasColumnType("jsonb")
                .HasColumnName("formats");
            entity.Property(e => e.Hash)
                .HasMaxLength(255)
                .HasColumnName("hash");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Mime)
                .HasMaxLength(255)
                .HasColumnName("mime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PreviewUrl)
                .HasMaxLength(255)
                .HasColumnName("preview_url");
            entity.Property(e => e.Provider)
                .HasMaxLength(255)
                .HasColumnName("provider");
            entity.Property(e => e.ProviderMetadata)
                .HasColumnType("jsonb")
                .HasColumnName("provider_metadata");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Size)
                .HasPrecision(10, 2)
                .HasColumnName("size");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.FileCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("files_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.FileUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("files_updated_by_id_fk");
        });

        modelBuilder.Entity<FilesFolderLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("files_folder_lnk_pkey");

            entity.ToTable("files_folder_lnk");

            entity.HasIndex(e => e.FileId, "files_folder_lnk_fk");

            entity.HasIndex(e => e.FolderId, "files_folder_lnk_ifk");

            entity.HasIndex(e => e.FileOrd, "files_folder_lnk_oifk");

            entity.HasIndex(e => new { e.FileId, e.FolderId }, "files_folder_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.FileOrd).HasColumnName("file_ord");
            entity.Property(e => e.FolderId).HasColumnName("folder_id");

            entity.HasOne(d => d.File).WithMany(p => p.FilesFolderLnks)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("files_folder_lnk_fk");

            entity.HasOne(d => d.Folder).WithMany(p => p.FilesFolderLnks)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("files_folder_lnk_ifk");
        });

        modelBuilder.Entity<FilesRelatedMph>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("files_related_mph_pkey");

            entity.ToTable("files_related_mph");

            entity.HasIndex(e => e.FileId, "files_related_mph_fk");

            entity.HasIndex(e => e.RelatedId, "files_related_mph_idix");

            entity.HasIndex(e => e.Order, "files_related_mph_oidx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Field)
                .HasMaxLength(255)
                .HasColumnName("field");
            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.RelatedId).HasColumnName("related_id");
            entity.Property(e => e.RelatedType)
                .HasMaxLength(255)
                .HasColumnName("related_type");

            entity.HasOne(d => d.File).WithMany(p => p.FilesRelatedMphs)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("files_related_mph_fk");
        });

        modelBuilder.Entity<I18nLocale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("i18n_locale_pkey");

            entity.ToTable("i18n_locale");

            entity.HasIndex(e => e.CreatedById, "i18n_locale_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "i18n_locale_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "i18n_locale_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.I18nLocaleCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("i18n_locale_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.I18nLocaleUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("i18n_locale_updated_by_id_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.HasIndex(e => e.CreatedById, "orders_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "orders_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "orders_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PickedUp).HasColumnName("picked_up");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.OrderCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orders_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.OrderUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orders_updated_by_id_fk");
        });

        modelBuilder.Entity<OrdersCustomerLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_customer_lnk_pkey");

            entity.ToTable("orders_customer_lnk");

            entity.HasIndex(e => e.OrderId, "orders_customer_lnk_fk");

            entity.HasIndex(e => e.CustomerId, "orders_customer_lnk_ifk");

            entity.HasIndex(e => new { e.OrderId, e.CustomerId }, "orders_customer_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrdersCustomerLnks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_customer_lnk_ifk");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersCustomerLnks)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_customer_lnk_fk");
        });

        modelBuilder.Entity<OrdersEventDateTimeLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_event_date_time_lnk_pkey");

            entity.ToTable("orders_event_date_time_lnk");

            entity.HasIndex(e => e.OrderId, "orders_event_date_time_lnk_fk");

            entity.HasIndex(e => e.EventDateTimeId, "orders_event_date_time_lnk_ifk");

            entity.HasIndex(e => new { e.OrderId, e.EventDateTimeId }, "orders_event_date_time_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventDateTimeId).HasColumnName("event_date_time_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.EventDateTime).WithMany(p => p.OrdersEventDateTimeLnks)
                .HasForeignKey(d => d.EventDateTimeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_event_date_time_lnk_ifk");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersEventDateTimeLnks)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_event_date_time_lnk_fk");
        });

        modelBuilder.Entity<OrdersPaymentLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_payment_lnk_pkey");

            entity.ToTable("orders_payment_lnk");

            entity.HasIndex(e => e.OrderId, "orders_payment_lnk_fk");

            entity.HasIndex(e => e.PaymentId, "orders_payment_lnk_ifk");

            entity.HasIndex(e => new { e.OrderId, e.PaymentId }, "orders_payment_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersPaymentLnks)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_payment_lnk_fk");

            entity.HasOne(d => d.Payment).WithMany(p => p.OrdersPaymentLnks)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_payment_lnk_ifk");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.HasIndex(e => e.CreatedById, "payments_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "payments_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "payments_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(255)
                .HasColumnName("payment_status");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.PaymentCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payments_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.PaymentUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payments_updated_by_id_fk");
        });

        modelBuilder.Entity<ShopSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shop_settings_pkey");

            entity.ToTable("shop_settings");

            entity.HasIndex(e => e.CreatedById, "shop_settings_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "shop_settings_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "shop_settings_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DataType)
                .HasMaxLength(255)
                .HasColumnName("data_type");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .HasColumnName("display_name");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.SettingName)
                .HasMaxLength(255)
                .HasColumnName("setting_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.ShopSettingCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shop_settings_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.ShopSettingUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shop_settings_updated_by_id_fk");
        });

        modelBuilder.Entity<ShopSettingValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shop_setting_values_pkey");

            entity.ToTable("shop_setting_values");

            entity.HasIndex(e => e.CreatedById, "shop_setting_values_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "shop_setting_values_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "shop_setting_values_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.OptionValue)
                .HasMaxLength(255)
                .HasColumnName("option_value");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.ShopSettingValueCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shop_setting_values_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.ShopSettingValueUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shop_setting_values_updated_by_id_fk");
        });

        modelBuilder.Entity<ShopSettingValuesOwnerLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shop_setting_values_owner_lnk_pkey");

            entity.ToTable("shop_setting_values_owner_lnk");

            entity.HasIndex(e => e.ShopSettingValueId, "shop_setting_values_owner_lnk_fk");

            entity.HasIndex(e => e.UserId, "shop_setting_values_owner_lnk_ifk");

            entity.HasIndex(e => new { e.ShopSettingValueId, e.UserId }, "shop_setting_values_owner_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ShopSettingValueId).HasColumnName("shop_setting_value_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ShopSettingValue).WithMany(p => p.ShopSettingValuesOwnerLnks)
                .HasForeignKey(d => d.ShopSettingValueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shop_setting_values_owner_lnk_fk");

            entity.HasOne(d => d.User).WithMany(p => p.ShopSettingValuesOwnerLnks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shop_setting_values_owner_lnk_ifk");
        });

        modelBuilder.Entity<ShopSettingValuesShopSettingLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shop_setting_values_shop_setting_lnk_pkey");

            entity.ToTable("shop_setting_values_shop_setting_lnk");

            entity.HasIndex(e => e.ShopSettingValueId, "shop_setting_values_shop_setting_lnk_fk");

            entity.HasIndex(e => e.ShopSettingId, "shop_setting_values_shop_setting_lnk_ifk");

            entity.HasIndex(e => e.ShopSettingValueOrd, "shop_setting_values_shop_setting_lnk_oifk");

            entity.HasIndex(e => new { e.ShopSettingValueId, e.ShopSettingId }, "shop_setting_values_shop_setting_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ShopSettingId).HasColumnName("shop_setting_id");
            entity.Property(e => e.ShopSettingValueId).HasColumnName("shop_setting_value_id");
            entity.Property(e => e.ShopSettingValueOrd).HasColumnName("shop_setting_value_ord");

            entity.HasOne(d => d.ShopSetting).WithMany(p => p.ShopSettingValuesShopSettingLnks)
                .HasForeignKey(d => d.ShopSettingId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shop_setting_values_shop_setting_lnk_ifk");

            entity.HasOne(d => d.ShopSettingValue).WithMany(p => p.ShopSettingValuesShopSettingLnks)
                .HasForeignKey(d => d.ShopSettingValueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shop_setting_values_shop_setting_lnk_fk");
        });

        modelBuilder.Entity<StrapiApiToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_api_tokens_pkey");

            entity.ToTable("strapi_api_tokens");

            entity.HasIndex(e => e.CreatedById, "strapi_api_tokens_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_api_tokens_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_api_tokens_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessKey)
                .HasMaxLength(255)
                .HasColumnName("access_key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.EncryptedKey).HasColumnName("encrypted_key");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.LastUsedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("last_used_at");
            entity.Property(e => e.Lifespan).HasColumnName("lifespan");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiApiTokenCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_api_tokens_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiApiTokenUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_api_tokens_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiApiTokenPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_api_token_permissions_pkey");

            entity.ToTable("strapi_api_token_permissions");

            entity.HasIndex(e => e.CreatedById, "strapi_api_token_permissions_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_api_token_permissions_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_api_token_permissions_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiApiTokenPermissionCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_api_token_permissions_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiApiTokenPermissionUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_api_token_permissions_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiApiTokenPermissionsTokenLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_api_token_permissions_token_lnk_pkey");

            entity.ToTable("strapi_api_token_permissions_token_lnk");

            entity.HasIndex(e => e.ApiTokenPermissionId, "strapi_api_token_permissions_token_lnk_fk");

            entity.HasIndex(e => e.ApiTokenId, "strapi_api_token_permissions_token_lnk_ifk");

            entity.HasIndex(e => e.ApiTokenPermissionOrd, "strapi_api_token_permissions_token_lnk_oifk");

            entity.HasIndex(e => new { e.ApiTokenPermissionId, e.ApiTokenId }, "strapi_api_token_permissions_token_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiTokenId).HasColumnName("api_token_id");
            entity.Property(e => e.ApiTokenPermissionId).HasColumnName("api_token_permission_id");
            entity.Property(e => e.ApiTokenPermissionOrd).HasColumnName("api_token_permission_ord");

            entity.HasOne(d => d.ApiToken).WithMany(p => p.StrapiApiTokenPermissionsTokenLnks)
                .HasForeignKey(d => d.ApiTokenId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_api_token_permissions_token_lnk_ifk");

            entity.HasOne(d => d.ApiTokenPermission).WithMany(p => p.StrapiApiTokenPermissionsTokenLnks)
                .HasForeignKey(d => d.ApiTokenPermissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_api_token_permissions_token_lnk_fk");
        });

        modelBuilder.Entity<StrapiCoreStoreSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_core_store_settings_pkey");

            entity.ToTable("strapi_core_store_settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Environment)
                .HasMaxLength(255)
                .HasColumnName("environment");
            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .HasColumnName("key");
            entity.Property(e => e.Tag)
                .HasMaxLength(255)
                .HasColumnName("tag");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<StrapiDatabaseSchema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_database_schema_pkey");

            entity.ToTable("strapi_database_schema");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Hash)
                .HasMaxLength(255)
                .HasColumnName("hash");
            entity.Property(e => e.Schema)
                .HasColumnType("json")
                .HasColumnName("schema");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
        });

        modelBuilder.Entity<StrapiHistoryVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_history_versions_pkey");

            entity.ToTable("strapi_history_versions");

            entity.HasIndex(e => e.CreatedById, "strapi_history_versions_created_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentType)
                .HasMaxLength(255)
                .HasColumnName("content_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.RelatedDocumentId)
                .HasMaxLength(255)
                .HasColumnName("related_document_id");
            entity.Property(e => e.Schema)
                .HasColumnType("jsonb")
                .HasColumnName("schema");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiHistoryVersions)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_history_versions_created_by_id_fk");
        });

        modelBuilder.Entity<StrapiMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_migrations_pkey");

            entity.ToTable("strapi_migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
        });

        modelBuilder.Entity<StrapiMigrationsInternal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_migrations_internal_pkey");

            entity.ToTable("strapi_migrations_internal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
        });

        modelBuilder.Entity<StrapiRelease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_releases_pkey");

            entity.ToTable("strapi_releases");

            entity.HasIndex(e => e.CreatedById, "strapi_releases_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_releases_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_releases_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.ReleasedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("released_at");
            entity.Property(e => e.ScheduledAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("scheduled_at");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.Timezone)
                .HasMaxLength(255)
                .HasColumnName("timezone");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiReleaseCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_releases_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiReleaseUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_releases_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiReleaseAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_release_actions_pkey");

            entity.ToTable("strapi_release_actions");

            entity.HasIndex(e => e.CreatedById, "strapi_release_actions_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_release_actions_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_release_actions_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentType)
                .HasMaxLength(255)
                .HasColumnName("content_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.EntryDocumentId)
                .HasMaxLength(255)
                .HasColumnName("entry_document_id");
            entity.Property(e => e.IsEntryValid).HasColumnName("is_entry_valid");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiReleaseActionCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_release_actions_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiReleaseActionUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_release_actions_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiReleaseActionsReleaseLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_release_actions_release_lnk_pkey");

            entity.ToTable("strapi_release_actions_release_lnk");

            entity.HasIndex(e => e.ReleaseActionId, "strapi_release_actions_release_lnk_fk");

            entity.HasIndex(e => e.ReleaseId, "strapi_release_actions_release_lnk_ifk");

            entity.HasIndex(e => e.ReleaseActionOrd, "strapi_release_actions_release_lnk_oifk");

            entity.HasIndex(e => new { e.ReleaseActionId, e.ReleaseId }, "strapi_release_actions_release_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReleaseActionId).HasColumnName("release_action_id");
            entity.Property(e => e.ReleaseActionOrd).HasColumnName("release_action_ord");
            entity.Property(e => e.ReleaseId).HasColumnName("release_id");

            entity.HasOne(d => d.ReleaseAction).WithMany(p => p.StrapiReleaseActionsReleaseLnks)
                .HasForeignKey(d => d.ReleaseActionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_release_actions_release_lnk_fk");

            entity.HasOne(d => d.Release).WithMany(p => p.StrapiReleaseActionsReleaseLnks)
                .HasForeignKey(d => d.ReleaseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_release_actions_release_lnk_ifk");
        });

        modelBuilder.Entity<StrapiTransferToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_transfer_tokens_pkey");

            entity.ToTable("strapi_transfer_tokens");

            entity.HasIndex(e => e.CreatedById, "strapi_transfer_tokens_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_transfer_tokens_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_transfer_tokens_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessKey)
                .HasMaxLength(255)
                .HasColumnName("access_key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.LastUsedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("last_used_at");
            entity.Property(e => e.Lifespan).HasColumnName("lifespan");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiTransferTokenCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_transfer_tokens_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiTransferTokenUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_transfer_tokens_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiTransferTokenPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_transfer_token_permissions_pkey");

            entity.ToTable("strapi_transfer_token_permissions");

            entity.HasIndex(e => e.CreatedById, "strapi_transfer_token_permissions_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_transfer_token_permissions_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_transfer_token_permissions_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiTransferTokenPermissionCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_transfer_token_permissions_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiTransferTokenPermissionUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_transfer_token_permissions_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiTransferTokenPermissionsTokenLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_transfer_token_permissions_token_lnk_pkey");

            entity.ToTable("strapi_transfer_token_permissions_token_lnk");

            entity.HasIndex(e => e.TransferTokenPermissionId, "strapi_transfer_token_permissions_token_lnk_fk");

            entity.HasIndex(e => e.TransferTokenId, "strapi_transfer_token_permissions_token_lnk_ifk");

            entity.HasIndex(e => e.TransferTokenPermissionOrd, "strapi_transfer_token_permissions_token_lnk_oifk");

            entity.HasIndex(e => new { e.TransferTokenPermissionId, e.TransferTokenId }, "strapi_transfer_token_permissions_token_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TransferTokenId).HasColumnName("transfer_token_id");
            entity.Property(e => e.TransferTokenPermissionId).HasColumnName("transfer_token_permission_id");
            entity.Property(e => e.TransferTokenPermissionOrd).HasColumnName("transfer_token_permission_ord");

            entity.HasOne(d => d.TransferToken).WithMany(p => p.StrapiTransferTokenPermissionsTokenLnks)
                .HasForeignKey(d => d.TransferTokenId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_transfer_token_permissions_token_lnk_ifk");

            entity.HasOne(d => d.TransferTokenPermission).WithMany(p => p.StrapiTransferTokenPermissionsTokenLnks)
                .HasForeignKey(d => d.TransferTokenPermissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_transfer_token_permissions_token_lnk_fk");
        });

        modelBuilder.Entity<StrapiWebhook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_webhooks_pkey");

            entity.ToTable("strapi_webhooks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Events)
                .HasColumnType("jsonb")
                .HasColumnName("events");
            entity.Property(e => e.Headers)
                .HasColumnType("jsonb")
                .HasColumnName("headers");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Url).HasColumnName("url");
        });

        modelBuilder.Entity<StrapiWorkflow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_workflows_pkey");

            entity.ToTable("strapi_workflows");

            entity.HasIndex(e => e.CreatedById, "strapi_workflows_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_workflows_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_workflows_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentTypes)
                .HasColumnType("jsonb")
                .HasColumnName("content_types");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiWorkflowCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_workflows_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiWorkflowUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_workflows_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiWorkflowsStage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_workflows_stages_pkey");

            entity.ToTable("strapi_workflows_stages");

            entity.HasIndex(e => e.CreatedById, "strapi_workflows_stages_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "strapi_workflows_stages_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "strapi_workflows_stages_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.StrapiWorkflowsStageCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_workflows_stages_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.StrapiWorkflowsStageUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("strapi_workflows_stages_updated_by_id_fk");
        });

        modelBuilder.Entity<StrapiWorkflowsStageRequiredToPublishLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_workflows_stage_required_to_publish_lnk_pkey");

            entity.ToTable("strapi_workflows_stage_required_to_publish_lnk");

            entity.HasIndex(e => e.WorkflowId, "strapi_workflows_stage_required_to_publish_lnk_fk");

            entity.HasIndex(e => e.WorkflowStageId, "strapi_workflows_stage_required_to_publish_lnk_ifk");

            entity.HasIndex(e => new { e.WorkflowId, e.WorkflowStageId }, "strapi_workflows_stage_required_to_publish_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WorkflowId).HasColumnName("workflow_id");
            entity.Property(e => e.WorkflowStageId).HasColumnName("workflow_stage_id");

            entity.HasOne(d => d.Workflow).WithMany(p => p.StrapiWorkflowsStageRequiredToPublishLnks)
                .HasForeignKey(d => d.WorkflowId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_workflows_stage_required_to_publish_lnk_fk");

            entity.HasOne(d => d.WorkflowStage).WithMany(p => p.StrapiWorkflowsStageRequiredToPublishLnks)
                .HasForeignKey(d => d.WorkflowStageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_workflows_stage_required_to_publish_lnk_ifk");
        });

        modelBuilder.Entity<StrapiWorkflowsStagesPermissionsLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_workflows_stages_permissions_lnk_pkey");

            entity.ToTable("strapi_workflows_stages_permissions_lnk");

            entity.HasIndex(e => e.WorkflowStageId, "strapi_workflows_stages_permissions_lnk_fk");

            entity.HasIndex(e => e.PermissionId, "strapi_workflows_stages_permissions_lnk_ifk");

            entity.HasIndex(e => e.PermissionOrd, "strapi_workflows_stages_permissions_lnk_ofk");

            entity.HasIndex(e => new { e.WorkflowStageId, e.PermissionId }, "strapi_workflows_stages_permissions_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.PermissionOrd).HasColumnName("permission_ord");
            entity.Property(e => e.WorkflowStageId).HasColumnName("workflow_stage_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.StrapiWorkflowsStagesPermissionsLnks)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_workflows_stages_permissions_lnk_ifk");

            entity.HasOne(d => d.WorkflowStage).WithMany(p => p.StrapiWorkflowsStagesPermissionsLnks)
                .HasForeignKey(d => d.WorkflowStageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_workflows_stages_permissions_lnk_fk");
        });

        modelBuilder.Entity<StrapiWorkflowsStagesWorkflowLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strapi_workflows_stages_workflow_lnk_pkey");

            entity.ToTable("strapi_workflows_stages_workflow_lnk");

            entity.HasIndex(e => e.WorkflowStageId, "strapi_workflows_stages_workflow_lnk_fk");

            entity.HasIndex(e => e.WorkflowId, "strapi_workflows_stages_workflow_lnk_ifk");

            entity.HasIndex(e => e.WorkflowStageOrd, "strapi_workflows_stages_workflow_lnk_oifk");

            entity.HasIndex(e => new { e.WorkflowStageId, e.WorkflowId }, "strapi_workflows_stages_workflow_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WorkflowId).HasColumnName("workflow_id");
            entity.Property(e => e.WorkflowStageId).HasColumnName("workflow_stage_id");
            entity.Property(e => e.WorkflowStageOrd).HasColumnName("workflow_stage_ord");

            entity.HasOne(d => d.Workflow).WithMany(p => p.StrapiWorkflowsStagesWorkflowLnks)
                .HasForeignKey(d => d.WorkflowId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_workflows_stages_workflow_lnk_ifk");

            entity.HasOne(d => d.WorkflowStage).WithMany(p => p.StrapiWorkflowsStagesWorkflowLnks)
                .HasForeignKey(d => d.WorkflowStageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("strapi_workflows_stages_workflow_lnk_fk");
        });

        modelBuilder.Entity<UpPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("up_permissions_pkey");

            entity.ToTable("up_permissions");

            entity.HasIndex(e => e.CreatedById, "up_permissions_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "up_permissions_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "up_permissions_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.UpPermissionCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("up_permissions_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.UpPermissionUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("up_permissions_updated_by_id_fk");
        });

        modelBuilder.Entity<UpPermissionsRoleLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("up_permissions_role_lnk_pkey");

            entity.ToTable("up_permissions_role_lnk");

            entity.HasIndex(e => e.PermissionId, "up_permissions_role_lnk_fk");

            entity.HasIndex(e => e.RoleId, "up_permissions_role_lnk_ifk");

            entity.HasIndex(e => e.PermissionOrd, "up_permissions_role_lnk_oifk");

            entity.HasIndex(e => new { e.PermissionId, e.RoleId }, "up_permissions_role_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.PermissionOrd).HasColumnName("permission_ord");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.UpPermissionsRoleLnks)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("up_permissions_role_lnk_fk");

            entity.HasOne(d => d.Role).WithMany(p => p.UpPermissionsRoleLnks)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("up_permissions_role_lnk_ifk");
        });

        modelBuilder.Entity<UpRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("up_roles_pkey");

            entity.ToTable("up_roles");

            entity.HasIndex(e => e.CreatedById, "up_roles_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "up_roles_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "up_roles_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.UpRoleCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("up_roles_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.UpRoleUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("up_roles_updated_by_id_fk");
        });

        modelBuilder.Entity<UpUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("up_users_pkey");

            entity.ToTable("up_users");

            entity.HasIndex(e => e.CreatedById, "up_users_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "up_users_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "up_users_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Blocked).HasColumnName("blocked");
            entity.Property(e => e.ConfirmationToken)
                .HasMaxLength(255)
                .HasColumnName("confirmation_token");
            entity.Property(e => e.Confirmed).HasColumnName("confirmed");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Provider)
                .HasMaxLength(255)
                .HasColumnName("provider");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.ResetPasswordToken)
                .HasMaxLength(255)
                .HasColumnName("reset_password_token");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.UpUserCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("up_users_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.UpUserUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("up_users_updated_by_id_fk");
        });

        modelBuilder.Entity<UpUsersRoleLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("up_users_role_lnk_pkey");

            entity.ToTable("up_users_role_lnk");

            entity.HasIndex(e => e.UserId, "up_users_role_lnk_fk");

            entity.HasIndex(e => e.RoleId, "up_users_role_lnk_ifk");

            entity.HasIndex(e => e.UserOrd, "up_users_role_lnk_oifk");

            entity.HasIndex(e => new { e.UserId, e.RoleId }, "up_users_role_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserOrd).HasColumnName("user_ord");

            entity.HasOne(d => d.Role).WithMany(p => p.UpUsersRoleLnks)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("up_users_role_lnk_ifk");

            entity.HasOne(d => d.User).WithMany(p => p.UpUsersRoleLnks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("up_users_role_lnk_fk");
        });

        modelBuilder.Entity<UploadFolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("upload_folders_pkey");

            entity.ToTable("upload_folders");

            entity.HasIndex(e => e.CreatedById, "upload_folders_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "upload_folders_documents_idx");

            entity.HasIndex(e => e.PathId, "upload_folders_path_id_index").IsUnique();

            entity.HasIndex(e => e.Path, "upload_folders_path_index").IsUnique();

            entity.HasIndex(e => e.UpdatedById, "upload_folders_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .HasColumnName("path");
            entity.Property(e => e.PathId).HasColumnName("path_id");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.UploadFolderCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("upload_folders_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.UploadFolderUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("upload_folders_updated_by_id_fk");
        });

        modelBuilder.Entity<UploadFoldersParentLnk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("upload_folders_parent_lnk_pkey");

            entity.ToTable("upload_folders_parent_lnk");

            entity.HasIndex(e => e.FolderId, "upload_folders_parent_lnk_fk");

            entity.HasIndex(e => e.InvFolderId, "upload_folders_parent_lnk_ifk");

            entity.HasIndex(e => e.FolderOrd, "upload_folders_parent_lnk_oifk");

            entity.HasIndex(e => new { e.FolderId, e.InvFolderId }, "upload_folders_parent_lnk_uq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FolderId).HasColumnName("folder_id");
            entity.Property(e => e.FolderOrd).HasColumnName("folder_ord");
            entity.Property(e => e.InvFolderId).HasColumnName("inv_folder_id");

            entity.HasOne(d => d.Folder).WithMany(p => p.UploadFoldersParentLnkFolders)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("upload_folders_parent_lnk_fk");

            entity.HasOne(d => d.InvFolder).WithMany(p => p.UploadFoldersParentLnkInvFolders)
                .HasForeignKey(d => d.InvFolderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("upload_folders_parent_lnk_ifk");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venues_pkey");

            entity.ToTable("venues");

            entity.HasIndex(e => e.CreatedById, "venues_created_by_id_fk");

            entity.HasIndex(e => new { e.DocumentId, e.Locale, e.PublishedAt }, "venues_documents_idx");

            entity.HasIndex(e => e.UpdatedById, "venues_updated_by_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasColumnName("adress");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(255)
                .HasColumnName("document_id");
            entity.Property(e => e.Locale)
                .HasMaxLength(255)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PostCode)
                .HasMaxLength(255)
                .HasColumnName("post_code");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.VenueCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("venues_created_by_id_fk");

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.VenueUpdatedBies)
                .HasForeignKey(d => d.UpdatedById)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("venues_updated_by_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
