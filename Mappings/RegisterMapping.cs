using backend.Dto;
using backend.Models;

namespace backend.Extensions
{
    public static class RegisterMapping
    {
        public static UserModel ToEntity(this UserDto userDto)
        {
            return new UserModel
            {
                Username=userDto.Username,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            };
        }
    }
}
