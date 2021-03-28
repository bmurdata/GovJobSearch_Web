using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace nycgovwork.Models
{
    public class job_info_short
    {
        public string hiring_agency { get; set; }
        public string jobLink { get; set; }
        [Key]
        public int jobNum { get; set; }
        public int job_ID { get; set; }
        public string business_title { get; set; }
        public string civil_title { get; set; }
        public string title_class { get; set; }
        public string job_category { get; set; }
        public string career_level { get; set; }
        public string work_location { get; set; }
        public string division_work_unit { get; set; }
        public string total_openings { get; set; }
        public string title_code { get; set; }
        public string level { get; set; }
        public string proposed_salary_range { get; set; }

        public DateTime posted { get; set; }
        public DateTime post_until { get; set; }
    }
}
