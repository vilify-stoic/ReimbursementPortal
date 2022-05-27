using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using DataAccessLayer.IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RePortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RePortal.Controllers
{
   // [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IReimbursementServices reimbursementService;
        private readonly IMapper mapper;

        public AdminController(IReimbursementServices _reimbursementService, IMapper _mapper)
        {
            reimbursementService = _reimbursementService;
            mapper = _mapper;
        }

        [HttpPost("UpdateReimbursementDetailsByA/{id}")]
        public async Task<ActionResult<bool>> UpdateReimbursementDetailsByA(int id, ReDetailsModel reimbursementDetail)
        {
            var details = mapper.Map<ReDetailsModel, ReimbursementDTO>(reimbursementDetail);
            var check = await reimbursementService.UpdateReimbursement(id, details);
            if (check == false)
            {
                return BadRequest();
            }
            return true;
        }


        [Route("SearchByActiveStatus")]
        [HttpGet]
        public async Task<IEnumerable<ReDetailsModel>> SearchByActiveStatus([FromQuery] string activeStatus)
        {
            var listOfReimbursement = await reimbursementService.GetAllReimbursement();
            var listOfReimbursementModel = mapper.Map<List<ReimbursementDTO>, List<ReDetailsModel>>(listOfReimbursement);
           
            if (activeStatus != null)
            {
                string activeStatusLower = activeStatus.ToLower();
                var pendingReimbursmentlist = listOfReimbursementModel.Where(x => x.ActiveStatus == activeStatus);
                return pendingReimbursmentlist;
            }
            return listOfReimbursementModel;
        }

        [HttpGet("SearchByDetails")]
        public async Task<IEnumerable<ReDetailsModel>> SearchByDetails([FromQuery] string activeStatus, [FromQuery] string email, [FromQuery] string rType)
        {
            var listOfReimbursement = await reimbursementService.GetAllReimbursement();
            var listOfReimbursementModel = mapper.Map<List<ReimbursementDTO>, List<ReDetailsModel>>(listOfReimbursement);
            if (activeStatus != null)
            {
                var pendingReimbursmentlist = listOfReimbursementModel.Where(x => x.ActiveStatus == activeStatus);
                if (email != null && (rType!=null || rType=="All"))
                {
                    string emailLower = email.ToLower();
                    var email_rtypeReimbursmentlist = pendingReimbursmentlist.Where(x => x.RequestedBy == emailLower && x.ReimburementType== rType);
                    return email_rtypeReimbursmentlist;
                }
                else if (email != null)
                {
                    string emailLower = email.ToLower();
                    var emailReimbursmentlist = pendingReimbursmentlist.Where(x => x.RequestedBy == emailLower);
                    return emailReimbursmentlist;
                }
                else if (rType != null || rType == "All")
                {
                    var rTypeReimbursmentlist = pendingReimbursmentlist.Where(x => x.ReimburementType == rType);
                    return rTypeReimbursmentlist;
                }
                return pendingReimbursmentlist;
            }
            return null;
        }

    }
}
