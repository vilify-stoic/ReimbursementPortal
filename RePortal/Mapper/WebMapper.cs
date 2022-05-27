using AutoMapper;
using BusinessLayer.DTO;
using RePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RePortal.Mapper
{
    public class WebMapper: Profile
    {
        public WebMapper() : base("WebMapper")
        {
            CreateMap< ReDetailsModel ,ReimbursementDTO > ().ReverseMap();
            CreateMap<SignUpModel, SignUpDTO>().ReverseMap();
            CreateMap<LoginModel, LoginDTO>().ReverseMap();
        }
    }
}





