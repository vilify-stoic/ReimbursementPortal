using BusinessLayer.DTO;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IAccountServices
    {
        Task<string> Login(LoginDTO userModel);
        Task<bool> Logout();
        Task<string> SignUp(SignUpDTO userModel);
       
    }
}