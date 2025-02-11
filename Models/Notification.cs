namespace echa_backend_dotnet.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TypeNotificationId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime NotificationDate { get; set; }

    public bool? Read { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual TypeNotification? TypeNotification { get; set; }

    public virtual User? User { get; set; }
}
