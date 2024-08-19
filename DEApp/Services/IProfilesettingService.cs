using DEApp.Models;
using DEApp.Models.DTOs;

namespace DEApp.Services
{
    public interface IProfilesettingService
    {
        public List<ProfileSettingDTO> GetAllUserProfiles();
        public ProfileSettingDTO GetUserProfileById(int ProfileSettingId);
        public ProfileSettingDTO AddUserProfile(ProfileSettingDTO profileSettingDTO);
        public ProfileSettingDTO UpdateUserProfile(ProfileSettingDTO ProfileSettingId);
        public ProfileSettingDTO DeleteUserProfileById(int ProfileSettingId);
    }
}
