using DEApp.Models.DTOs;

namespace DEApp.Services
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}
