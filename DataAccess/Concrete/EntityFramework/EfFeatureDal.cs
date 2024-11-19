using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFeatureDal : EfEntityRepositoryBase<EntityFeature>, IFeatureDal
    {

        public EfFeatureDal(SignalRDbContext dbContext) : base(dbContext) { }
       
    }
}
