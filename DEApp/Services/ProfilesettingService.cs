using DEApp.Interfaces;
using DEApp.Models;
using DEApp.Models.DTOs;
using DEApp.Repositories;

namespace DEApp.Services
{
    public class ProfilesettingService : IProfilesettingService
    {
        private readonly IProfilesettingRepository<int, ProfileSetting> _profilesettingRepository;
        public ProfilesettingService(IProfilesettingRepository<int, ProfileSetting> profilesettingRepository)
        {
            _profilesettingRepository = profilesettingRepository;
        }

        public ProfileSettingDTO AddUserProfile(ProfileSettingDTO profileSettingDTO)
        {
            var profileSetting = new ProfileSetting
            {
                Email = profileSettingDTO.Email,
                FirstName = profileSettingDTO.FirstName,
                LastName = profileSettingDTO.LastName,
                Username = profileSettingDTO.Username,
                MobileNumber = profileSettingDTO.MobileNumber,
                RoleId = profileSettingDTO.RoleId 
            };

            _profilesettingRepository.Add(profileSetting);

            return new ProfileSettingDTO
            {
                UserId = profileSetting.UserId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                RoleId = profileSetting.RoleId 
            };
        }

        public ProfileSettingDTO DeleteUserProfileById(int profileSettingId)
        {
            var profileSetting = _profilesettingRepository.Get(profileSettingId);
            if (profileSetting == null)
            {
                return null;
            }

            _profilesettingRepository.Delete(profileSettingId);

            return new ProfileSettingDTO
            {
                UserId = profileSetting.UserId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                RoleId = profileSetting.RoleId 
            };
        }

        public List<ProfileSettingDTO> GetAllUserProfiles()
        {
            var profileSettings = _profilesettingRepository.GetAll()
                .Select(profileSetting => new ProfileSettingDTO
                {
                    UserId = profileSetting.UserId,
                    Email = profileSetting.Email,
                    FirstName = profileSetting.FirstName,
                    LastName = profileSetting.LastName,
                    Username = profileSetting.Username,
                    MobileNumber = profileSetting.MobileNumber,
                    RoleId = profileSetting.RoleId 
                }).ToList();

            return profileSettings;
        }

        public ProfileSettingDTO GetUserProfileById(int profileSettingId)
        {
            var profileSetting = _profilesettingRepository.Get(profileSettingId);
            if (profileSetting == null)
            {
                return null;
            }

            return new ProfileSettingDTO
            {
                UserId = profileSetting.UserId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                RoleId = profileSetting.RoleId 
            };
        }

        public ProfileSettingDTO UpdateUserProfile(ProfileSettingDTO profileSettingDTO)
        {
            var profileSetting = _profilesettingRepository.Get(profileSettingDTO.UserId);
            if (profileSetting == null)
            {
                return null;
            }

            profileSetting.Email = profileSettingDTO.Email;
            profileSetting.FirstName = profileSettingDTO.FirstName;
            profileSetting.LastName = profileSettingDTO.LastName;
            profileSetting.Username = profileSettingDTO.Username;
            profileSetting.MobileNumber = profileSettingDTO.MobileNumber;
            profileSetting.RoleId = profileSettingDTO.RoleId; 

            _profilesettingRepository.Update(profileSetting);

            return new ProfileSettingDTO
            {
                UserId = profileSetting.UserId,
                Email = profileSettingDTO.Email,
                FirstName = profileSettingDTO.FirstName,
                LastName = profileSettingDTO.LastName,
                Username = profileSettingDTO.Username,
                MobileNumber = profileSettingDTO.MobileNumber,
                RoleId = profileSetting.RoleId 
            };
        }
    }
}
