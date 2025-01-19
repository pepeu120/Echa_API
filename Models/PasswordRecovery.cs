using System;
using System.Collections.Generic;

namespace echa_backend_dotnet.Models;

public partial class PasswordRecovery
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpirationDate { get; set; }

    public DateTime? UtilizationDate { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual User User { get; set; } = null!;
}
