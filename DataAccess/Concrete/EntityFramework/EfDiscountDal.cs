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
    public class EfDiscountDal : EfEntityRepositoryBase<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRDbContext dbContext):base(dbContext) { }
    }
}
