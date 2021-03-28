using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nycgovwork.Models;

namespace nycgovwork.Data
{
    public class nycgovworkContext : DbContext
    {
        public nycgovworkContext (DbContextOptions<nycgovworkContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("nyc_gov_jobs");
        }
        public DbSet<nycgovwork.Models.search_by_agencycode> search_by_agencycode { get; set; }
        public DbSet<nycgovwork.Models.job_info_short> job_info_short { get; set; }
        public DbSet<nycgovwork.Models.job_info_details> job_info_details { get; set; }
    }
}
