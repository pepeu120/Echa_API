using System;
using System.Collections.Generic;

namespace echa_backend_dotnet.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
