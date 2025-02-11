namespace echa_backend_dotnet.Models;

public partial class ErrorLog
{
    public int Id { get; set; }

    public string ErrorLevel { get; set; } = null!;

    public string ErrorMessage { get; set; } = null!;

    public string? ErrorCode { get; set; }

    public int? UserId { get; set; }

    public DateTime OccurrenceDate { get; set; }

    public string? StackTrace { get; set; }

    public string? RequestData { get; set; }

    public string? AdditionalInfo { get; set; }

    public virtual User? User { get; set; }
}
