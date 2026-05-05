namespace Service.Interface;

public interface INotificationService
{
    Task SendToUserAsync(string firebaseUid, string title, string body, Dictionary<string, string>? data = null);
    Task SendToMultipleAsync(IEnumerable<string> firebaseUids, string title, string body, Dictionary<string, string>? data = null);
}