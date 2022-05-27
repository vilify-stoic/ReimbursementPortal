using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using DataAccessLayer.IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RePortal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountServices accountService, IMapper mapper )
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        //POST : /api/AccountController/SignUp
        [HttpPost]
        [Route("Register")]
        public async Task<bool> SignUp(SignUpModel userModel)
        {
            if (ModelState.IsValid)
            {
                var signUpDTO = _mapper.Map<SignUpModel, SignUpDTO>(userModel);
                var result = await _accountService.SignUp(signUpDTO);
                if (result == "true")
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/AccountController/Login
        public async Task<ActionResult<object>> Login(LoginModel userModel)
        {
            if (ModelState.IsValid)
            {
                var loginDTO = _mapper.Map<LoginModel, LoginDTO>(userModel);
                var check = await _accountService.Login(loginDTO);
                if(check=="Basic" || check=="Admin")
                {
                    return new { result="true", role=check };
                }
                return new { result = "false" };
            }
            return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpPost]
        [Route("Logout")]
        //POST : /api/ApplicationUser/Logout
        public async Task<ActionResult<bool>> Logout()
        {
            var result = await _accountService.Logout();
            return result;
        }
    }
}

