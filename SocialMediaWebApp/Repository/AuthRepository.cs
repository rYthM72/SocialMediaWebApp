using SocialMediaWebApp.Dtos.Account;

namespace SocialMediaWebApp.Repository
{
    public interface IAuthRepository
    {
        Task RegisterUser(RegisterDto registerDto);
    }
    public class AuthRepository : IAuthRepository
    {
        public AuthRepository()
        {
            
        }

        public async Task RegisterUser(RegisterDto registerDto)
        {
            if (registerDto.ConfirmPassword != registerDto.Password)
            {
                throw new Exception("Password and Confirm Password donot match");
            }

        }
    }
}
