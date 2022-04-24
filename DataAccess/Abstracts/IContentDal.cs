using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstracts
{
    public interface IContentDal : IEntityRepository<Content>
    {
        List<ContentDetailDto> GetContentDetailDtos();
    }
}
