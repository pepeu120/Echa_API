using System;
using System.Collections.Generic;

namespace echa_backend_dotnet.Models;

public partial class StatusContribution
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();
}
