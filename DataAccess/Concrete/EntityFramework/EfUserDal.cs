using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,MathContext>,IUserDal
    {
    }
}
