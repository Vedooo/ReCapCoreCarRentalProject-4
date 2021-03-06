using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Results.DataResultOptions.DataResults;
using Core.Utilities.Results.ResultOptions.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EfUserManager : IUserService
    {
        IUserDal _userDal;

        public EfUserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {

            if ((user.FirstName == null) && (user.LastName == null) && (user.Email == null) && (user.Password == null))
            {
                return new ErrorResult(Messages.InformationsCantBeEmpty);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(_userDal.GetAll(), Messages.MaintainanceTimeUser);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
