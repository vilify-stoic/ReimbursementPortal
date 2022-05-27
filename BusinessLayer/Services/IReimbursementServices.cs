using BusinessLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IReimbursementServices
    {
        Task<bool> AddReimbursement(ReimbursementDTO reimbursementDetail);
        Task<List<ReimbursementDTO>> GetAllReimbursement();
        Task<ReimbursementDTO> GetReimbursementById(int? id);
        Task<bool> UpdateReimbursement(int? id,ReimbursementDTO reimbursementDetail);
        Task<bool> DeletereImbursementDetail(int? id);
    }
}