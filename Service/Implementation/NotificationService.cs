using FirebaseAdmin.Messaging;
using Google.Cloud.Firestore;
using Service.Interface;

namespace Service.Implementation;

public class NotificationService : INotificationService
{
    private readonly FirestoreDb _firestoreDb;
    private const string Collection = "users";

    public NotificationService(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb;
    }

    public async Task SendToUserAsync(string firebaseUid, string title, string body, Dictionary<string, string>? data = null)
    {
        var docRef = _firestoreDb.Collection(Collection).Document(firebaseUid);
        var snapshot = await docRef.GetSnapshotAsync();

        if (!snapshot.Exists) return;

        var fcmToken = snapshot.GetValue<string>("FcmToken");
        if (string.IsNullOrEmpty(fcmToken)) return;

        var message = new Message
        {
            Token = fcmToken,
            Notification = new Notification
            {
                Title = title,
                Body = body
            },
            Data = data
        };

        await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }

    public async Task SendToMultipleAsync(IEnumerable<string> firebaseUids, string title, string body, Dictionary<string, string>? data = null)
    {
        foreach (var uid in firebaseUids)
        {
            await SendToUserAsync(uid, title, body, data);
        }
    }
}