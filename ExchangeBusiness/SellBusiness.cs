
using ExchangeData.DAO;
using ExchangeData.Models;
using ExchangeData;
using ExchangeData.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeWebApi.DTO;

namespace ExchangeBusiness
{
    public class SellBusiness
    {
        //private readonly UserDAO userDAO;

        private readonly UnitOfWork _unitOfWork;
        public SellBusiness()
        {
            _unitOfWork ??= new UnitOfWork(); //if unitofwork == null thi unitofwork = new unitofwork
        }

        public async Task<ExchangeResult> GetAll()
        {
            try
            {
                var sells = await _unitOfWork.SellRepository.GetAllAsync();
                if (sells == null)
                {
                    return new ExchangeResult(-1, "NO USER DATA");
                }
                else
                {
                    return new ExchangeResult(1, "Get sell List success", sells);
                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(-4, ex.Message);
            }
        }
        public async Task<ExchangeResult> GetById(String code)
        {
            try
            {
                #region business rule
                #endregion
                var sell = await _unitOfWork.SellRepository.GetByIdAsync(code);
                if (sell == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No sell data by Id");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get sell success", sell);

                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
        public async Task<ExchangeResult> GetById(int code)
        {
            try
            {
                #region business rule
                #endregion
                var sell = await _unitOfWork.SellRepository.GetByIdAsync(code);
                if (sell == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No sell data bu Id");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get sell success", sell);

                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
        public async Task<ExchangeResult> Create(CreateSellDTO sell)
        {
            try
            {
                #region business rule
                #endregion
                Transaction transactionBusinessExist = await _unitOfWork.TransactionRepository.GetByIdAsync(sell.TransactionId);

                var m = 1;
                var createSell = new Sell
                {
                    Payment = sell.Payment,
                    PaymentMethod = sell.Payment,
                    TransactionId = sell.TransactionId,
                    Status = 1,
                    CreateOn = DateTime.Now,
                    CashCustomerPay = sell.CashCustomerPay,
                    TotalPrice = transactionBusinessExist.TotalPrice,
                    CashBack = sell.CashCustomerPay - transactionBusinessExist.TotalPrice,
                    Note = sell.Note,
                };
                await _unitOfWork.SellRepository.CreateAsync(createSell);
                return new ExchangeResult(Const.SUCCESS_GET, "Create success", sell);


            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
        public async Task<ExchangeResult> Update(UpdateSellDTO sell)
        {
            try
            {
                #region business rule
                #endregion
                var new_sell = await _unitOfWork.SellRepository.GetByIdAsync(sell.Id);
                if (new_sell == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "");
                }
                else
                {
                    new_sell.Payment = sell.Payment;
                    new_sell.TransactionId = sell.TransactionId;
                    new_sell.Status = sell.Status;
                    new_sell.CashCustomerPay = sell.CashCustomerPay;
                    new_sell.TotalPrice = sell.TotalPrice;
                    new_sell.CashBack = sell.CashCustomerPay - sell.TotalPrice;
                    new_sell.CreateOn = DateTime.Now;
                    new_sell.Note = sell.Note;
                    new_sell.PaymentMethod = sell.Payment;
                    await _unitOfWork.SellRepository.UpdateAsync(new_sell);
                    return new ExchangeResult(Const.SUCCESS_GET, "Update success", sell);

                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
        public async Task<ExchangeResult> Delete(int id)
        {
            try
            {
                #region business rule
                #endregion
                var new_sell = await _unitOfWork.SellRepository.GetByIdAsync(id);
                if (new_sell == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "");
                }
                else
                {
                    await _unitOfWork.SellRepository.RemoveAsync(new_sell);
                    return new ExchangeResult(Const.SUCCESS_GET, "Delete success", new_sell);

                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
    }
}

