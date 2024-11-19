using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISocialMediaService:IGenericService<SocialMedia>
    {
     
    }
}
