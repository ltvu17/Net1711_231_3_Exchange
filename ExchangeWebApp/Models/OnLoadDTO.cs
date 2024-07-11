using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeWebApp.Models
{
    public class OnLoadDTO
    {
        public List<StudentDTO>? studentList { get; set; } = new List<StudentDTO>();
        public int? total_user { get; set; }
        public int? total_active { get; set; }
        public int? total_Inactive { get; set; }
        public int? new_user_inmonth { get; set; }
    }
}
