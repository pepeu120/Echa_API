﻿namespace echa_backend_dotnet.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Transaction>? Transactions { get; set; }
}
