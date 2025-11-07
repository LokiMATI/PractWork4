using NotificationLibrary.Notifications;

namespace NotificationLibrary;

public class NotificationFilterOptions
{
    public bool? IsRead { get; set; }
    public NotificationType[]? Types { get; set; } // список нужных типов
    public string? SearchText { get; set; }
    public int? MinPriority { get; set; }
    public SortNotificationBy? SortBy { get; set; } // по Date, Priority, Title
}