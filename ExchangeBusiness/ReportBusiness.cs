using ExchangeData;
using ExchangeData.DAO;
using ExchangeData.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBusiness
{
    public class ReportBusiness
    {
        /*private readonly ReportDAO _unitOfWork;*/
        private readonly UnitOfWork _unitOfWork;
        public ReportBusiness()
        {
            /*_unitOfWork = new ReportDAO();*/
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IExchangeResult> GetById(int id)
        {
            try
            {
                var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);
                if (report == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                else
                {
                    return new ExchangeResult(1, "Success", report);
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
                var reports = await _unitOfWork.ReportRepository.GetAllAsync();
                if (reports == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                else
                {
                    return new ExchangeResult(1, "Success", reports);
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
                var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);
                if (report == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                await _unitOfWork.ReportRepository.RemoveAsync(report);
                return new ExchangeResult(1, "Success", report);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> UpdateById(int id, Report reportUpdate)
        {
            try
            {
                var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);
                if (report == null)
                {
                    return new ExchangeResult(-1, "No Data");
                }
                report.Reporter = reportUpdate.Reporter;
                report.Assignee = reportUpdate.Assignee;
                report.ProductId = reportUpdate.ProductId;
                report.ReportTime = reportUpdate.ReportTime;
                report.Reason = reportUpdate.Reason;
                report.ApproveBy = reportUpdate.ApproveBy;
                report.ApproveTime = reportUpdate.ApproveTime;
                report.Reply = reportUpdate.Reply;
                report.Status = reportUpdate.Status;
                await _unitOfWork.ReportRepository.UpdateAsync(report);
                return new ExchangeResult(1, "Success", report);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IExchangeResult> Insert(Report createReport)
        {
            try
            {
                createReport.Id = 0;
                _unitOfWork.ReportRepository.Create(createReport);
                return new ExchangeResult(1, "Success", createReport);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
