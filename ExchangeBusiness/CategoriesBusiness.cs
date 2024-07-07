using ExchangeData;
using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBusiness
{
    public class CategoriesBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoriesBusiness()
        {
            /*_unitOfWork = new ReportDAO();*/
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IExchangeResult> GetById(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                else
                {
                    return new ExchangeResult(1, "Success", category);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> GetAll()
        {
            try
            {
                var category = await _unitOfWork.CategoriesRepository.GetAllAsync();
                if (category == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                else
                {
                    return new ExchangeResult(1, "Success", category);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> RemoveById(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                await _unitOfWork.CategoriesRepository.RemoveAsync(category);
                return new ExchangeResult(1, "Success", category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> UpdateById(int id, Category categoryUpdate)
        {
            try
            {
                var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                category.Name = categoryUpdate.Name;
                category.Note = categoryUpdate.Note;
                await _unitOfWork.CategoriesRepository.UpdateAsync(category);
                return new ExchangeResult(1, "Success", category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> Insert(Category category)
        {
            try
            {
                category.Id = 0;
                _unitOfWork.CategoriesRepository.Create(category);
                return new ExchangeResult(1, "Success", category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
