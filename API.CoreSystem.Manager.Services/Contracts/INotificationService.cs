using API.CoreSystem.Manager.Domain.DTO;

namespace API.CoreSystem.Manager.Services.Contracts
{
    public interface INotificationService
    {
        Notification Notification { get; }
        public bool HasErrors { get { return Notification.Errors.Any(); } }
    }
}
