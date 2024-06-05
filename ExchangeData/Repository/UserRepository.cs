using ExchangeData.Base;
using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly Net17112313ExchangeContext _context;
        public UserRepository(Net17112313ExchangeContext con ) : base( con ) 
        {
            _context = con;
        }
    }
}
