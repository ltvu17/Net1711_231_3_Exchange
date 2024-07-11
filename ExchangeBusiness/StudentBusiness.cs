
using ExchangeBusiness.Models;
using ExchangeData;

namespace ExchangeBusiness
{
    public class StudentBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public StudentBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IExchangeResult> GetAll()
        {
            try
            {
                var Students = await _unitOfWork.StudentRepository.GetAllAsync();
                if (Students == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No Students data");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get Students success", Students);
                }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> GetByID(int ID)
        {
            try
            {
                var Students = await _unitOfWork.StudentRepository.GetByIdAsync(ID);
                if (Students == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No Student data");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get Student success", Students);
                }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> GetByID(string ID)
        {
            try
            {
                var Students = await _unitOfWork.StudentRepository.GetByIdAsync(ID);
                if (Students == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No Student data");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get Student success", Students);
                }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IExchangeResult> CreateStudent(StudentDTO Student)
        {
            try
            {
                ExchangeData.Models.Student student = new ExchangeData.Models.Student
                {
                    Name = Student.Name,
                    Address = Student.Address,
                    Phone = Student.Phone,
                    Rate = Student.Rate,
                    Status = Student.Status,
                    UserId = Student.UserId,
                    SeftDescription = Student.SeftDescription,
                    TotalPost = Student.TotalPost,
                    CreatedDate = DateTime.Now,
                    InactiveIn = null,
                    InactiveReason = null,
                };
                    
                var Students = await _unitOfWork.StudentRepository.CreateAsync(student);
                return new ExchangeResult(Const.SUCCESS_CREATE, "Create Student success", student);


            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> UpdateStudent(StudentDTO Student)
        {
            try
            {
                ExchangeData.Models.Student student = new ExchangeData.Models.Student
                {
                    Id = Student.Id,
                    Name = Student.Name,
                    Address = Student.Address,
                    Phone = Student.Phone,
                    Rate = Student.Rate,
                    Status = Student.Status,
                    UserId = Student.UserId,
                    SeftDescription = Student.SeftDescription,
                    TotalPost = Student.TotalPost,
                    CreatedDate = Student.CreatedDate,
                    InactiveIn = Student.InactiveIn,
                    InactiveReason = Student.InactiveReason,
                };
                await _unitOfWork.StudentRepository.UpdateAsync(student);
                return new ExchangeResult(Const.SUCCESS_CREATE, "Update Student success", student);


            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> DeleteStudent(int Student)
        {
            try
            {
                ExchangeData.Models.Student remove = _unitOfWork.StudentRepository.GetById(Student);
                var CommentList =  (await _unitOfWork.CommentssRepository.GetAllAsync()).Where(s=>s.StudentId == Student);
                foreach (var Comment in CommentList) { 
                    await _unitOfWork.CommentssRepository.RemoveAsync(Comment);
                }
/*                var Products = (await _unitOfWork.ProductRepository.GetAllAsync()).Where(s => s.StudentId == Student);
                foreach (var Product in Products)
                {
                    await _unitOfWork.ProductRepository.RemoveAsync(Product);
                }
                var Products = (await _unitOfWork.ProductRepository.GetAllAsync()).Where(s => s.StudentId == Student);
                foreach (var Product in Products)
                {
                    await _unitOfWork.ProductRepository.RemoveAsync(Product);
                }*/
                bool Students = _unitOfWork.StudentRepository.Remove(remove);

                return new ExchangeResult(Const.SUCCESS_CREATE, "Create Student success", remove);



            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

    }
}
