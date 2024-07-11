
using ExchangeData.Models;
using ExchangeData;
using ExchangeWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeData.DTO;
using System.ComponentModel.DataAnnotations;

namespace ExchangeBusiness
{
    public class TransactionBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public TransactionBusiness()
        {
            _unitOfWork ??= new UnitOfWork(); //if unitofwork == null thi unitofwork = new unitofwork
        }

        public async Task<ExchangeResult> GetAll()
        {
            try
            {
                var transactionList = await _unitOfWork.TransactionRepository.GetAllAsync();
                if (transactionList == null)
                {
                    return new ExchangeResult(-1, "NO USER DATA");
                }
                else
                {
                    return new ExchangeResult(1, "Get Transaction List success", transactionList);
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
                var transactionExist = await _unitOfWork.TransactionRepository.GetByIdAsync(code);
                if (transactionExist == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No sell data by Id");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get sell success", transactionExist);

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
                var transactionExist = await _unitOfWork.TransactionRepository.GetByIdAsync(code);
                if (transactionExist == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No sell data bu Id");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get sell success", transactionExist);

                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
        public async Task<ExchangeResult> Create(Transaction transaction)
        {
            try
            {
                #region business rule
                #endregion
                /*var userExist = await _unitOfWork.UserRepository.GetByIdAsync(user.Id);
                if (userExist == null)
                {*/
                await _unitOfWork.TransactionRepository.CreateAsync(transaction);
                return new ExchangeResult(Const.SUCCESS_GET, "Create success", transaction);


            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
        public async Task<ExchangeResult> Update(UpdateTransactionDTO transaction)
        {
            try
            {
                #region business rule
                #endregion
                var transactionExist = await _unitOfWork.TransactionRepository.GetByIdAsync(transaction.Id);
                if (transactionExist == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "");
                }
                else
                {
                    transactionExist.ProductId = transaction.ProductId;
                    transactionExist.Quantity = transaction.Quantity;
                    transactionExist.Status = transaction.Status;
                    transactionExist.Note = transaction.Note;
                    transactionExist.Price = transaction.Price;
                    transactionExist.CreateAt = DateTime.Now;
                    transactionExist.StudentBuy = 1;
                    transactionExist.TotalPrice = transaction.Price * transaction.Quantity;
                    transactionExist.TypeTransactions = transaction.TypeTransactions;
                    await _unitOfWork.TransactionRepository.UpdateAsync(transactionExist);
                    return new ExchangeResult(Const.SUCCESS_GET, "Update success", transactionExist);

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
                var transactionExist = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
                var list = (await _unitOfWork.TransactionRepository.GetAllAsync()).Where(p => p.ProductId == id);
                if (transactionExist == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "");
                }
                else
                {
                    if(list.Count() ==1)
                    {
                        await _unitOfWork.TransactionRepository.RemoveAsync(transactionExist);
                        return new ExchangeResult(Const.SUCCESS_GET, "Delete success", transactionExist);
                    }
                    else
                    {
                        transactionExist.Status = 2;
                        await _unitOfWork.TransactionRepository.UpdateAsync(transactionExist);
                        return new ExchangeResult(Const.SUCCESS_GET, "Delete success", transactionExist);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
