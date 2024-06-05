using ExchangeData;
using ExchangeData.DAO;
using ExchangeData.Models;


namespace ExchangeBusiness
{
    public class UserBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public UserBusiness()
        {
            _unitOfWork ??= new UnitOfWork() ;
        }


        public async Task<IExchangeResult> GetAll()
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetAllAsync();
                if (users == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No users data");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get users success", users);
                }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> GetByID( int ID)
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetByIdAsync(ID);
                if (users == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No user data");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get user success", users);
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
                var users = await _unitOfWork.UserRepository.GetByIdAsync(ID);
                if (users == null)
                {
                    return new ExchangeResult(Const.WARNING_NO_DATA, "No user data");
                }
                else
                {
                    return new ExchangeResult(Const.SUCCESS_GET, "Get user success", users);
                }

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }


        public async Task<IExchangeResult> CreateUser(UserDTO User)
        {
            try
            {
                ExchangeData.Models.User user = new ExchangeData.Models.User
                {
                    Id = User.Id,
                    Name = User.Name,
                    Password = User.Password,
                    Role = User.Role
                };
                var users = await _unitOfWork.UserRepository.CreateAsync(user);
                return new ExchangeResult(Const.SUCCESS_CREATE, "Create user success", user);
                

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }


        public async Task<IExchangeResult> UpdateUser(UserDTO User)
        {
            try
            {
                ExchangeData.Models.User user = new ExchangeData.Models.User
                {
                    Id = User.Id,
                    Name = User.Name,
                    Password = User.Password,
                    Role = User.Role
                };
                 _unitOfWork.UserRepository.UpdateAsync(user);
                return new ExchangeResult(Const.SUCCESS_CREATE, "Update user success", user);
                

            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IExchangeResult> DeleteUser(string User)
        {
            try
            {
                User remove = _unitOfWork.UserRepository.GetById(User);
                bool users = _unitOfWork.UserRepository.Remove(remove);

                return new ExchangeResult(Const.SUCCESS_CREATE, "Create user success", remove);
                


            }
            catch (Exception ex)
            {
                return new ExchangeResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }


    }
}
