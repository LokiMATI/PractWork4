using NotificationLibrary.Notifications;

namespace NotificationLibrary.Managers;

public interface INotificationManager
{
    public IEnumerable<Notification> FilterAndSort(
        IEnumerable<Notification> notifications,
        NotificationFilterOptions options);
}