using DataAccessLayer.Domain;
using DataAccessLayer.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Data
{
    public class ReimburesementDbContexts : IdentityDbContext
    {

        public ReimburesementDbContexts(DbContextOptions<ReimburesementDbContexts> options) : base(options)
        {

        }
        public DbSet<ReimbursementDomain> ReimburesementDetailsDb  { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
