using ExchangeData.Models;
using ExchangeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBusiness
{
    public class CommentsBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public CommentsBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IExchangeResult> GetAll()
        {
            try
            {
                var exchanges = await _unitOfWork.CommentssRepository.GetAllAsync();
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
                var exchanges = await _unitOfWork.CommentssRepository.GetByIdAsync(id);
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
        public async Task<IExchangeResult> Create(Comment entity)
        {
            try
            {
                var exchanges = await _unitOfWork.CommentssRepository.CreateAsync(entity);
                if (exchanges == 0)
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
        public async Task<IExchangeResult> Update(int id, Comment newEntity)
        {
            try
            {
                var comment = await _unitOfWork.CommentssRepository.GetByIdAsync(id);
                if (comment == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                comment.ImageId = newEntity.ImageId;
                comment.Status = newEntity.Status;
                comment.StudentId = newEntity.StudentId;
                comment.ProductId = newEntity.ProductId;
                comment.Content = newEntity.Content;
                comment.CreateOn = newEntity.CreateOn;
                comment.ModifyAt = newEntity.ModifyAt;
                comment.ReplyId = newEntity.ReplyId;
                await _unitOfWork.CommentssRepository.UpdateAsync(comment);
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
                var exchanges = await _unitOfWork.CommentssRepository.GetByIdAsync(id);
                if (exchanges == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }

                await _unitOfWork.CommentssRepository.RemoveAsync(exchanges);
                return new ExchangeResult(1, "Remove Saved");
            }
            catch
            {
                return new ExchangeResult(-1, "Save error");
            }
        }
    }
}
