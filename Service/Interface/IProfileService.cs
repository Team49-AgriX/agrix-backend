using Domain.Models.Identity;

namespace Service.Interface;

public interface IProfileService
{
    Task CreateProfileAsync(string firebaseUid, string displayName, string phone);
    Task<UserProfile?> GetProfileAsync(string firebaseUid);
    Task UpdateProfileAsync(string firebaseUid, string displayName, string phone);
    Task UpdateFcmTokenAsync(string firebaseUid, string fcmToken);
}