namespace API.CoreSystem.Manager.Domain.DTO
{
    public class Notification
    {
        private readonly List<string> errors = new();
        public List<string> Errors { get { return errors; } }
    }
}
