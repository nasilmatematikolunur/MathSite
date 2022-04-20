using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IContentService
    {
        IResult Add(Content content);
        IResult Update(Content content);
        IResult Delete(Content content);
        IDataResult<Content> Get(Expression<Func<Content, bool>> filter);
        IDataResult<List<Content>> GetList(Expression<Func<Content, bool>> filter = null);
    }
}
