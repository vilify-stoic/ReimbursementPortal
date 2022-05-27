using DataAccessLayer.Data;
using DataAccessLayer.Domain;
using DataAccessLayer.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<string> SignUp(SignUpDomain userModel)
        {
            var applicationUser = new ApplicationUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                FullName = userModel.FullName,
                PanNumber = userModel.PanNumber,
                Bank = userModel.Bank,
                AccountNumber = userModel.AccountNumber
            };
            string result = "false";
            var check = await _userManager.CreateAsync(applicationUser, userModel.Password);
            if (check.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, "Basic");
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                result = "true";
            }
            return result;
        }
        public async Task<string> Login(LoginDomain userModel)
        {
            string result = "false";
            var tempResult = await _signInManager.PasswordSignInAsync(userModel.EmailId,
                             userModel.password, false, false);
           var loginUser = await _userManager.FindByEmailAsync(userModel.EmailId);
            if (tempResult.Succeeded && loginUser != null)
            {
               var roleList = await _userManager.GetRolesAsync(loginUser);
                if(roleList[0]=="Admin")
                {
                    result = "Admin";
                }
                else
                {
                    result = "Basic";
                }
                return result;
            }
            // result = "Invalid Login Attempt";
            return result;
        }

        public async Task<bool> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}