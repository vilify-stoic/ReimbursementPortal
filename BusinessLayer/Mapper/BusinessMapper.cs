using AutoMapper;
using BusinessLayer.DTO;
using DataAccessLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public class BusinessMapper : Profile
    {
        public BusinessMapper() : base("BusinessMapper")
        {
            CreateMap<ReimbursementDTO, ReimbursementDomain>().ReverseMap();
            CreateMap<LoginDTO, LoginDomain>().ReverseMap();
            CreateMap<SignUpDTO, SignUpDomain>().ReverseMap();
        }
    }
}


