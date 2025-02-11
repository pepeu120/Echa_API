using System;
using System.Collections.Generic;

namespace echa_backend_dotnet.Models;

public partial class List
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public int UserId { get; set; }

    public int FontId { get; set; }

    public int StatusListId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? HighlightColor { get; set; }

    public string? Image { get; set; }

    public DateTime? EventDate { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Font? Font { get; set; }

    public virtual ICollection<Item>? Items { get; set; }

    public virtual StatusList? StatusList { get; set; }

    public virtual User? User { get; set; }
}
