using System.ComponentModel.DataAnnotations.Schema;

namespace echa_backend_dotnet.Models;

public partial class Item
{
    public int Id { get; set; }

    public Guid ListId { get; set; }

    public int? CategoryId { get; set; }

    public int StatusItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal TotalValue { get; set; }

    [NotMapped]
    public decimal ValueCollected { get; set; }

    public string? Image { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Contribution>? Contributions { get; set; }

    public virtual List? List { get; set; }

    public virtual StatusItem? StatusItem { get; set; }
}
