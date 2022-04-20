using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        [SecuredOperation("Admin,Moderatör")]
        public IResult Add(Content content)
        {
            _contentDal.Add(content);
            return new SuccessResult("Başarıyla eklendi");
        }

        [SecuredOperation("Admin,Moderatör")]
        public IResult Update(Content content)
        {
            _contentDal.Update(content);
            return new SuccessResult("Başarıyla Güncellendi");
        }

        [SecuredOperation("Admin,Moderatör")]
        public IResult Delete(Content content)
        {
            _contentDal.Delete(content);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<Content> Get(Expression<Func<Content, bool>> filter)
        {
            return new SuccessDataResult<Content>(_contentDal.Get(filter));
        }

        public IDataResult<List<Content>> GetList(Expression<Func<Content, bool>> filter = null)
        {
            return new SuccessDataResult<List<Content>>(_contentDal.GetList(filter));
        }
    }
}
