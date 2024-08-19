using DEApp.Data;
using DEApp.Interfaces;
using DEApp.Models;

namespace DEApp.Repositories
{
    public class ProfilesettingRepository : IProfilesettingRepository<int , ProfileSetting>
    {
        private readonly DeappContext _context;

        public ProfilesettingRepository(DeappContext context) 
        { 
            _context = context;        
        }

        public ProfileSetting Add(ProfileSetting item)
        {
           _context.ProfileSettings.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ProfileSetting Delete(int key)
        {
            var ProfileSetting = Get(key);
            if (ProfileSetting != null)
            {
                _context.ProfileSettings.Remove(ProfileSetting);
                _context.SaveChanges(true);
                return (ProfileSetting);
            }
            return null;

        }
           

        public ProfileSetting Get(int key)
        {
            var ProfileSetting = _context.ProfileSettings.FirstOrDefault(p => p.ProfileSettingId == key);
            return ProfileSetting;
        }

        public List<ProfileSetting> GetAll()
        {
           return _context.ProfileSettings.ToList();
        }

        public ProfileSetting Update(ProfileSetting item)
        {
            _context.Entry<ProfileSetting>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
