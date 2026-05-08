using Domain.Models.Identity;
using Google.Cloud.Firestore;
using Service.Interface;

namespace Service.Implementation;

public class ProfileService : IProfileService
{
    private readonly FirestoreDb _firestoreDb;
    private const string Collection = "users";

    public ProfileService(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb;
    }

    public async Task CreateProfileAsync(string firebaseUid, string displayName, string phone)
    {
        var docRef = _firestoreDb.Collection(Collection).Document(firebaseUid);
        
        var profile = new UserProfile
        {
            FirebaseUid = firebaseUid,
            DisplayName = displayName,
            Phone = phone,
            AvatarUrl = string.Empty
        };

        await docRef.SetAsync(profile);
    }

    public async Task<UserProfile?> GetProfileAsync(string firebaseUid)
    {
        var docRef = _firestoreDb.Collection(Collection).Document(firebaseUid);
        var snapshot = await docRef.GetSnapshotAsync();

        if (!snapshot.Exists) return null;

        return snapshot.ConvertTo<UserProfile>();
    }

    public async Task UpdateProfileAsync(string firebaseUid, string displayName, string phone)
    {
        var docRef = _firestoreDb.Collection(Collection).Document(firebaseUid);

        var updates = new Dictionary<string, object>
        {
            { "DisplayName", displayName },
            { "Phone", phone }
        };

        await docRef.UpdateAsync(updates);
    }
    
    public async Task UpdateFcmTokenAsync(string firebaseUid, string fcmToken)
    {
        var docRef = _firestoreDb.Collection(Collection).Document(firebaseUid);

        var updates = new Dictionary<string, object>
        {
            { "FcmToken", fcmToken }
        };

        await docRef.UpdateAsync(updates);
    }
}