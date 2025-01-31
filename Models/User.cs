using System;
using System.Collections.Generic;

namespace echa_backend_dotnet.Models;

public partial class User
{
    public int Id { get; set; }

    public int? AuthenticationMethodId { get; set; }

    public int StatusUserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Cpf { get; set; } = null!;

    public string? PixKey { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ContactNumber { get; set; } = null!;

    public string? Password { get; set; }

    public string? ProfileImage { get; set; }

    public string? ExternalAuthId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual AuthenticationMethod? AuthenticationMethod { get; set; }

    public virtual ICollection<ErrorLog>? ErrorLogs { get; set; }

    public virtual ICollection<List>? Lists { get; set; }

    public virtual ICollection<Notification>? Notifications { get; set; }

    public virtual ICollection<PasswordRecovery>? PasswordRecoveries { get; set; }

    public virtual StatusUser? StatusUser { get; set; }
}
