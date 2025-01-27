using System;
using System.Collections.Generic;

namespace echa_backend_dotnet.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int ContributionId { get; set; }

    public int PaymentMethodId { get; set; }

    public int StatusTransactionId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string TransactionReference { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Contribution? Contribution { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual StatusTransaction? StatusTransaction { get; set; }
}
