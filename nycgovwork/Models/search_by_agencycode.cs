using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace nycgovwork.Models
{
    public class search_by_agencycode 
    {
        [Key]
        public int jobNum { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string shortCategory { get; set; }
        public string LongCategory { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string Agency { get; set; }
        public DateTime Posted_Date { get; set; }

    }
}
