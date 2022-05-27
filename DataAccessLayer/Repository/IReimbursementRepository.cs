using DataAccessLayer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IReimbursementRepository
    {
        Task<bool> AddReimbursement(ReimbursementDomain reimbursementDetails);
        Task<List<ReimbursementDomain>> GetAllReimbursement();
        Task<ReimbursementDomain> GetReimbursementById(int? id);
        Task<bool> UpdateReimbursement(int? id, ReimbursementDomain reimbursementDetail);

        Task<bool> DeletereImbursementDetail(int? id);
    }
}