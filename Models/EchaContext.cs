using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace echa_backend_dotnet.Models;

public partial class EchaContext : DbContext
{
    public EchaContext()
    {
    }

    public EchaContext(DbContextOptions<EchaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthenticationMethod> AuthenticationMethods { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contribution> Contributions { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Font> Fonts { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PasswordRecovery> PasswordRecoveries { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<StatusContribution> StatusContributions { get; set; }

    public virtual DbSet<StatusItem> StatusItems { get; set; }

    public virtual DbSet<StatusList> StatusLists { get; set; }

    public virtual DbSet<StatusTransaction> StatusTransactions { get; set; }

    public virtual DbSet<StatusUser> StatusUsers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TypeNotification> TypeNotifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthenticationMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("authentication_method");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Contribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contribution");

            entity.HasIndex(e => e.ContributorEmail, "idx_contribution_email");

            entity.HasIndex(e => e.ItemId, "idx_contribution_item_id");

            entity.HasIndex(e => e.StatusContributionId, "idx_contribution_status_contribution_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ContributorEmail).HasColumnName("contributor_email");
            entity.Property(e => e.ContributorName)
                .HasMaxLength(255)
                .HasColumnName("contributor_name");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.ItemId)
                .HasColumnType("int(11)")
                .HasColumnName("item_id");
            entity.Property(e => e.Message)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.IsVisible)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_visible");
            entity.Property(e => e.IsRead)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_read");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .HasColumnName("icon");
            entity.Property(e => e.StatusContributionId)
                .HasDefaultValueSql("1")
                .HasColumnType("int(11)")
                .HasColumnName("status_contribution_id");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
            entity.Property(e => e.Value)
                .HasPrecision(10)
                .HasColumnName("value");

            entity.HasOne(d => d.Item).WithMany(p => p.Contributions)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("contribution_ibfk_1");

            entity.HasOne(d => d.StatusContribution).WithMany(p => p.Contributions)
                .HasForeignKey(d => d.StatusContributionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("contribution_ibfk_2");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("error_log");

            entity.HasIndex(e => e.UserId, "idx_error_log_user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AdditionalInfo)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("additional_info");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(100)
                .HasDefaultValueSql("NULL")
                .HasColumnName("error_code");
            entity.Property(e => e.ErrorLevel)
                .HasMaxLength(50)
                .HasColumnName("error_level");
            entity.Property(e => e.ErrorMessage)
                .HasColumnType("text")
                .HasColumnName("error_message");
            entity.Property(e => e.OccurrenceDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("occurrence_date");
            entity.Property(e => e.RequestData)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("request_data");
            entity.Property(e => e.StackTrace)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("stack_trace");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ErrorLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("error_log_ibfk_1");
        });

        modelBuilder.Entity<Font>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("font");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("item");

            entity.HasIndex(e => e.CategoryId, "idx_item_category_id");

            entity.HasIndex(e => e.ListId, "idx_item_list_id");

            entity.HasIndex(e => e.StatusItemId, "idx_item_status_item_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("category_id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.ListId)
                .HasMaxLength(36)
                .HasColumnName("list_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StatusItemId)
                .HasDefaultValueSql("1")
                .HasColumnType("int(11)")
                .HasColumnName("status_item_id");
            entity.Property(e => e.TotalValue)
                .HasPrecision(10)
                .HasColumnName("total_value");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("item_ibfk_2");

            entity.HasOne(d => d.List).WithMany(p => p.Items)
                .HasForeignKey(d => d.ListId)
                .HasConstraintName("item_ibfk_1");

            entity.HasOne(d => d.StatusItem).WithMany(p => p.Items)
                .HasForeignKey(d => d.StatusItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("item_ibfk_3");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("list");

            entity.HasIndex(e => e.FontId, "idx_list_font_id");

            entity.HasIndex(e => e.StatusListId, "idx_list_status_list_id");

            entity.HasIndex(e => e.UserId, "idx_list_user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FontId)
                .HasDefaultValueSql("1")
                .HasColumnType("int(11)")
                .HasColumnName("font_id");
            entity.Property(e => e.HighlightColor)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#609558'")
                .HasColumnName("highlight_color");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.MessageToContributors)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("message_to_contributors");
            entity.Property(e => e.StatusListId)
                .HasDefaultValueSql("1")
                .HasColumnType("int(11)")
                .HasColumnName("status_list_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Font).WithMany(p => p.Lists)
                .HasForeignKey(d => d.FontId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("list_ibfk_2");

            entity.HasOne(d => d.StatusList).WithMany(p => p.Lists)
                .HasForeignKey(d => d.StatusListId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("list_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.Lists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("list_ibfk_1");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notification");

            entity.HasIndex(e => e.TypeNotificationId, "idx_notification_type_notification_id");

            entity.HasIndex(e => e.UserId, "idx_notification_user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.NotificationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("notification_date");
            entity.Property(e => e.Read)
                .HasDefaultValueSql("'0'")
                .HasColumnName("read");
            entity.Property(e => e.TypeNotificationId)
                .HasColumnType("int(11)")
                .HasColumnName("type_notification_id");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.TypeNotification).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TypeNotificationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("notification_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("notification_ibfk_1");
        });

        modelBuilder.Entity<PasswordRecovery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("password_recovery");

            entity.HasIndex(e => e.UserId, "idx_password_recovery_user_id");

            entity.HasIndex(e => e.Token, "token").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("timestamp")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
            entity.Property(e => e.UtilizationDate)
                .HasDefaultValueSql("NULL")
                .HasColumnType("timestamp")
                .HasColumnName("utilization_date");

            entity.HasOne(d => d.User).WithMany(p => p.PasswordRecoveries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("password_recovery_ibfk_1");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment_method");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<StatusContribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status_contribution");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<StatusItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status_item");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<StatusList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status_list");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<StatusTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status_transaction");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<StatusUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status_user");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transaction");

            entity.HasIndex(e => e.ContributionId, "idx_transaction_contribution_id");

            entity.HasIndex(e => e.PaymentMethodId, "idx_transaction_payment_method_id");

            entity.HasIndex(e => e.StatusTransactionId, "idx_transaction_status_transaction_id");

            entity.HasIndex(e => e.TransactionReference, "transaction_reference").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ContributionId)
                .HasColumnType("int(11)")
                .HasColumnName("contribution_id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.PaymentMethodId)
                .HasColumnType("int(11)")
                .HasColumnName("payment_method_id");
            entity.Property(e => e.StatusTransactionId)
                .HasDefaultValueSql("1")
                .HasColumnType("int(11)")
                .HasColumnName("status_transaction_id");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionReference).HasColumnName("transaction_reference");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Contribution).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ContributionId)
                .HasConstraintName("transaction_ibfk_1");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transaction_ibfk_2");

            entity.HasOne(d => d.StatusTransaction).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.StatusTransactionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("transaction_ibfk_3");
        });

        modelBuilder.Entity<TypeNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("type_notification");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Cpf, "cpf").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.ExternalAuthId, "external_auth_id").IsUnique();

