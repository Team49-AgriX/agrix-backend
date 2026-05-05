using Google.Cloud.Firestore;

namespace Domain.Models.Identity;

[FirestoreData]
public class UserProfile
{
    [FirestoreProperty]
    public string DisplayName { get; set; } = string.Empty;
    
    [FirestoreProperty]
    public string Phone { get; set; } = string.Empty;
    
    [FirestoreProperty]
    public string AvatarUrl { get; set; } = string.Empty;
    
    [FirestoreProperty]
    public string FirebaseUid { get; set; } = string.Empty;
    
    [FirestoreProperty]
    public string FcmToken { get; set; } = string.Empty;
}