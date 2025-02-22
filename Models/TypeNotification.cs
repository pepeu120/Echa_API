﻿namespace echa_backend_dotnet.Models;

public partial class TypeNotification
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Notification>? Notifications { get; set; }
}
