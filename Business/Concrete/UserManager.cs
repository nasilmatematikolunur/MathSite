using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstracts;


namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
       public IResult Add(User user)
        { 
            _userDal.Add(user);
            return new SuccessResult("Başarıyla Eklendi");
        }
       
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Başarıyla Değiştirildi");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter));
        }

        public IDataResult<List<User>> GetList(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList(filter),"Başarıyla Listelendi");
        }
    }
}
