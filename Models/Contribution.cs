using System;
using System.Collections.Generic;

namespace echa_backend_dotnet.Models;

public partial class Contribution
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public decimal Value { get; set; }

    public string ContributorName { get; set; } = null!;

    public string ContributorEmail { get; set; } = null!;

    public string? Message { get; set; }

    public int StatusContributionId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual StatusContribution StatusContribution { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
