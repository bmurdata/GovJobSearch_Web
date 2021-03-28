using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nycgovwork.Models;
namespace nycgovwork.Data
{
    public class nycGovContext: DbContext
    {
        public nycGovContext(DbContextOptions<nycGovContext> options) : base(options)
        {

        }
        public DbSet<search_by_agencycode> AgencySearches { get; set; }
        public DbSet<job_info_short> JobMetaData { get; set; }
        public DbSet<job_info_details> JobFullDetails { get; set; }

 
    }
}
