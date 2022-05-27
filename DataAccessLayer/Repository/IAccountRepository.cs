using DataAccessLayer.Domain;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IAccountRepository
    {
        Task<string> Login(LoginDomain userModel);
        Task<bool> Logout();
        Task<string> SignUp(SignUpDomain userModel);
    }
}