            entity.HasIndex(e => e.AuthenticationMethodId, "idx_user_authentication_method_id");

            entity.HasIndex(e => e.StatusUserId, "idx_user_status_user_id");

            entity.HasIndex(e => e.PixKey, "pix_key").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AuthenticationMethodId)
                .HasColumnType("int(11)")
                .HasColumnName("authentication_method_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .HasColumnName("contact_number");
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .HasColumnName("cpf");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.ExternalAuthId)
                .HasDefaultValueSql("NULL")
                .HasColumnName("external_auth_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasDefaultValueSql("NULL")
                .HasColumnName("password");
            entity.Property(e => e.PixKey).HasColumnName("pix_key");
            entity.Property(e => e.ProfileImage)
                .HasDefaultValueSql("NULL")
                .HasColumnType("text")
                .HasColumnName("profile_image");
            entity.Property(e => e.StatusUserId)
                .HasDefaultValueSql("1")
                .HasColumnType("int(11)")
                .HasColumnName("status_user_id");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("NULL ON UPDATE CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("update_date");

            entity.HasOne(d => d.AuthenticationMethod).WithMany(p => p.Users)
                .HasForeignKey(d => d.AuthenticationMethodId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("user_ibfk_1");

            entity.HasOne(d => d.StatusUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("user_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
