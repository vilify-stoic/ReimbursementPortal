using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RePortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReimbursementController : ControllerBase
    {
        private readonly IReimbursementServices reimbursementService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor _httpContext;
        public ReimbursementController(IReimbursementServices _reimbursementService, IMapper _mapper, IWebHostEnvironment _webHostEnvironment, IHttpContextAccessor httpContext)
        {
            reimbursementService = _reimbursementService;
            mapper = _mapper;
            webHostEnvironment = _webHostEnvironment;
            _httpContext = httpContext;
        }

        // POST: api/AddReimbursement
        [HttpPost("AddReimbursement")]
        public async Task<ActionResult<ReDetailsModel>> AddReimbursement(ReDetailsModel reimbursementDetail)
        {
            var details = mapper.Map<ReDetailsModel, ReimbursementDTO>(reimbursementDetail);
            //if (reimbursementDetail.Image != null)
            //{
            // string folder = "Image/";
            // reimbursementDetail.ImageUrl = await UploadImage(folder, reimbursementDetail.Image);
            //}
            var ans = await reimbursementService.AddReimbursement(details);
            if (ans == true)
            {
                return CreatedAtAction("AddReimbursement", new { id = reimbursementDetail.ReimburementId }, reimbursementDetail);
            }
            return NotFound();
        }


        // GET: api/GetAllReimbursement
        [HttpGet("GetAllReimbursementByEmail/{email}")]
        public async Task<ActionResult<List<ReDetailsModel>>> GetAllReimbursementByEmail(string email)
        {
            string emailLower = email.ToLower();
            var listOfReimbursement = await reimbursementService.GetAllReimbursement();
            var listOfReimbursementModel = mapper.Map<List<ReimbursementDTO>, List<ReDetailsModel>>(listOfReimbursement);
            var emaiReimbursmentlist = new List<ReDetailsModel>();
            foreach (var Rdetail in listOfReimbursementModel)
            {
                if (Rdetail.RequestedBy == emailLower)
                {
                    emaiReimbursmentlist.Add(Rdetail);
                }
            }
            return emaiReimbursmentlist;
        }

        // GET: api/ReimbursementDetail/5
        [HttpGet("GetReimbursementById/{id}")]
        public async Task<ActionResult<ReDetailsModel>> GetReimbursementById(int id)
        {
            var reimbursementDetail = await reimbursementService.GetReimbursementById(id);
            if (reimbursementDetail == null)
            {
                return NotFound();
            }
            return mapper.Map<ReimbursementDTO, ReDetailsModel>(reimbursementDetail);
        }


        // PUT: api/ReimbursementDetail/5
        [HttpPost("UpdateReimbursementById/{id}")]
        public async Task<ActionResult<bool>> UpdateReimbursementById(int id, ReDetailsModel reimbursementDetail)
        {
            if (reimbursementDetail.ActiveStatus == "Pending")
            {
                var details = mapper.Map<ReDetailsModel, ReimbursementDTO>(reimbursementDetail);
                var check = await reimbursementService.UpdateReimbursement(id, details);
                if (check == false)
                {
                    return BadRequest();
                }
                return true;
            }
            return false;
        }


        [HttpDelete("DeletereImbursementDetail/{id}")]
        // [Route("DeletereImbursementDetail/{id}")]
        public async Task<ActionResult<bool>> DeletereImbursementDetail(int? id)
        {
            var check = await reimbursementService.DeletereImbursementDetail(id);
            if (check == false)
            {
                return BadRequest();
            }
            return true;
        }
        /*folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);
        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;*/

      /*  [HttpPost("UploadImage")]
        [DisableRequestSizeLimit]*/
        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadImage")]
        public IActionResult UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Image");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }

    /*// GET: api/GetAllReimbursement
    [HttpGet("GetAllReimbursement")]
    public async Task<ActionResult<List<ReDetailsModel>>> GetAllReimbursement()
    {
        var listOfReimbursement = await reimbursementService.GetAllReimbursement();
        return mapper.Map<List<ReimbursementDTO>, List<ReDetailsModel>>(listOfReimbursement);
    }*/
}


        