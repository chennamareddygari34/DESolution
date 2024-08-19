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
                Role = profileSettingDTO.Role
            };

            _profilesettingRepository.Add(profileSetting);

            return new ProfileSettingDTO
            {
                ProfileSettingId = profileSetting.ProfileSettingId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                Role = profileSetting.Role
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
                ProfileSettingId = profileSetting.ProfileSettingId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                Role = profileSetting.Role
            };
        }

       

        public List<ProfileSettingDTO> GetAllUserProfiles()
        {
            var profileSettings = _profilesettingRepository.GetAll()
                .Select(profileSetting => new ProfileSettingDTO
                {
                    ProfileSettingId = profileSetting.ProfileSettingId,
                    Email = profileSetting.Email,
                    FirstName = profileSetting.FirstName,
                    LastName = profileSetting.LastName,
                    Username = profileSetting.Username,
                    MobileNumber = profileSetting.MobileNumber,
                    Role = profileSetting.Role
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
                ProfileSettingId = profileSetting.ProfileSettingId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                Role = profileSetting.Role
            };
        }

        public ProfileSettingDTO UpdateUserProfile(ProfileSettingDTO profileSettingDTO)
        {
            var profileSetting = _profilesettingRepository.Get(profileSettingDTO.ProfileSettingId);
            if (profileSetting == null)
            {
                return null;
            }

            profileSetting.Email = profileSettingDTO.Email;
            profileSetting.FirstName = profileSettingDTO.FirstName;
            profileSetting.LastName = profileSettingDTO.LastName;
            profileSetting.Username = profileSettingDTO.Username;
            profileSetting.MobileNumber = profileSettingDTO.MobileNumber;
            profileSetting.Role = profileSettingDTO.Role;

            _profilesettingRepository.Update(profileSetting);

            return new ProfileSettingDTO
            {
                ProfileSettingId = profileSetting.ProfileSettingId,
                Email = profileSettingDTO.Email,
                FirstName = profileSettingDTO.FirstName,
                LastName = profileSettingDTO.LastName,
                Username = profileSettingDTO.Username,
                MobileNumber = profileSettingDTO.MobileNumber,
                Role = profileSettingDTO.Role
            };
        }

       
    }
}
