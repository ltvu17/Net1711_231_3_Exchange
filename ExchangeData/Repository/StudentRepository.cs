using ExchangeData.Base;
using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        private readonly Net17112313ExchangeContext _context;
        public StudentRepository(Net17112313ExchangeContext content) : base(content)
        {
        }
    }
}
