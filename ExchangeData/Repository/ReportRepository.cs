using ExchangeData.Base;
using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.Repository
{
    public class ReportRepository : BaseRepository<Report>
    {
        public ReportRepository(Net17112313ExchangeContext context) : base(context)
        {
        }
    }
}
