using NotificationLibrary.Notifications;

namespace NotificationLibrary.Managers;

public class NotificationManager
{
    public IEnumerable<Notification> FilterAndSort(
        IEnumerable<Notification> notifications,
        NotificationFilterOptions options)
    {
        if (options.SortBy.HasValue)
            notifications = SortNotifications(notifications, options.SortBy.Value);
        
        notifications = FilterNotifications(notifications, options);

        return notifications;
    }

    private static IEnumerable<Notification> FilterNotifications(IEnumerable<Notification> notifications, NotificationFilterOptions options)
    {
        if (options.IsRead.HasValue)
            notifications = notifications.Where(n => n.IsRead == options.IsRead);
        
        if (options.Types is not null)
            notifications = notifications.Where(n => options.Types.Contains(n.Type));
        
        if (options.SearchText is not null)
            notifications = notifications
                .Where(n => (n.Title.Contains(options.SearchText) ||
                             n.Content is not null && n.Content.Contains(options.SearchText)));
        
        if (options.MinPriority.HasValue)
            notifications = notifications.Where(n => n.Priority >= options.MinPriority);
        return notifications;
    }

    private static IEnumerable<Notification> SortNotifications(
        IEnumerable<Notification> enumerable,
        SortNotificationBy options) 
        => options switch
        {
            SortNotificationBy.Date => enumerable.OrderBy(n => n.CreatedAt),
            SortNotificationBy.DateDesc => enumerable.OrderByDescending(n => n.CreatedAt),
            SortNotificationBy.Title => enumerable.OrderBy(n => n.Title),
            SortNotificationBy.TitleDesc => enumerable.OrderByDescending(n => n.Title),
            SortNotificationBy.Priority => enumerable.OrderBy(n => n.Priority),
            SortNotificationBy.PriorityDesc => enumerable.OrderByDescending(n => n.Priority)
        };
}