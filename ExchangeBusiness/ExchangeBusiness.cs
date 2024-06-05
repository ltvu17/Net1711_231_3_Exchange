using ExchangeData;
using ExchangeData.Base;
using ExchangeData.DAO;
using ExchangeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBusiness
{
    public class ExchangeBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public ExchangeBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IExchangeResult> GetAll()
        {
            try
            {
                var exchanges = await _unitOfWork.ExchangeRepository.GetAllAsync();
                if (exchanges == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                else
                {
                    return new ExchangeResult(1, "Success", exchanges);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> GetById(int id)
        {
            try
            {
                var exchanges = await _unitOfWork.ExchangeRepository.GetByIdAsync(id);
                if (exchanges == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                else
                {
                    return new ExchangeResult(1, "Success", exchanges);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> Create(Exchange entity)
        {
            try
            {
                var exchanges = await _unitOfWork.ExchangeRepository.CreateAsync(entity);
                if (exchanges != 0)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                else
                {
                    return new ExchangeResult(1, "Success", exchanges);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> Update(int id, Exchange newEntity)
        {
            try
            {
                var exchanges = await _unitOfWork.ExchangeRepository.GetByIdAsync(id);
                if (exchanges == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                exchanges.ExchangeNavigation = newEntity.ExchangeNavigation;
                exchanges.Status = newEntity.Status;
                exchanges.Transaction = newEntity.Transaction;
                _unitOfWork.ExchangeRepository.UpdateAsync(exchanges);
                return new ExchangeResult(1, "Update Saved");
            }
            catch
            {
                return new ExchangeResult(-1, "Save error");
            }
        }
        public async Task<IExchangeResult> Remove(int id)
        {
            try
            {
                var exchanges = await _unitOfWork.ExchangeRepository.GetByIdAsync(id);
                if (exchanges == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }

                await _unitOfWork.ExchangeRepository.RemoveAsync(exchanges);
                return new ExchangeResult(1, "Remove Saved");
            }
            catch
            {
                return new ExchangeResult(-1, "Save error");
            }
        }
    }
}
