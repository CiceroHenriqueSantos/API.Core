using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Services.Contracts;

namespace API.CoreSystem.Manager.Services
{
    public class NotificationService : INotificationService
    {
        private readonly Notification notification = new();
        public Notification Notification { get { return notification; } }
    }
}
