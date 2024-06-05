using ExchangeData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData
{
    public class UnitOfWork
    {
        private Net17112313ExchangeContext _context;
        private ExchangeRepository _repository;
        private UserRepository _userRepository;
        private ProductRepository _product;
        private ReportRepository _reportRepository;
        public UnitOfWork()
        {
            _context = new Net17112313ExchangeContext();
        }
        public ExchangeRepository ExchangeRepository { get { return _repository ??= new ExchangeRepository(_context); } }
        public UserRepository UserRepository
        {
            get { return _userRepository ??= new Repository.UserRepository(_context); }
        }
        public ProductRepository ProductRepository { get { return _product ??= new Repository.ProductRepository(_context); } }
        public ReportRepository ReportRepository
        {
            get
            {
                return _reportRepository ??= new ReportRepository(_context);
            }
        }
    }
}
