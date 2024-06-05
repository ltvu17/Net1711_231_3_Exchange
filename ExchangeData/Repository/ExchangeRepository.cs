using ExchangeData.Base;
using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.Repository
{
    public class ExchangeRepository: BaseRepository<Exchange>
    {
        public ExchangeRepository(Net17112313ExchangeContext context) : base(context)
        {
            
        }
    }
}
