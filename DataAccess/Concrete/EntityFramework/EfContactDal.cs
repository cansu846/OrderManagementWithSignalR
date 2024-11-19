using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Pages;
using Entities.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact>, IContactDal
    {
        public EfContactDal(SignalRDbContext context) : base(context)
        {
        }
    }
}
