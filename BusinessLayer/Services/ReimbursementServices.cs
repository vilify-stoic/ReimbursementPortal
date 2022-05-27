using AutoMapper;
using BusinessLayer.DTO;
using DataAccessLayer.Domain;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ReimbursementServices : IReimbursementServices
    {

        private readonly IReimbursementRepository reimbursementRepository;
        private readonly IMapper mapper;
        public ReimbursementServices(IReimbursementRepository _reimbursementRepository, IMapper _mapper)
        {
            mapper = _mapper;
            reimbursementRepository = _reimbursementRepository;
        }
        public async Task<bool> AddReimbursement(ReimbursementDTO reimbursementDetail)
        {
            var newReimbursement = mapper.Map<ReimbursementDTO, ReimbursementDomain>(reimbursementDetail);
            return await reimbursementRepository.AddReimbursement(newReimbursement);
             
        }

        public async Task<List<ReimbursementDTO>> GetAllReimbursement()
        {
            var listOfReimbursement = await reimbursementRepository.GetAllReimbursement();
            return mapper.Map<List<ReimbursementDomain>, List<ReimbursementDTO>>(listOfReimbursement);
        }

        public async Task<ReimbursementDTO> GetReimbursementById(int? id)
        {
            var reimbursementById = await reimbursementRepository.GetReimbursementById(id);
            return mapper.Map<ReimbursementDomain, ReimbursementDTO>(reimbursementById);
        }
        public async Task<bool> UpdateReimbursement(int? id,ReimbursementDTO reimbursementDetail)
        {
            var newReimbursement = mapper.Map<ReimbursementDTO, ReimbursementDomain>(reimbursementDetail);
            return await reimbursementRepository.UpdateReimbursement(id,newReimbursement);
        }

        public async Task<bool> DeletereImbursementDetail(int? id)
        {
            return await reimbursementRepository.DeletereImbursementDetail(id);
        }
    }
}
