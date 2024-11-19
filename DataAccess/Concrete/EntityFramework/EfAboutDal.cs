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
    public class EfAboutDal : EfEntityRepositoryBase<About>, IAboutDal
    {
        public EfAboutDal(SignalRDbContext context) : base(context)
        {
        }
    }
}
