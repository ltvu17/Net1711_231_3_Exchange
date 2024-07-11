using ExchangeData.Models;
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
        private SellRepository _sell;
        private TransactionRepository _transaction;
        private CategoriesRepository _categoriesRepository;
        private CommentsRepository _commentssRepository;
        private StudentRepository _studentRepository;
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
        public SellRepository SellRepository
        {
            get
            {
                return _sell ??= new Repository.SellRepository(_context);
            }
        }

        public TransactionRepository TransactionRepository
        {
            get
            {
                return _transaction ??= new Repository.TransactionRepository(_context);
            }
        }
        public CategoriesRepository CategoriesRepository
        {
            get
            {
                return _categoriesRepository ??= new CategoriesRepository(_context);
            }
        }
        public CommentsRepository CommentssRepository
        {
            get
            {
                return _commentssRepository ??= new CommentsRepository(_context);
            }
        }
        public StudentRepository StudentRepository
        {
            get { return _studentRepository ??= new Repository.StudentRepository(_context); }
        }
    }
}
