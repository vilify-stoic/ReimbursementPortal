using DataAccessLayer.Data;
using DataAccessLayer.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DataAccessLayer.Repository
{
    public class ReimbursementRepository : IReimbursementRepository
    {
        //instance of DB Context
        private ReimburesementDbContexts _dbContext;

        //constructor
        public ReimbursementRepository(ReimburesementDbContexts context)
        {
            _dbContext = context;
        }

        //add
        public async Task<bool> AddReimbursement(ReimbursementDomain reimbursementDetails)
        {
             _dbContext.ReimburesementDetailsDb.Add(reimbursementDetails);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //update
        public async Task<bool> UpdateReimbursement(int? id, ReimbursementDomain reimbursementDetail)
        {
            if (id != reimbursementDetail.ReimburementId)
            {
                return false;
            }
             _dbContext.ReimburesementDetailsDb.Update(reimbursementDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        //list of all reimburement claim
        public async Task<List<ReimbursementDomain>> GetAllReimbursement()
        {
            return await _dbContext.ReimburesementDetailsDb.ToListAsync();
        }

        //get reimbursement by id
        public async Task<ReimbursementDomain> GetReimbursementById(int? id)
        {
            return await _dbContext.ReimburesementDetailsDb.Where(x => x.ReimburementId == id).FirstAsync();
        }

        //delete by id
        public async Task<bool> DeletereImbursementDetail(int? id)
        {
            ReimbursementDomain reimbursementDetail = _dbContext.ReimburesementDetailsDb.Find(id);
            if (reimbursementDetail == null)
            {
                return false;
            }
            _dbContext.ReimburesementDetailsDb.Remove(reimbursementDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
