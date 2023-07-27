using Flunt.Notifications;

namespace simple_record.service.Services
{
    public class GenericServiceResult
    {
        public GenericServiceResult(string message, bool success,object? data, IReadOnlyCollection<Notification>? errors)
        {
            this.errors = errors;
            this.message = message;
            this.success = success;
            this.data = data;
        }

        public string message { get; set; }
        public IReadOnlyCollection<Notification>? errors { get; set; }
        public bool success { get; set; }
        public object? data { get; set; }
    }
}
