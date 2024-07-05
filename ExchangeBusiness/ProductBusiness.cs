using ExchangeData;
using ExchangeData.DAO;
using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBusiness
{
    public class ProductBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IExchangeResult> GetAll()
        {
            try
            {
                var products =  await _unitOfWork.ProductRepository.GetAllAsync();
                if(products != null)
                {
                    return new ExchangeResult(Const.SUCCESS_GET,"Success get data", products);
                }
                else { return new ExchangeResult(Const.FAILED_GET, "No data"); }
                
            }catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IExchangeResult> GetById(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product != null)
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Success get data", product);
                }
                else { return new ExchangeResult(Const.FAILED_GET, "No data"); }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IExchangeResult> GetById(string id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product != null)
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Success get data", product);
                }
                else { return new ExchangeResult(Const.FAILED_GET, "No data"); }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> CreateProduct(Product product)
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.CreateAsync(product);
                if (result != null)
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Success create data", result);
                }
                else { return new ExchangeResult(Const.FAILED_GET, "No data"); }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> UpdateProduct(Product product)
        {
            try
            {
                await _unitOfWork.ProductRepository.UpdateAsync(product);
                return new ExchangeResult(Const.SUCCESS_GET, "Updated success!");

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> DeleteProduct(int id)
        {
            try
            {
                Product product =  _unitOfWork.ProductRepository.GetById(id);
                if (_unitOfWork.ProductRepository.Remove(product))
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Removed success!");
                }
                else
                {
                    return new ExchangeResult(Const.FAILED_GET, "Remove data fail!");
                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
