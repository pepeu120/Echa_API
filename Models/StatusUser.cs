﻿namespace echa_backend_dotnet.Models;

public partial class StatusUser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<User>? Users { get; set; }
}
