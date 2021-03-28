using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace nycgovwork.Models
{
    public class job_info_details
    {
        public string add_info { get; set; }
        public string hours_shift { get; set; }
        public string job_descrip { get; set; }
        public string min_qual { get; set; }
        public string preferred_skills { get; set; }
        public string recruit_contact { get; set; }
        public string residency_req { get; set; }
        public string to_apply { get; set; }
        public string work_location { get; set; }
        [Key]
        public int jobNum { get; set; }


    }
}
